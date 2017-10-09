/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 27/03/2017 - SCRC060VM_Thongtin.cs
 */
using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC060VM_Thongtin : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC060VM_Thongtin));
        #region Class Variables
        TranDauModel _lichDaTrongNgayItem = new TranDauModel();
        public TranDauModel LichDaTrongNgayItem
        {
            get { return _lichDaTrongNgayItem; }
            set
            {
                _lichDaTrongNgayItem = value;
                this.RaisePropertyChanged("LichDaTrongNgayItem");
            }
        }

        ObservableCollection<TranDauModel> _lichDaTrongNgayItems = new ObservableCollection<TranDauModel>();
        public ObservableCollection<TranDauModel> LichDaTrongNgayItems
        {
            get { return _lichDaTrongNgayItems; }
            set
            {
                _lichDaTrongNgayItems = value;
                this.RaisePropertyChanged("LichDaTrongNgayItems");
            }
        }

        BangXepHangModel _doiBongItem = new BangXepHangModel();

        public BangXepHangModel DoiBongItem
        {
            get { return _doiBongItem; }
            set
            {
                _doiBongItem = value;
                this.RaisePropertyChanged("DoiBongItem");
            }
        }

        ObservableCollection<BangXepHangModel> _doiBongItems = new ObservableCollection<BangXepHangModel>();
        public ObservableCollection<BangXepHangModel> DoiBongItems
        {
            get { return _doiBongItems; }
            set
            {
                _doiBongItems = value;
                this.RaisePropertyChanged("DoiBongItems");
            }
        }

        private NguoiDungModel _userLogin = new NguoiDungModel();
        public NguoiDungModel UserLogin
        {
            get { return _userLogin; }
            set
            {
                _userLogin = value;
                RaisePropertyChanged("UserLogin");
            }
        }
        private bool _isAccept = false;
        public bool IsAccept
        {
            get { return _isAccept; }
            set
            {
                _isAccept = value;
                RaisePropertyChanged("IsAccept");
            }
        }

        private string EmailNguoiDung = string.Empty;
        #endregion

        #region Constructor
        public SCRC060VM_Thongtin(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            EmailNguoiDung = Constants.UserUsing.Email;
            var dao = DiContainer.Inject(new Dao());
            UserLogin = Constants.UserUsing;
            ThongTinChinhDAO = dao.ThongTinChinhDAO;
            LichDaTrongNgayItem = null;
            ExecuteGetLichDaCommand(null);
            ExecuteGetBangXHCommand(null);
            IsAccept = UserLogin.LoaiNV > 2 ? false : true;
        }
        #endregion

        #region Command
        private void ExecuteGetLichDaCommand(object obj)
        {
            LichDaTrongNgayItems = ThongTinChinhDAO.GetLichDauTrongNgay();
            LichDaTrongNgayItem = null;
        }

        /*
         * Mo lich dau chi tiet cua giai dau
         */
        private void ExecuteOpenLichDauChiTietCommand(object obj)
        {
            Log.Info(string.Format("{0} Open man hinh lich thi dau", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCRC050VM_LichThiDau");
        }

        /*
         * Mo man hinh danh sach - tim kiem cau thu
         */
        private void ExecuteOpenDsCauThuCommand(object obj)
        {
            Log.Info(string.Format("{0} Open man hinh danh sach cau thu", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCRC030VM_DanhSachCauThu");
        }

        /*
         * Lay bang xep hang cac doi bong
         */
        private void ExecuteGetBangXHCommand(object obj)
        {
            DoiBongItems = ThongTinChinhDAO.GetBangXepHang();
            DoiBongItem = null;
        }

        /*
         * open man hinh dang ki doi bong
         */
        private void ExecuteOpenDangKiDoiBongCommand(object obj)
        {
            Log.Info(string.Format("{0} Open man hinh dang ky doi bong", EmailNguoiDung));
            //Modalless
            ViewForwarder.ForwardModal("SCED020VM_SwitchThongTinDangKy","");
            ExecuteGetBangXHCommand(null);

        }

        private void ExecuteOpenChiTietDoiBongCommand(object obj)
        {
            Log.Info(string.Format("{0} Open man hinh thong tin doi bong", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCRC070VM_ThongTinDoiBong", DoiBongItem);
        }
        private bool CanExecuteOpenChiTietDoiBongCommand(object obj)
        {
            return !(DoiBongItem == null);
        }

        /*
         * Xoa 1 doi bong
         */
        private void ExecuteXoaDoiBongCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa đôi bóng này không?")
                == System.Windows.MessageBoxResult.No)
                return;
            var lstAva = ThongTinChinhDAO.GetDsCauThuDoiBong(DoiBongItem.MaDoi).Where(ct => !string.IsNullOrEmpty(ct.AnhDaiDien));
            Log.Info(string.Format("{0} Xoa doi bong", EmailNguoiDung));
            if (ThongTinChinhDAO.DeleteDoiBong(DoiBongItem.MaDoi))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa đội bóng thành công");
                string destinationPath = Constants.IMAGE_DOIBONGAVA_FOLDER + "\\" + "ava" + DoiBongItem.MaDoi.Trim() + ".jpg";
                File.Delete(destinationPath);

                if (lstAva != null)
                {
                    foreach (CauThuModel cthu in lstAva)
                    {
                        destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + cthu.AnhDaiDien;
                        File.Delete(destinationPath);
                    }
                }
                ExecuteGetBangXHCommand(null);
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa đội bóng không thành công");
        }
        private bool CanExecuteXoaDoiBongCommand(object obj)
        {
            return !(DoiBongItem == null);
        }

        /*
         * Cap nhat lai bang xep hang
         */
        private void ExecuteCapNhatBXHCommand(object obj)
        {   
                ExecuteGetBangXHCommand(null);
        }
        private void ExecuteOpenReportCommand(object obj)
        {
            //su dung report reviewer
            Log.Info(string.Format("{0} Xem report bang xep hang", EmailNguoiDung));
            //Xuat report
            ViewForwarder.ForwardModal("SCRC061VM_ReportBXH");
        }

        /*
         * LogOut
         */
        private void ExecuteLogoutCommand(object obj)
        {
            Log.Info(string.Format("{0} Logout", EmailNguoiDung));
            ViewForwarder.ForwardModeless("SCLG010VM_Login");

            Constants.UserUsing = new NguoiDungModel();
            CloseAction();
        }
        public Action CloseAction { get; set; }
        #endregion

        #region Dao
        ISCRC060 ThongTinChinhDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCRC060 ThongTinChinhDAO { get; set; }
        }
        #endregion
    }
}
