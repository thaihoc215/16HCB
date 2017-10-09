using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 03/04/2017 - SCED070VM_ThongTinTrongTai.cs
 */
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED070VM_ThongTinTrongTai : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED070VM_ThongTinTrongTai));

        #region Class Variables
        public TrongTaiModel TrongTaiObject
        {
            get { return (TrongTaiModel)Args[0]; }
        }

        bool IsAddTrongTai
        {
            get { return (bool)Args[1]; }
        }

        TrongTaiModel _trongTaiItem = new TrongTaiModel();
        public TrongTaiModel TrongTaiItem
        {
            get { return _trongTaiItem; }
            set
            {
                _trongTaiItem = value;
                this.RaisePropertyChanged("TrongTaiItem");
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

        BangCapModel _bangCapItem = new BangCapModel();
        public BangCapModel BangCapItem
        {
            get { return _bangCapItem; }
            set
            {
                _bangCapItem = value;
                RaisePropertyChanged("BangCapItem");
            }
        }

        ObservableCollection<BangCapModel> _bangCapItems = new ObservableCollection<BangCapModel>();
        public ObservableCollection<BangCapModel> BangCapItems
        {
            get { return _bangCapItems; }
            set
            {
                _bangCapItems = value;
                RaisePropertyChanged("BangCapItems");
            }
        }

        string _tenTrongTai = string.Empty;
        public string TenTrongTai
        {
            get { return _tenTrongTai; }
            set
            {
                _tenTrongTai = value;
                RaisePropertyChanged("TenTrongTai");
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
        public SCED070VM_ThongTinTrongTai(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            TrongTaiDAO = dao.TrongTaiDAO;
            TrongTaiItem = TrongTaiObject;
            TenTrongTai = TrongTaiItem.TenTrongTai;
            BangCapItems = TrongTaiDAO.GetListBangCap();
            if (!IsAddTrongTai)
            {    
                BangCapItem = BangCapItems.Where(bc => bc.MaBC == TrongTaiItem.BangCap).FirstOrDefault();
                if (TrongTaiItem.GioiTinh == "Nam")
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
                TextIsAdd = "Lưu";
            }
            else
            {
                BangCapItem = BangCapItems[0];
                string maTrongTai = TrongTaiDAO.CountTrongTai();
                TrongTaiItem.MaTrongTai = maTrongTai.Substring(0, 2) + 
                    (Convert.ToInt32(maTrongTai.Substring(2)) + 1).ToString("00000");
                IsControlsEnable = true;
                VisibleStatus = "Hidden";
                TextIsAdd = "Thêm";
            }

            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        private void ExecuteEditTrongTaiInfoCommand(object obj)
        {
            IsControlsEnable = true;
        }

        private void ExecuteSaveTrongTaiInfoCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn thay đổi thông tin không?") == System.Windows.MessageBoxResult.No)
                return;
            if (GioiTinhNam)
                TrongTaiItem.GioiTinh = "Nam";
            else TrongTaiItem.GioiTinh = "Nu";
            TrongTaiItem.TenTrongTai = TenTrongTai;
            if (IsAddTrongTai)
            {
                Log.Info(string.Format("{0} Them trong tai", EmailNguoiDung));
                TrongTaiItem.BangCap = BangCapItem.MaBC;
                if (TrongTaiDAO.AddTrongTai(TrongTaiItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm trọng tài thành công.");
                    IsControlsEnable = false;
                    CloseDialogBox();
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm trọng tài không thành công.");

            }
            else
            {
                Log.Info(string.Format("{0} Sua thong tin trong tai", EmailNguoiDung));
                TrongTaiItem.BangCap = BangCapItem.MaBC;
                if (TrongTaiDAO.UpdateTrongTai(TrongTaiItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Cập nhật thông tin trọng tài thành công.");
                    IsControlsEnable = false;
                    CloseDialogBox();
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Cập nhật thông tin trọng tài không thành công.");
            }
            
        }
        private bool CanExecuteSaveTrongTaiInfoCommand(object obj)
        {
            return IsControlsEnable && !string.IsNullOrEmpty(TenTrongTai) && TenTrongTai.Length <= 50;
        }

        private void ExecuteDeleteTrongTaiInfoCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa trọng tài này không?") == System.Windows.MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Xoa trong tai", EmailNguoiDung));
            if (TrongTaiDAO.DeleteTrongTai(TrongTaiItem.MaTrongTai))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa trọng tài thành công.");
                IsControlsEnable = false;
                CloseDialogBox();
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa trọng tài không thành công.");
        }
        #endregion

        #region Dao
        ISCED070 TrongTaiDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCED070 TrongTaiDAO { get; set; }
        }
        #endregion

    }
}
