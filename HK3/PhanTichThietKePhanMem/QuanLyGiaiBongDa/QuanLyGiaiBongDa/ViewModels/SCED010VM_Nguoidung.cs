/*
 * 1642024 - Ung Buu Tri Hung
 * 27/03/2017 3:00 PM - SCED010VM_Nguoidung
 */
using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED010VM_Nguoidung : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED010VM_Nguoidung));
        #region Class Variables
        NguoiDungModel _nguoiDungItem = new NguoiDungModel();

        public NguoiDungModel NguoiDungItem
        {
            get { return _nguoiDungItem; }
            set
            {
                _nguoiDungItem = value;
                RaisePropertyChanged("NguoiDungItem");
            }
        }

        ObservableCollection<NguoiDungModel> _nguoiDungItems = new ObservableCollection<NguoiDungModel>();
        public ObservableCollection<NguoiDungModel> NguoiDungItems
        {
            get { return _nguoiDungItems; }
            set
            {
                _nguoiDungItems = value;
                RaisePropertyChanged("NguoiDungItems");
            }
        }

        LoaiNVModel _loaiNVItem = new LoaiNVModel();
        public LoaiNVModel LoaiNVItem
        {
            get { return _loaiNVItem; }
            set
            {
                _loaiNVItem = value;
                RaisePropertyChanged("LoaiNVItem");
            }
        }
        ObservableCollection<LoaiNVModel> _loaiNVItems = new ObservableCollection<LoaiNVModel>();
        public ObservableCollection<LoaiNVModel> LoaiNVItems
        {
            get { return _loaiNVItems; }
            set
            {
                _loaiNVItems = value;
                RaisePropertyChanged("LoaiNVItems");
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

        string _hoTenNguoiDung = string.Empty;
        public string HoTenNguoiDung
        {
            get { return _hoTenNguoiDung; }
            set
            {
                _hoTenNguoiDung = value;
                this.RaisePropertyChanged("HoTenNguoiDung");
            }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                this.RaisePropertyChanged("Email");
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
        #endregion

        #region Constructor
        public SCED010VM_Nguoidung(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            NguoiDungDAO = dao.NguoiDungDAO;
            UserLogin = Constants.UserUsing;
            ExecuteGetListLoaiNVCommand(null);
            ExecuteGetListNguoiDungCommand(null);
        }
        #endregion

        #region Command

        /*
         * Lay danh sach nguoi dung
         */
        private void ExecuteGetListNguoiDungCommand(object obj)
        {
            Log.Info(string.Format("{0} Lay danh sach nguoi dung", UserLogin.Email));
            NguoiDungItems = NguoiDungDAO.GetListNguoiDung();
            if (NguoiDungItems.Count > 0)
            {
                NguoiDungItem = NguoiDungItems[0];
                HoTenNguoiDung = NguoiDungItem.HoTen;
                Email = NguoiDungItem.Email;
                LoaiNVItem = LoaiNVItems.Where(lnv => lnv.MaLoai == NguoiDungItem.LoaiNV).FirstOrDefault();
            }

        }

        /*
         * Lay danh sach nhan vien
         */
        private void ExecuteGetListLoaiNVCommand(object obj)
        {
            Log.Info(string.Format("{0} Lay danh sach loai nhan vien", UserLogin.Email));
            LoaiNVItems = NguoiDungDAO.GetListLoaiNV();
            if (LoaiNVItems.Count > 0)
            {
                LoaiNVItem = LoaiNVItems[0];
            }

        }

        private bool _isAddUser = false;
        public bool IsAddUser
        {
            get { return _isAddUser; }
            set
            {
                _isAddUser = value;
                RaisePropertyChanged("IsAddUser");
            }
        }
        /*
         * Open control de them - sua nguoi dung
         */
        private void ExecuteOpenAddNguoiDungCommand(object obj)
        {
            IsAddUser = Int32.Parse(obj.ToString()) == 0 ? true : false;//true: them nguoi dung - false: sua thong tin nguoi dung
            IsControlsEnable = true;
            if (IsAddUser) // Them nguoi dung
            {
                int maNV = NguoiDungDAO.CountNV() + 1;
                NguoiDungItem = new NguoiDungModel(maNV);
                HoTenNguoiDung = string.Empty;
                Email = string.Empty;
                
            }
        }

        private bool CanExecuteOpenAddNguoiDungCommand(object obj)
        {
            return UserLogin.LoaiNV < 3;
        }
        /*
         * Thay doi thong tin - Them nguoi dung
         */
        private void ExecuteUpdateNguoiDungCommand(object obj)
        {
           
            if (GioiTinhNam == true)
                NguoiDungItem.GioiTinh = "Nam";
            else NguoiDungItem.GioiTinh = "Nữ";
            NguoiDungItem.LoaiNV = LoaiNVItem.MaLoai;
            NguoiDungItem.HoTen = HoTenNguoiDung;
            NguoiDungItem.Email = Email;
            DateTime _ns;
            if (!DateTime.TryParse(NguoiDungItem.NgaySinh.ToString(), out _ns))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Vui lòng nhập đúng ngày sinh");
                return;
            }
            if (IsAddUser) // Them nguoi dung
            {
                if (UserLogin.LoaiNV == 2 && LoaiNVItem.MaLoai<=2)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Không thể thêm người dùng cùng cấp hoặc cao hơn");
                    return;

                }
                var lstEmail = NguoiDungItems.Select(nd=>nd.Email.Trim()).ToList();
                if (lstEmail.Contains(NguoiDungItem.Email.Trim()))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Email đăng nhập đã có trong hệ thống");
                    return;
                }
                NguoiDungItem.Pass = NguoiDungItem.NgaySinh.ToString("yyyyMMdd");
                Log.Info(string.Format("{0} Them nguoi dung", UserLogin.Email));
                if (NguoiDungDAO.CapTaiKhoan(NguoiDungItem))
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm người dùng thành công");
                else
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm người dùng thất bại");
                }
                ExecuteGetListNguoiDungCommand(null);
                IsAddUser = false;
            }
            else //Sua thong tin nguoi dung
            {
                if (UserLogin.LoaiNV == 2 && loaiNguoiDungBefore < 2)
                {
                        MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Không thể sửa thông tin người dùng cấp cao hơn");
                        return;
                }
                if(UserLogin.LoaiNV == loaiNguoiDungBefore)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Không thể sửa loại người dùng cùng cấp");
                    return;
                }
                //if (NguoiDungItems.Count <= 0 || NguoiDungItem == null)
                //{
                //    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Vui lòng chọn người dùng");
                //    return;
                //}

                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn chắc chắn muốn thay đổi thông tin??")
                    == System.Windows.MessageBoxResult.No)
                    return;
                Log.Info(string.Format("{0} Thay doi thong tin nguoi dung", UserLogin.Email));
                if (NguoiDungDAO.SuaTaiKhoan(NguoiDungItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Sửa người dùng thành công");
                    ExecuteGetListNguoiDungCommand(null);
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Sửa người dùng thất bại");
            }
            IsControlsEnable = false;

        }
        private bool CanExecuteUpdateNguoiDungCommand(object obj)
        {
            Regex regex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$");
            if (!regex.IsMatch(Email))
                return false;

            return IsControlsEnable && NguoiDungItem != null && !string.IsNullOrEmpty(HoTenNguoiDung) && HoTenNguoiDung.Length <= 50
                && Email.Length <= 20 && !string.IsNullOrEmpty(Email) && LoaiNVItem != null;
        }
        /*
         * Xoa nguoi dung
         */
        private void ExecuteDeleteNguoiDungCommand(object obj)
        {
            

            //Kiem tra nguoi dung dang dung va nguoi dung muon xoa
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn muốn xóa người dùng?")
                == System.Windows.MessageBoxResult.No)
                return;
            if (UserLogin.MaNV == NguoiDungItem.MaNV)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Không thể xóa người dùng đang sử dụng");
                return;

            }
            if (UserLogin.LoaiNV == 2 && loaiNguoiDungBefore <= 2)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Không thể xóa người dùng cùng cấp hoặc cao hơn");
                return;

            }
            Log.Info(string.Format("{0} Xoa thong tin nguoi dung", UserLogin.Email));
            if (NguoiDungDAO.XoaTaiKhoan(NguoiDungItem.MaNV))
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa người dùng thành công");
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa người dùng thất bại");
            ExecuteGetListNguoiDungCommand(null);
        }
        private bool CanExecuteDeleteNguoiDungCommand(object obj)
        {
            return UserLogin.LoaiNV < 3 && !IsAddUser && NguoiDungItems.Count > 0 && NguoiDungItem != null;
        }

        /*
         * Thay doi nguoi dung duoc chon
         */
        public int loaiNguoiDungBefore { get; set; }
        private void ExecuteNguoiDungChangeCommand(object obj)
        {
            if (NguoiDungItem != null)
            {
                if (NguoiDungItem.GioiTinh == "Nam")
                {
                    GioiTinhNam = true;
                    GioiTinhNu = false;
                }

                else
                {
                    GioiTinhNam = false;
                    GioiTinhNu = true;
                }
                LoaiNVItem = LoaiNVItems.Where(lnv => lnv.MaLoai == NguoiDungItem.LoaiNV).FirstOrDefault();
                HoTenNguoiDung = NguoiDungItem.HoTen;
                Email = NguoiDungItem.Email;
                loaiNguoiDungBefore = LoaiNVItem.MaLoai;
            }

        }

        private void ExecuteCancelUpdateNguoiDungCommand(object obj)
        {
            Log.Info(string.Format("{0} Huy thay doi thong tin", UserLogin.Email));
            IsControlsEnable = false;
            ExecuteGetListNguoiDungCommand(null);
            if (NguoiDungItems.Count > 0)
            {
                NguoiDungItem = NguoiDungItems[0];
                HoTenNguoiDung = NguoiDungItem.HoTen;
                Email = NguoiDungItem.Email;
            }
            IsAddUser = false;
        }

        private void ExecuteLogoutCommand(object obj)
        {
            Log.Info(string.Format("{0} Logout", UserLogin.Email));
            ViewForwarder.ForwardModeless("SCLG010VM_Login");

            Constants.UserUsing = new NguoiDungModel();
            CloseAction();
        }
        public Action CloseAction { get; set; }
        #endregion

        #region Dao
        ISCED010 NguoiDungDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCED010 NguoiDungDAO { get; set; }
        }
        #endregion
    }
}
