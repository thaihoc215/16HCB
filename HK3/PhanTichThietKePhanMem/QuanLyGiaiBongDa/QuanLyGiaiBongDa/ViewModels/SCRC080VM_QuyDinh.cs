/*
 * 1642024 - Ung Buu Tri Hung
 * 01/05/2017 5:50 AM - SCRC080VM_QuyDinh
 */
using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC080VM_QuyDinh : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC080VM_QuyDinh));
        #region Class Variables
        QuyDinhModel _QuyDinhItem = new QuyDinhModel();
        public QuyDinhModel QuyDinhItem
        {
            get { return _QuyDinhItem; }
            set
            {
                _QuyDinhItem = value;
                RaisePropertyChanged("QuyDinhItem");
            }
        }

        LoaiBanThangModel _loaiBanThangItem = new LoaiBanThangModel();
        public LoaiBanThangModel LoaiBanThangItem
        {
            get
            {
                return _loaiBanThangItem;
            }

            set
            {
                _loaiBanThangItem = value;
                RaisePropertyChanged("LoaiBanThangItem");
            }
        }

        ObservableCollection<LoaiBanThangModel> _LoaiBanThangItems;
        public ObservableCollection<LoaiBanThangModel> LoaiBanThangItems
        {
            get { return _LoaiBanThangItems; }
            set
            {
                _LoaiBanThangItems = value;
                RaisePropertyChanged("LoaiBanThangItems");
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

        bool _isAddLoaiBT = false;
        public bool IsAddLoaiBT
        {
            get
            {
                return _isAddLoaiBT;
            }

            set
            {
                _isAddLoaiBT = value;
                RaisePropertyChanged("IsAddLoaiBT");
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
        public SCRC080VM_QuyDinh(params object[] args)
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
            QuyDinhDAO = dao.QuyDinhDAO;
            UserLogin = Constants.UserUsing;
            ExecuteLoadQuyDinhCommand(null);
            ExecuteLoadLoaiBanThangCommand(null);
            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
        }
        #endregion

        #region Command

        //Load quy định
        private void ExecuteLoadQuyDinhCommand(object obj)
        {
            QuyDinhItem = QuyDinhDAO.LoadQuyDinh();
        }

        //Load loại bàn thắng
        private void ExecuteLoadLoaiBanThangCommand(object obj)
        {
            Log.Info(string.Format("{0} Load danh sach quy dinh", EmailNguoiDung));
            LoaiBanThangItems = QuyDinhDAO.LoadLoaiBanThang();
            if (LoaiBanThangItems.Count > 0)
            {
                LoaiBanThangItem = LoaiBanThangItems[0];
            }
            
        }
        #region Loai Ban Thang
        /*
         * 
         */
        private void ExecuteAddLoaiBTCommand(object obj)
        {
            string maLoai = QuyDinhDAO.CountMaxLoaiBT();
            maLoai = maLoai.Substring(0, 3) + (Convert.ToInt32(maLoai.Substring(3)) + 1).ToString("0000");
            LoaiBanThangItem = new LoaiBanThangModel(maLoai);
            IsAddLoaiBT = true;
        }

        /*
         * 
         */
        private void ExecuteDeleteLoaiBTCommand(object obj)
        {
            //Xu ly xoa loai ban thang
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation,
                "Bạn có chắc chắn muốn xóa loại bàn thắng này không?") == System.Windows.MessageBoxResult.No)
                return;
            if (QuyDinhDAO.DeleteLoaiBanThang(LoaiBanThangItem))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa loại bàn thắng thành công");
                IsAddLoaiBT = false;
            }
            else
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa loại bàn thắng không thành công");
                return;
            }
            ExecuteLoadLoaiBanThangCommand(null);
        }

        private bool CanExecuteDeleteLoaiBTCommand(object obj)
        {
            return IsAccept && LoaiBanThangItems.Count > 0 && LoaiBanThangItem != null && !IsAddLoaiBT;
        }

        /*
         * 
         */
        private void ExecuteUpdateLoaiBTCommand(object obj)
        {
            if (IsAddLoaiBT)
            {
                Log.Info(string.Format("{0} Them loai ban thang", EmailNguoiDung));
                if (QuyDinhDAO.AddLoaiBanThang(LoaiBanThangItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm loại bàn thắng thành công");
                    IsAddLoaiBT = false;
                }
                else
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm loại bàn thắng không thành công");
                    return;
                }
            }
            else
            {
                Log.Info(string.Format("{0} Chinh sua thong tin loai ban thang", EmailNguoiDung));
                if (QuyDinhDAO.UpdateLoaiBanThang(LoaiBanThangItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Update loại bàn thắng thành công");
                }
                else
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Update loại bàn thắng không thành công");
                    return;
                }
            }
            ExecuteLoadLoaiBanThangCommand(null);
        }
        private bool CanExecuteUpdateLoaiBTCommand(object obj)
        {
            return IsAccept && LoaiBanThangItems.Count > 0 && !string.IsNullOrEmpty(LoaiBanThangItem.TenLoai);
        }
        /*
         * 
         */
        private void ExecuteCancelUpdateLoaiBTCommand(object obj)
        {
            ExecuteLoadLoaiBanThangCommand(null);
            IsAddLoaiBT = false;
        }
        #endregion

        #region Quy dinh 1
        //Update quy dinh 1
        bool _openUpdateQD1 = false;
        public bool OpenUpdateQD1
        {
            get { return _openUpdateQD1; }
            set
            {
                _openUpdateQD1 = value;
                RaisePropertyChanged("OpenUpdateQD1");
            }
        }

        string _UpdateQD1 = "Sửa";
        public string UpdateQD1
        {
            get
            {
                return _UpdateQD1;
            }

            set
            {
                _UpdateQD1 = value;
                RaisePropertyChanged("UpdateQD1");
            }
        }
        private void ExecuteUpdateQuyDinh1Command(object obj)
        {
            if(UpdateQD1 == "Sửa")
            {
                UpdateQD1 = "Lưu";
                OpenUpdateQD1 = true;
            }
            else
            {
                if (QuyDinhItem.TuoiMax <= QuyDinhItem.TuoiMin)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                            "Tuổi Max > Tuổi Min");
                    return;
                }

                if (QuyDinhItem.SoLuongMax <= QuyDinhItem.SoLuongMin)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                            "Số lượng cầu thủ tối đa > Số lượng cầu thủ tối thiểu");
                    return;
                }
                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, 
                    "Bạn chắc chắn muốn thay đổi quy định này??")
                    == System.Windows.MessageBoxResult.No)
                    return;
                Log.Info(string.Format("{0} Update quy dinh 1", EmailNguoiDung));
                if (QuyDinhDAO.UpdateQD1(QuyDinhItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                        "Thay đổi quy định 1 thành công");
                    UpdateQD1 = "Sửa";
                    OpenUpdateQD1 = false;
                }
                else
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, 
                        "Thay đổi quy định 1 không thành công");
                }
            }

        }
        private void ExecuteCancelUpdateQuyDinh1Command(object obj)
        {
            UpdateQD1 = "Sửa";
            OpenUpdateQD1 = false;
            ExecuteLoadQuyDinhCommand(null);
        }
        private bool CanExecuteCancelUpdateQuyDinh1Command(object obj)
        {
            return IsAccept && UpdateQD1 == "Lưu";
        }
        #endregion

        #region Quy dinh 3
        bool _openUpdateQD3 = false;
        public bool OpenUpdateQD3
        {
            get { return _openUpdateQD3; }
            set
            {
                _openUpdateQD3 = value;
                RaisePropertyChanged("OpenUpdateQD3");
            }
        }

        string _UpdateQD3 = "Sửa";
        public string UpdateQD3
        {
            get
            {
                return _UpdateQD3;
            }

            set
            {
                _UpdateQD3 = value;
                RaisePropertyChanged("UpdateQD3");
            }
        }
        private void ExecuteUpdateQuyDinh3Command(object obj)
        {
            if (UpdateQD3 == "Sửa")
            {
                UpdateQD3 = "Lưu";
                OpenUpdateQD3 = true;
            }
            else
            {
                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, 
                    "Bạn chắc chắn muốn thay đổi quy định này??")
                    == System.Windows.MessageBoxResult.No)
                    return;
                Log.Info(string.Format("{0} Update quy dinh 3", EmailNguoiDung));
                if (QuyDinhDAO.UpdateQD3(QuyDinhItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                        "Thay đổi quy định 3 thành công");
                    UpdateQD3 = "Sửa";
                    OpenUpdateQD3 = false;
                }
                else
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                        "Thay đổi quy định 3 không thành công");
                }
            }

        }
        private void ExecuteCancelUpdateQuyDinh3Command(object obj)
        {
            UpdateQD3 = "Sửa";
            OpenUpdateQD3 = false;
            ExecuteLoadQuyDinhCommand(null);
        }
        private bool CanExecuteCancelUpdateQuyDinh3Command(object obj)
        {
            return IsAccept && UpdateQD3 == "Lưu";
        }
        #endregion

        #region Quy dinh 4
        bool _openUpdateQD4 = false;
        public bool OpenUpdateQD4
        {
            get { return _openUpdateQD4; }
            set
            {
                _openUpdateQD4 = value;
                RaisePropertyChanged("OpenUpdateQD4");
            }
        }

        string _UpdateQD4 = "Sửa";
        public string UpdateQD4
        {
            get
            {
                return _UpdateQD4;
            }

            set
            {
                _UpdateQD4 = value;
                RaisePropertyChanged("UpdateQD4");
            }
        }
        private void ExecuteUpdateQuyDinh4Command(object obj)
        {
            if (UpdateQD4 == "Sửa")
            {
                UpdateQD4 = "Lưu";
                OpenUpdateQD4 = true;
            }
            else
            {
                if (QuyDinhItem.Thang <= QuyDinhItem.Hoa || QuyDinhItem.Hoa <= QuyDinhItem.Thua)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                            "Điểm Thắng > Hòa > Thua");
                    return;
                }
                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation,
                    "Bạn chắc chắn muốn thay đổi quy định này??")
                    == System.Windows.MessageBoxResult.No)
                    return;
                Log.Info(string.Format("{0} Update quy dinh 4", EmailNguoiDung));
                if (QuyDinhDAO.UpdateQD4(QuyDinhItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                        "Thay đổi quy định 4 thành công");
                    UpdateQD4 = "Sửa";
                    OpenUpdateQD4 = false;
                }
                else
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                        "Thay đổi quy định 4 không thành công");
                }
            }

        }
        private void ExecuteCancelUpdateQuyDinh4Command(object obj)
        {
            UpdateQD4 = "Sửa";
            OpenUpdateQD4 = false;
            ExecuteLoadQuyDinhCommand(null);
        }
        private bool CanExecuteCancelUpdateQuyDinh4Command(object obj)
        {
            return IsAccept && UpdateQD4 == "Lưu";
        }
        #endregion

        private void ExecuteLogoutCommand(object obj)
        {
            ViewForwarder.ForwardModeless("SCLG010VM_Login");

            Constants.UserUsing = new NguoiDungModel();
            CloseAction();
        }
        public Action CloseAction { get; set; }
        #endregion

        #region Dao
        ISCRC080 QuyDinhDAO { get; set; }

        class Dao
        {
            [Dependency]
            public ISCRC080 QuyDinhDAO { get; set; }
        }
        #endregion
    }
}
