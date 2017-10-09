using log4net;
using Microsoft.Practices.Unity;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 31/03/2017 - SCED040VM_ThongTinHLV.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED040VM_ThongTinHLV : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED040VM_ThongTinHLV));

        #region Class Variables
        public HuanLuyenVienModel HLVObject
        {
            get { return (HuanLuyenVienModel)Args[0]; }
        }
        bool IsAddHLV
        {
            get { return (bool)Args[1]; }
        }
        HuanLuyenVienModel _hlvItem = new HuanLuyenVienModel();
        public HuanLuyenVienModel HlvItem
        {
            get { return _hlvItem; }
            set
            {
                _hlvItem = value;
                this.RaisePropertyChanged("HlvItem");
            }
        }

        bool _gioiTinhNam = true;
        public bool GioiTinhNam
        {
            get { return _gioiTinhNam; }
            set
            {
                _gioiTinhNam = value;
                this.RaisePropertyChanged("GioiTinhNam");
            }
        }
        bool _gioiTinhNu = false;
        public bool GioiTinhNu
        {
            get { return _gioiTinhNu; }
            set
            {
                _gioiTinhNu = value;
                this.RaisePropertyChanged("GioiTinhNu");
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

        string _visibleStatus;
        public string VisibleStatus
        {
            get { return _visibleStatus; }
            set { _visibleStatus = value; }
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
        //text cho nút Lưu/Thêm
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
        #endregion

        private string EmailNguoiDung = string.Empty;
        #region Constructor
        public SCED040VM_ThongTinHLV(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            HuanLuyenVienDAO = dao.HuanLuyenVienDAO;
            HlvItem = HLVObject;
            TenHLV = HlvItem.TenHLV;
            if (!IsAddHLV)
            {

                if (HlvItem.GioiTinh == "Nam")
                {
                    GioiTinhNam = true;
                    GioiTinhNu = false;
                }

                else
                {
                    GioiTinhNam = false;
                    GioiTinhNu = true;
                }

                VisibleStatus = "Visible";
                DoiBongItems = HuanLuyenVienDAO.GetDanhSachDoiBong();
                DoiBongItem = DoiBongItems.Where(db => db.MaDoi == HlvItem.DoiBong).FirstOrDefault();
                TextIsAdd = "Lưu";
            }
            else
            {
                IsControlsEnable = true;
                HlvItem = new HuanLuyenVienModel();
                VisibleStatus = "Hidden";
                TextIsAdd = "Thêm";
                string maHLV = HuanLuyenVienDAO.CountHLV();
                maHLV = maHLV.Substring(0, 1) + (Convert.ToInt32(maHLV.Substring(1)) + 1).ToString("000000");
                HlvItem.MaHLV = maHLV;
            }
            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        private void ExecuteEditHLVInfoCommand(object obj)
        {
            IsControlsEnable = true;
        }
        string _tenHLV = string.Empty;
        public string TenHLV
        {
            get
            {
                return _tenHLV;
            }

            set
            {
                _tenHLV = value;
                RaisePropertyChanged("TenHLV");
            }
        }
        private void ExecuteSaveHLVInfoCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn lưu thông tin không?") == MessageBoxResult.No)
                return;
            if (GioiTinhNam == true)
                HlvItem.GioiTinh = "Nam";
            else HlvItem.GioiTinh = "Nu";
            HlvItem.TenHLV = TenHLV;
            if (IsAddHLV)
            {
                Log.Info(string.Format("{0} Them huan luyen vien", EmailNguoiDung));
                if (HuanLuyenVienDAO.AddHLV(HlvItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm huấn luyện viên thành công.");
                    IsControlsEnable = false;
                    CloseDialogBox();
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm huấn luyện viên không thành công.");
            }
            else
            {
                Log.Info(string.Format("{0} thay doi thong tin huan luyen vien", EmailNguoiDung));
                if (HuanLuyenVienDAO.UpdateHuanLuyenVien(HlvItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Cập nhật thông tin huấn luyện viên thành công.");
                    IsControlsEnable = false;
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Cập nhật thông tin huấn luyện viên không thành công.");
            }


        }

        private bool CanExecuteSaveHLVInfoCommand(object obj)
        {

            return IsControlsEnable && !string.IsNullOrEmpty(TenHLV) && TenHLV.Length <= 50;
        }
        private void ExecuteFindHLVInfoCommand(object obj)
        {
            if (HuanLuyenVienDAO.FindHuanLuyenVien(HlvItem.MaHLV))
            {
                IsControlsEnable = false;
                CloseDialogBox();
            }
        }
        private void ExecuteDeleteHLVInfoCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa huấn luyện viên này không?") == MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Xoa huan luyen vien", EmailNguoiDung));
            if (HuanLuyenVienDAO.DeleteHuanLuyenVien(HlvItem.MaHLV))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa huấn luyện viên thành công.");
                IsControlsEnable = false;
                CloseDialogBox();
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa huấn luyện viên không thành công.");
        }
        #endregion

        #region Dao
        ISCED040 HuanLuyenVienDAO { get; set; }

        class Dao
        {
            [Dependency]
            public ISCED040 HuanLuyenVienDAO { get; set; }
        }
        #endregion
    }
}
