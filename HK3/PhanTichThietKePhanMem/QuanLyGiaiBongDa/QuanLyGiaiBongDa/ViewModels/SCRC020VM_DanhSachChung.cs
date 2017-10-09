using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC020VM_DanhSachChung : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC020VM_DanhSachChung));
        #region Class Variables
        TrongTaiModel _trongTaiItem = new TrongTaiModel();

        public TrongTaiModel TrongTaiItem
        {
            get { return _trongTaiItem; }
            set { _trongTaiItem = value; }
        }
        ObservableCollection<TrongTaiModel> _trongTaiItems = new ObservableCollection<TrongTaiModel>();
        public ObservableCollection<TrongTaiModel> TrongTaiItems
        {
            get { return _trongTaiItems; }
            set
            {
                _trongTaiItems = value;
                RaisePropertyChanged("TrongTaiItems");
            }
        }

        SanVanDongModel _sanVanDongItem = new SanVanDongModel();
        public SanVanDongModel SanVanDongItem
        {
            get { return _sanVanDongItem; }
            set { _sanVanDongItem = value; }
        }
        ObservableCollection<SanVanDongModel> _sanVanDongItems = new ObservableCollection<SanVanDongModel>();
        public ObservableCollection<SanVanDongModel> SanVanDongItems
        {
            get { return _sanVanDongItems; }
            set
            {
                _sanVanDongItems = value;
                RaisePropertyChanged("SanVanDongItems");
            }
        }

        HuanLuyenVienModel _huanLuyenVienItem = new HuanLuyenVienModel();
        public HuanLuyenVienModel HuanLuyenVienItem
        {
            get { return _huanLuyenVienItem; }
            set { _huanLuyenVienItem = value; }
        }
        ObservableCollection<HuanLuyenVienModel> _huanLuyenVienItems = new ObservableCollection<HuanLuyenVienModel>();
        public ObservableCollection<HuanLuyenVienModel> HuanLuyenVienItems
        {
            get { return _huanLuyenVienItems; }
            set
            {
                _huanLuyenVienItems = value;
                RaisePropertyChanged("HuanLuyenVienItems");
            }
        }

        ThePhatModel _thePhatItem = new ThePhatModel();
        public ThePhatModel ThePhatItem
        {
            get { return _thePhatItem; }
            set
            {
                _thePhatItem = value;
                RaisePropertyChanged("ThePhatItem");
            }
        }
        ObservableCollection<ThePhatModel> _thePhatItems = new ObservableCollection<ThePhatModel>();
        public ObservableCollection<ThePhatModel> ThePhatItems
        {
            get { return _thePhatItems; }
            set
            {
                _thePhatItems = value;
                RaisePropertyChanged("ThePhatItems");
            }
        }

        BanThangModel _banThangItem = new BanThangModel();
        public BanThangModel BanthangItem
        {
            get { return _banThangItem; }
            set { _banThangItem = value; }
        }
        ObservableCollection<BanThangModel> _banThangItems = new ObservableCollection<BanThangModel>();
        public ObservableCollection<BanThangModel> BanThangItems
        {
            get { return _banThangItems; }
            set { _banThangItems = value; }
        }

        ObservableCollection<DoiBongModel> _DoiBongItems = new ObservableCollection<DoiBongModel>();
        public ObservableCollection<DoiBongModel> DoiBongItems
        {
            get { return _DoiBongItems; }
            set
            {
                _DoiBongItems = value;
                RaisePropertyChanged("DoiBongItems");
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

        private string EmailNguoiDung = string.Empty;
        #endregion

        #region Constructor
        public SCRC020VM_DanhSachChung(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            DanhSach = dao.DanhSach;
            DoiBongItems = DanhSach.GetDanhSachDoiBong();
            ExecuteGetListHLVCommand(null);
            ExecuteGetListSVDCommand(null);
            ExecuteGetListTrongTaiCommand(null);
            ExecuteGetListThePhatCommand(null);
            ExecuteGetListBanThangCommand(null);

            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        #region Chi tiet
        /*
         * Open man hinh thong tin huan luyen vien
         */
        private void ExecuteGetInfoHLVCommand(object obj)
        {
            Log.Info(string.Format("{0} Mo man hinh thong tin huan luyen vien", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED040VM_ThongTinHLV", HuanLuyenVienItem, false);
            ExecuteGetListHLVCommand(null);
        }
        private bool CanExecuteGetInfoHLVCommand(object obj)
        {
            return (HuanLuyenVienItem != null);
        }
        private void ExecuteAddHLVCommand(object obj)
        {
            HuanLuyenVienItem = new HuanLuyenVienModel();
            Log.Info(string.Format("{0} Mo man hinh them huan luyen vien", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED040VM_ThongTinHLV", HuanLuyenVienItem, true);
            ExecuteGetListHLVCommand(null);
        }

        //San Van Dong
        private void ExecuteGetInfoSVDCommand(object obj)
        {
            Log.Info(string.Format("{0} Mo man hinh thong tin san van dong", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED050VM_ThongTinSVD", SanVanDongItem, false);
            ExecuteGetListSVDCommand(null);
        }
        private bool CanExecuteGetInfoSVDCommand(object obj)
        {
            return (SanVanDongItem != null);
        }
        private void ExecuteAddSVDCommand(object obj)
        {
            SanVanDongItem = new SanVanDongModel();
            Log.Info(string.Format("{0} Mo man hinh them san van dong", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED050VM_ThongTinSVD", SanVanDongItem, true);
            ExecuteGetListSVDCommand(null);
        }

        //Trong tai
        private void ExecuteGetInfoTrongTaiCommand(object obj)
        {
            Log.Info(string.Format("{0} Mo man hinh thong tin trong tai", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED070VM_ThongTinTrongTai", TrongTaiItem, false);
            ExecuteGetListTrongTaiCommand(null);
        }
        private bool CanExecuteGetInfoTrongTaiCommand(object obj)
        {
            return (TrongTaiItem != null);
        }
        private void ExecuteAddTrongTaiCommand(object obj)
        {
            TrongTaiItem = new TrongTaiModel();
            Log.Info(string.Format("{0} Mo man hinh them trong tai", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED070VM_ThongTinTrongTai", TrongTaiItem, true);
            ExecuteGetListTrongTaiCommand(null);
        }

        //The Phat
        private void ExecuteGetInfoThePhatCommand(object obj)
        {
            Log.Info(string.Format("{0} Mo man hinh thong tin the phat", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCED060VM_ThongTinThePhat", ThePhatItem,false);
            ExecuteGetListThePhatCommand(null);
        }
        private bool CanExecuteGetInfoThePhatCommand(object obj)
        {
            return (ThePhatItem != null);
        }
        private void ExecuteGetReportBanThangCommand(object obj)
        {
            //su dung report reviewer
            //Xuat report
            Log.Info(string.Format("{0} Xem report ban thang", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCRC021VM_ReportBanThang");
        }
        #endregion
        //Get List
        #region Danh Sach
        private void ExecuteGetListHLVCommand(object obj)
        {
            HuanLuyenVienItems = DanhSach.GetListHuanLuyenVien();
            foreach (HuanLuyenVienModel item in HuanLuyenVienItems)
            {
                var doibong = DoiBongItems.Select(db => new { db.MaDoi, db.TenDoi })
                                            .Where(db1 => db1.MaDoi == item.DoiBong).FirstOrDefault();
                if (doibong != null)
                {
                    item.TenDoi = doibong.TenDoi;
                    item.DoiBong = doibong.MaDoi;
                }
            }
            HuanLuyenVienItem = null;
        }

        private void ExecuteGetListSVDCommand(object obj)
        {
            SanVanDongItems = DanhSach.GetListSanVanDong();
            foreach (SanVanDongModel item in SanVanDongItems)
            {
                var doibong = DoiBongItems.Select(db => new { db.MaDoi, db.TenDoi })
                                            .Where(db1=>db1.MaDoi == item.DoiBongSoHuu).FirstOrDefault();
                if(doibong!=null)
                {
                    item.TenDoi = doibong.TenDoi;
                    item.DoiBongSoHuu = doibong.MaDoi;
                }
            }
            SanVanDongItem = null;
        }

        private void ExecuteGetListTrongTaiCommand(object obj)
        {
            TrongTaiItems = DanhSach.GetListTrongTai();
            TrongTaiItem = null;
        }

        private void ExecuteGetListThePhatCommand(object obj)
        {
            ThePhatItems = DanhSach.GetListThePhat();
            ThePhatItem = null;
        }

        private void ExecuteGetListBanThangCommand(object obj)
        {
            BanThangItems = DanhSach.GetListBanThang();
            BanthangItem = null;
        }
        #endregion

        #endregion

        #region Dao
        ISCRC020 DanhSach { get; set; }
        class Dao
        {
            [Dependency]
            public ISCRC020 DanhSach { get; set; }
        }
        #endregion
    }
}
