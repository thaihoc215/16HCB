using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 03/04/2017 - SCED050VM_ThongTinSVD.cs
 */
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED050VM_ThongTinSVD : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED050VM_ThongTinSVD));

        #region Class Variables
        public SanVanDongModel SVDObject
        {
            get { return (SanVanDongModel)Args[0]; }
        }
        bool IsAddSVD
        {
            get { return (bool)Args[1]; }
        }
        SanVanDongModel _svdItem = new SanVanDongModel();
        public SanVanDongModel SvdItem
        {
            get { return _svdItem; }
            set
            {
                _svdItem = value;
                this.RaisePropertyChanged("SvdItem");
            }
        }

        DoiBongModel _DoiBongItem = new DoiBongModel();
        public DoiBongModel DoiBongItem
        {
            get { return _DoiBongItem; }
            set
            {
                _DoiBongItem = value;
                RaisePropertyChanged("DoiBongItem");
            }
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
        string _textIsAdd = "";
        public string TextIsAdd
        {
            get { return _textIsAdd; }
            set
            {
                _textIsAdd = value;
                RaisePropertyChanged("TextIsAdd");
            }
        }
        string _visibleStatus;
        public string VisibleStatus
        {
            get { return _visibleStatus; }
            set { _visibleStatus = value; }
        }

        string _tenSan = string.Empty;
        public string TenSan
        {
            get { return _tenSan; }
            set
            {
                _tenSan = value;
                RaisePropertyChanged("TenSan");
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
        public SCED050VM_ThongTinSVD(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            SanVanDongDAO = dao.SanVanDongDAO;
            SvdItem = SVDObject;
            TenSan = SvdItem.TenSan;
            if (!IsAddSVD)
            {
                DoiBongItems = SanVanDongDAO.GetDanhSachDoiBong();
                DoiBongItem = DoiBongItems.Where(db => db.MaDoi == SvdItem.DoiBongSoHuu).FirstOrDefault();
                VisibleStatus = "Visible";
                TextIsAdd = "Lưu";
            }
            else
            {
                IsControlsEnable = true;
                VisibleStatus = "Hidden";
                TextIsAdd = "Thêm";
                string maSan = SanVanDongDAO.CountSan();
                maSan = maSan.Substring(0, 3) + (Convert.ToInt32(maSan.Substring(3)) + 1).ToString("0000");
                SvdItem.MaSan = maSan;
            }
            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        private void ExecuteEditSVDInfoCommand(object obj)
        {
            IsControlsEnable = true;
        }

        private void ExecuteSaveSVDInfoCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn lưu thông tin không?") == System.Windows.MessageBoxResult.No)
                return;
            SvdItem.TenSan = TenSan;
            if (IsAddSVD)
            {
                Log.Info(string.Format("{0} Them san van dong", EmailNguoiDung));
                if (SanVanDongDAO.AddSanVanDong(SvdItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm sân vận động thành công.");
                    IsControlsEnable = false;
                    CloseDialogBox();
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm sân vận động không thành công.");
            }
            else
            {
                Log.Info(string.Format("{0} Sua thong tin san van dong", EmailNguoiDung));
                if (SanVanDongDAO.UpdateSanVanDong(SvdItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Cập nhật thông tin sân vận động thành công.");
                    IsControlsEnable = false;
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Cập nhật thông tin sân vận động không thành công.");
            }
            
        }
        private bool CanExecuteSaveSVDInfoCommand(object obj)
        {
            return IsControlsEnable && !string.IsNullOrEmpty(TenSan) && TenSan.Length <= 50;
        }

        private void ExecuteDeleteSVDInfoCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa sân vận động này không?") == System.Windows.MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Xoa san van dong", EmailNguoiDung));
            if (SanVanDongDAO.DeleteSanVanDong(SvdItem.MaSan))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa sân vận động thành công.");
                IsControlsEnable = false;
                CloseDialogBox();
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa sân vận động không thành công.");
        }

        #endregion

        #region Dao
        ISCED050 SanVanDongDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCED050 SanVanDongDAO { get; set; }
        }
        #endregion
    }
}
