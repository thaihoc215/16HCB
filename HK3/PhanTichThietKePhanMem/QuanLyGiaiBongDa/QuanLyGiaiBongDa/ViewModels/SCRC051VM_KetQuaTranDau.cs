using log4net;
using Microsoft.Practices.Unity;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 12/04/2017 - SCRC050VM_LichThiDau.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC051VM_KetQuaTranDau : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC051VM_KetQuaTranDau));
        #region Class Variables
        //Ket qua tran dau
        KetQuaTranDauModel _ketQuaItem = new KetQuaTranDauModel();
        public KetQuaTranDauModel KetQuaItem
        {
            get { return _ketQuaItem; }
            set
            {
                _ketQuaItem = value;
                RaisePropertyChanged("KetQuaItem");
            }
        }

        //Tinh trang tran dau
        Dictionary<int, string> _tinhTrangItem = null;
        public Dictionary<int, string> TinhTrangItem
        {
            get { return _tinhTrangItem; }
            set
            {
                _tinhTrangItem = value;
                RaisePropertyChanged("TinhTrangItem");
            }
        }

        KeyValuePair<int, string> _tinhTrangTranDau;
        public KeyValuePair<int, string> TinhTrangTranDau
        {
            get { return _tinhTrangTranDau; }
            set
            {
                _tinhTrangTranDau = value;
                RaisePropertyChanged("TinhTrangTranDau");
            }
        }

        #region Them ban thang
        string _maBTThem = "";
        public string MaBTThem
        {
            get { return _maBTThem; }
            set { _maBTThem = value;
            RaisePropertyChanged("MaBTThem");
            }
        }
        BanThangModel _themBanThangItem = new BanThangModel();
        public BanThangModel ThemBanThangItem
        {
            get { return _themBanThangItem; }
            set
            {
                _themBanThangItem = value;
                RaisePropertyChanged("ThemBanThangItem");
            }
        }
        //Danh sach ban thang
        BanThangModel _banThangItem = new BanThangModel();
        public BanThangModel BanThangItem
        {
            get { return _banThangItem; }
            set { _banThangItem = value;
            RaisePropertyChanged("BanThangItem");
            }
        }
        ObservableCollection<BanThangModel> _banThangItems = new ObservableCollection<BanThangModel>();
        public ObservableCollection<BanThangModel> BanThangItems
        {
            get { return _banThangItems; }
            set
            {
                _banThangItems = value;
                RaisePropertyChanged("BanThangItems");
            }
        }

        //Danh sach cau thu hai doi bong
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

        //Danh sach doi bong tran dau
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
        ObservableCollection<DoiBongModel> _doiBongItems = new ObservableCollection<DoiBongModel>();
        public ObservableCollection<DoiBongModel> DoiBongItems
        {
            get { return _doiBongItems; }
            set
            {
                _doiBongItems = value;
                RaisePropertyChanged("DoiBongItems");
            }
        }

        //Danh sach loai ban thang va loai ban thang duoc chon
        KeyValuePair<string, string> _loaiBanThangItem = new KeyValuePair<string, string>();
        public KeyValuePair<string, string> LoaiBanThangItem
        {
            get { return _loaiBanThangItem; }
            set
            {
                _loaiBanThangItem = value;
                RaisePropertyChanged("LoaiBanThangItem");
            }
        }
        Dictionary<string, string> _loaiBanThangItems = new Dictionary<string, string>();
        public Dictionary<string, string> LoaiBanThangItems
        {
            get { return _loaiBanThangItems; }
            set
            {
                _loaiBanThangItems = value;
                RaisePropertyChanged("LoaiBanThangItems");
            }
        }

        #endregion
        bool _isControlsEnable = false;
        public bool IsControlsEnable
        {
            get { return _isControlsEnable; }
            set
            {
                _isControlsEnable = value;
                RaisePropertyChanged("IsControlsEnable");
            }
        }
        bool _isAddControlsEnable = false;
        public bool IsAddControlsEnable
        {
            get { return _isAddControlsEnable; }
            set
            {
                _isAddControlsEnable = value;
                RaisePropertyChanged("IsAddControlsEnable");
            }
        }

        public TranDauModel TranDauItem
        {
            get { return (TranDauModel)Args[0]; }
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

        QuyDinhModel quyDinhItem = new QuyDinhModel();
        private string EmailNguoiDung = string.Empty;
        #endregion

        #region Constructor
        public SCRC051VM_KetQuaTranDau(params object[] args)
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
            KetQuaTranDauDAO = dao.KetQuaTranDauDAO;
            QuyDinhDAO = dao.QuyDinhDAO;
            KetQuaItem = KetQuaTranDauDAO.GetKetQuaTranDau(TranDauItem.MaTranDau);
            TinhTrangItem = KetQuaTranDauDAO.GetListTinhTrang();
            TinhTrangTranDau = TinhTrangItem.Where(tt => tt.Key == KetQuaItem.MaTinhTrang).FirstOrDefault();
            BanThangItems = KetQuaTranDauDAO.GetListBanThang(TranDauItem.MaTranDau);

            quyDinhItem = QuyDinhDAO.LoadQuyDinh();
            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
        }
        #endregion

        #region Command

        //Open update ket qua
        private void ExecuteOpenUpdateKetQuaCommand(object obj)
        {
            IsControlsEnable = true;
        }

        //Update ket qua
        private void ExecuteUpdateKetQuaCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn thay đổi kết quả trận đấu?") == System.Windows.MessageBoxResult.No)
                return;
            KetQuaItem.MaTinhTrang = TinhTrangTranDau.Key;
            Log.Info(string.Format("{0} Thay doi thong tin tran dau", EmailNguoiDung));
            if (KetQuaTranDauDAO.UpdateTranDau(KetQuaItem))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thay đổi kết quả trận đấu thành công.");
                KetQuaItem = KetQuaTranDauDAO.GetKetQuaTranDau(TranDauItem.MaTranDau);
                IsControlsEnable = false;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thay đổi kết quả trận đấu không thành công.");
        }

        private bool CanExecuteUpdateKetQuaCommand(object obj)
        {
            //int kq1, kq2;
            //bool bt1 = Int32.TryParse(KetQuaItem.SoBanThangDoiNha.ToString(), out kq1);
            //bool bt2 = Int32.TryParse(KetQuaItem.SoBanThangDoiNha.ToString(), out kq2);
            return IsControlsEnable;
        }
        //Huy update ket qua
        private void ExecuteCancelUpdateCommand(object obj)
        {
            KetQuaItem = KetQuaTranDauDAO.GetKetQuaTranDau(TranDauItem.MaTranDau);
            IsControlsEnable = false;
        }
        private bool CanExecuteCancelUpdateCommand(object obj)
        {
            return IsControlsEnable;
        }

        //Open them ban thang
        private void ExecuteAddBanThangCommand(object obj)
        {
            string maBT = KetQuaTranDauDAO.GetMaxMaBT();
            maBT = maBT.Substring(0, 2) + (Convert.ToInt32(maBT.Substring(2)) + 1).ToString("00000");
            MaBTThem = maBT;
            DoiBongItems = KetQuaTranDauDAO.GetListDoiBong(TranDauItem.MaDoiNha, TranDauItem.MaDoiKhach);
            DoiBongItem = DoiBongItems[0];
            CauThuItems = KetQuaTranDauDAO.GetListCauThu(DoiBongItem.MaDoi);
            CauThuItem = CauThuItems[0];
            LoaiBanThangItems = KetQuaTranDauDAO.GetListLoaiBanThang();
            LoaiBanThangItem = LoaiBanThangItems.FirstOrDefault();
            IsAddControlsEnable = true;
        }
        private bool CanExecuteAddBanThangCommand(object obj)
        {
            return IsAccept && BanThangItems.Count < (KetQuaItem.SoBanThangDoiNha + KetQuaItem.SoBanThangDoiKhach);
        }

        //Thay doi doi bong
        private void ExecuteChangeDoiBongCommand(object obj)
        {
            if (DoiBongItem != null)
            {
                CauThuItems = KetQuaTranDauDAO.GetListCauThu(DoiBongItem.MaDoi);
                CauThuItem = CauThuItems[0];
            }
        }
        //Xac nhan them ban thang
        private void ExecuteConfirmAddBanThangCommand(object obj)
        {
            if(ThemBanThangItem.ThoiDiem > quyDinhItem.TDGhiBan)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thời điểm ghi bàn phải <= " + quyDinhItem.TDGhiBan);
                return;
            }
            ThemBanThangItem.MaBanThang = MaBTThem;
            ThemBanThangItem.DoiBong = DoiBongItem.MaDoi;
            ThemBanThangItem.MaCauThu = CauThuItem.MaCauThu;
            ThemBanThangItem.TranDau = TranDauItem.MaTranDau;
            ThemBanThangItem.LoaiBanThang = LoaiBanThangItem.Key;
            if (ThemBanThangItem.DoiBong.Trim() == TranDauItem.MaDoiNha.Trim())
            {
                var tmp = BanThangItems.Where(bt => bt.TenDoi.Trim() == TranDauItem.TenDoiNha.Trim());
                if (BanThangItems.Where(bt => bt.TenDoi.Trim() == TranDauItem.TenDoiNha.Trim()).Count() == KetQuaItem.SoBanThangDoiNha)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số bàn thắng đội nhà đã tối đa");
                    return;
                }
            }
            else
            {
                if (BanThangItems.Where(bt => bt.TenDoi.Trim() == TranDauItem.TenDoiKhach.Trim()).Count() == KetQuaItem.SoBanThangDoiKhach)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số bàn thắng đội khách đã tối đa");
                    return;
                }
            }
            Log.Info(string.Format("{0} Them ban thang", EmailNguoiDung));
            if (KetQuaTranDauDAO.AddBanThang(ThemBanThangItem))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm bàn thắng thành công.");
                KetQuaItem = KetQuaTranDauDAO.GetKetQuaTranDau(TranDauItem.MaTranDau);
                IsControlsEnable = false;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm bàn thắng không thành công.");
            ResetBanThang(); 
            BanThangItems = KetQuaTranDauDAO.GetListBanThang(TranDauItem.MaTranDau);
            IsControlsEnable = false;
        }
        private bool CanExecuteConfirmAddBanThangCommand(object obj)
        {
            return (ThemBanThangItem.ThoiDiem >=0);
        }
        //Xoa ban thang
        private void ExecuteDeleteBanThangCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa bàn thắng?") == System.Windows.MessageBoxResult.No)
                return;
            KetQuaItem.MaTinhTrang = TinhTrangTranDau.Key;
            Log.Info(string.Format("{0} Xoa ban thang", EmailNguoiDung));
            if (KetQuaTranDauDAO.DeleteBanThang(BanThangItem.MaBanThang))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa bàn thắng thành công.");
                KetQuaItem = KetQuaTranDauDAO.GetKetQuaTranDau(TranDauItem.MaTranDau);
                IsControlsEnable = false;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa bàn thắng không thành công.");

            BanThangItems = KetQuaTranDauDAO.GetListBanThang(TranDauItem.MaTranDau);
        }
        private bool CanExecuteDeleteBanThangCommand(object obj)
        {
            return IsAccept && BanThangItems.Count > 0;
        }      
        //Huy them ban thang
        private void ExecuteCancelAddBanThangCommand(object obj)
        {
            ResetBanThang();            
        }

        void ResetBanThang()
        {
            ThemBanThangItem = new BanThangModel();
            MaBTThem = "";
            DoiBongItems = new ObservableCollection<DoiBongModel>();
            CauThuItems = new ObservableCollection<CauThuModel>();
            LoaiBanThangItems = new Dictionary<string, string>();
            IsAddControlsEnable = false;
        }

        private void ExecuteOpenThePhatCommand(object obj)
        {
            ThePhatModel thePhat = new ThePhatModel();
            thePhat.MaThePhat = 123;
            thePhat.TenTrongTai = TranDauItem.TenTrongTai;
            thePhat.TrongTai = TranDauItem.TrongTai;
            thePhat.TranDau = TranDauItem.MaTranDau;
            Log.Info(string.Format("{0} Open man hinh thong tin the phat", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED060VM_ThongTinThePhat", thePhat, true,TranDauItem.MaDoiNha, TranDauItem.MaDoiKhach);
        }
        #endregion

        #region Dao
        ISCRC051 KetQuaTranDauDAO { get; set; }

        ISCRC080 QuyDinhDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCRC051 KetQuaTranDauDAO { get; set; }

            [Dependency]
            public ISCRC080 QuyDinhDAO { get; set; }
        }
        #endregion
    }
}
