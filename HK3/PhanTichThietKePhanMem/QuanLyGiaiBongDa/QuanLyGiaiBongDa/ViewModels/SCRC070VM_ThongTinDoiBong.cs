/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 02/05/2017 - SCRC071VM_DSCauThuDoiBong.cs
 */
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC070VM_ThongTinDoiBong : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC070VM_ThongTinDoiBong));
        #region Class Variables
        //Thong tin doi bong
        DoiBongModel _doiBongItem = new DoiBongModel();
        public DoiBongModel DoiBongItem
        {
            get { return _doiBongItem; }
            set
            {
                _doiBongItem = value;
                RaisePropertyChanged("DoiBongItem");
            }
        }
        //Cau thu (Doi truong)
        CauThuModel _cauThuItem = new CauThuModel();
        public CauThuModel CauThuItem
        {
            get { return _cauThuItem; }
            set
            {
                _cauThuItem = value;
                RaisePropertyChanged("CauThuItem");
            }
        }
        ObservableCollection<CauThuModel> _cauThuItems = new ObservableCollection<CauThuModel>();
        public ObservableCollection<CauThuModel> CauThuItems
        {
            get { return _cauThuItems; }
            set
            {
                _cauThuItems = value;
                RaisePropertyChanged("CauThuItems");
            }
        }

        //Huan luyen vien
        HuanLuyenVienModel _hlvItem = new HuanLuyenVienModel();
        public HuanLuyenVienModel HlvItem
        {
            get { return _hlvItem; }
            set
            {
                _hlvItem = value;
                RaisePropertyChanged("HlvItem");
            }
        }
        ObservableCollection<HuanLuyenVienModel> _hlvItems = new ObservableCollection<HuanLuyenVienModel>();
        public ObservableCollection<HuanLuyenVienModel> HlvItems
        {
            get { return _hlvItems; }
            set
            {
                _hlvItems = value;
                RaisePropertyChanged("HlvItems");
            }
        }

        //San Van Dong
        SanVanDongModel _sVDItem = new SanVanDongModel();
        public SanVanDongModel SVDItem
        {
            get { return _sVDItem; }
            set
            {
                _sVDItem = value;
                RaisePropertyChanged("SVDItem");
            }
        }
        ObservableCollection<SanVanDongModel> _sVDItems = new ObservableCollection<SanVanDongModel>();
        public ObservableCollection<SanVanDongModel> SVDItems
        {
            get { return _sVDItems; }
            set
            {
                _sVDItems = value;
                RaisePropertyChanged("SVDItems");
            }
        }

        bool _isControlEnable = false;
        public bool IsControlEnable
        {
            get { return _isControlEnable; }
            set
            {
                _isControlEnable = value;
                RaisePropertyChanged("IsControlEnable");
            }
        }

        string _logoString = "";

        public string LogoString
        {
            get { return _logoString; }
            set
            {
                _logoString = value;
                RaisePropertyChanged("LogoString");
            }
        }

        //Doi bong profile picture source
        BitmapImage _doiBongAva;
        public BitmapImage DoiBongAva
        {
            get { return _doiBongAva; }
            set
            {
                _doiBongAva = value;
                RaisePropertyChanged("DoiBongAva");
            }
        }

        string _tenDoi = string.Empty;
        public string TenDoi
        {
            get { return _tenDoi; }
            set
            {
                _tenDoi = value;
                RaisePropertyChanged("TenDoi");
            }
        }

        //phan quyen nguoi dung
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
        private string MaHLVBefore { get; set; }
        private string MaSVDBefore { get; set; }

        private string EmailNguoiDung = string.Empty;
        #endregion

        #region Constructor
        public SCRC070VM_ThongTinDoiBong(params object[] args)
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
            DoiBongDAO = dao.DoiBongDAO;
            string maDB = ((BangXepHangModel)Args[0]).MaDoi;
            DoiBongItem = DoiBongDAO.GetDoiBong(maDB);
            TenDoi = DoiBongItem.TenDoi;
            HlvItems = new ObservableCollection<HuanLuyenVienModel>(DoiBongDAO
                .GetDanhSachHLV()
                .Where(hlv => hlv.DoiBong == string.Empty || hlv.DoiBong == null || hlv.DoiBong == DoiBongItem.MaDoi).ToList());
            HlvItem = HlvItems.Where(hlv => hlv.MaHLV == DoiBongItem.HuanLuyenVien).FirstOrDefault();
            SVDItems = new ObservableCollection<SanVanDongModel>(DoiBongDAO
                .GetDanhSachSVD()
                .Where(svd => svd.DoiBongSoHuu == string.Empty || svd.DoiBongSoHuu == null || svd.DoiBongSoHuu == DoiBongItem.MaDoi).ToList());
            SVDItem = SVDItems.Where(svd => svd.MaSan == DoiBongItem.SanVanDong).FirstOrDefault();
            CauThuItems = DoiBongDAO.GetDanhSachCauThu(DoiBongItem.MaDoi);
            CauThuItem = CauThuItems.Where(ct => ct.MaCauThu == DoiBongItem.DoiTruong).FirstOrDefault();

            //Lấy mã HLV và SVĐ trước khi thay đổi
            MaHLVBefore = HlvItem == null ? string.Empty : HlvItem.MaHLV;
            MaSVDBefore = SVDItem == null ? string.Empty : SVDItem.MaSan;
            
            //get path of logo from solution
            //var uri = new Uri("pack://application:,,,/Resources/Images/DoibongAva/" + DoiBongItem.Logo);
            LogoString = Constants.IMAGE_DOIBONGAVA_FOLDER + "/" +
                (string.IsNullOrEmpty(DoiBongItem.Logo) ? "NOAVA.jpg" : DoiBongItem.Logo);
            //Set image source bit map for logo
            DoiBongAva = Constants.SetImageSource(LogoString);

            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
        }

        #endregion 

        #region Command
        /*
         * Enable chinh sua thong tin
         */
        private void ExecuteOpenEditCommand(object obj)
        {
            IsControlEnable = true;
        }

        private string _logoFilepath { get; set; }
        /*
         * Chon logo cho doi bong
         */
        private void ExecuteChooseLogoCommand(object obj)
        {
            Log.Info(string.Format("{0} Chon logo doi bong", EmailNguoiDung));
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                _logoFilepath = open.FileName; // Stores Original Path in Textbox    
                DoiBongAva = Constants.SetImageSource(_logoFilepath);
                //string name = System.IO.Path.GetFileName(filepath);
                //string destinationPath = GetDestinationPath(name, "\\QuanLyGiaiBongDa\\component\\Images\\DoibongAva");
            }

        }
        private String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string appPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\ProImages\";
            //String sURL = AppDomain.CurrentDomain.BaseDirectory;
            //sURL = sURL.Substring(0, sURL.Length - 10);
            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }

        private bool CanExecuteChooseLogoCommand(object obj)
        {
            return IsControlEnable;
        }
        /*
         * Save thong tin doi bong
         */
        private void ExecuteSaveEditCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation,
                "Bạn có chắc chắn muốn lưu thông tin không?") == MessageBoxResult.No)
            {
                DoiBongAva = Constants.SetImageSource(LogoString);
                return;
            }

            DoiBongItem.HuanLuyenVien = HlvItem.MaHLV;
            DoiBongItem.SanVanDong = SVDItem.MaSan;
            DoiBongItem.DoiTruong = CauThuItem.MaCauThu;
            DoiBongItem.TenDoi = TenDoi;
            //Set name for image in database
            DoiBongItem.Logo = string.IsNullOrEmpty(_logoFilepath) ? string.Empty : "ava" + (DoiBongItem.MaDoi).Trim() + ".jpg";
            Log.Info(string.Format("{0} Thay doi thong tin doi bong", EmailNguoiDung));
            if (DoiBongDAO.UpdateDoiBong(DoiBongItem, MaHLVBefore, MaSVDBefore))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                    "Cập nhật thông tin đội bóng thành công.");
                //save to resouces
                if (!string.IsNullOrEmpty(_logoFilepath))
                {
                    string destinationPath = Constants.IMAGE_DOIBONGAVA_FOLDER + "\\" + DoiBongItem.Logo;
                    File.Copy(_logoFilepath, destinationPath, true);
                }

                MaHLVBefore = HlvItem == null ? string.Empty : HlvItem.MaHLV;
                MaSVDBefore = SVDItem == null ? string.Empty : SVDItem.MaSan;
                IsControlEnable = false;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                    "Cập nhật thông tin đội bóng không thành công.");
        }

        private bool CanExecuteSaveEditCommand(object obj)
        {
            DateTime namTL = DateTime.Now;
            return IsControlEnable && !string.IsNullOrEmpty(TenDoi)
                && !string.IsNullOrEmpty(DoiBongItem.NamThanhLap.ToString());
        }

        /*
         * Close Window
         */
        private void ExecuteCloseCommand(object obj)
        {
            Log.Info(string.Format("{0} Cloase window", EmailNguoiDung));
            CloseDialogBox();
        }

        /*
         * Open man hinh thong tin san van dong
         */
        private void ExecuteOpenSVDCommand(object obj)
        {
            Log.Info(string.Format("{0} Xem thong tin san van dong", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED050VM_ThongTinSVD", SVDItem, false);
        }
        private bool CanExecuteOpenSVDCommand(object obj)
        {
            return SVDItem != null;
        }

        /*
         * Open man hinh thong tin huan luyen vien
         */
        private void ExecuteOpenHLVCommand(object obj)
        {
            Log.Info(string.Format("{0} Xem thong tin huan luyen vien", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED040VM_ThongTinHLV", HlvItem, false);
        }
        private bool CanExecuteOpenHLVCommand(object obj)
        {
            return HlvItem != null;
        }

        /*
         * Open man hinh danh sach cau thu doi bong
         */
        private void ExecuteOpenDSCTCommand(object obj)
        {
            Log.Info(string.Format("{0} Xem danh sach cau thu doi bong", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCRC071VM_DSCauThuDoiBong", CauThuItems);
        }

        #endregion

        #region Dao
        ISCRC070 DoiBongDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCRC070 DoiBongDAO { get; set; }
        }
        #endregion
    }
}
