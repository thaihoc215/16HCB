using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 10/04/2017 - SCRC050VM_LichThiDau.cs
 */
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC050VM_LichThiDau : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC050VM_LichThiDau));
        #region Class Variables

        TranDauModel _tranDauItem = new TranDauModel();
        public TranDauModel TranDauItem
        {
            get { return _tranDauItem; }
            set
            {
                _tranDauItem = value;
                RaisePropertyChanged("TranDauItem");
            }
        }

        ObservableCollection<TranDauModel> _tranDauItems = new ObservableCollection<TranDauModel>();
        public ObservableCollection<TranDauModel> TranDauItems
        {
            get { return _tranDauItems; }
            set
            {
                _tranDauItems = value;
                RaisePropertyChanged("TranDauItems");
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

        TrongTaiModel _trongTaiItem = new TrongTaiModel();
        public TrongTaiModel TrongTaiItem
        {
            get { return _trongTaiItem; }
            set
            {
                _trongTaiItem = value;
                RaisePropertyChanged("TrongTaiItem");
            }
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
        DateTime _NgayTaoLich = DateTime.Now;
        public DateTime NgayTaoLich
        {
            get
            {
                return _NgayTaoLich;
            }

            set
            {
                _NgayTaoLich = value;
                RaisePropertyChanged("NgayTaoLich");
            }
        }
        #endregion

        #region Constructor
        public SCRC050VM_LichThiDau(params object[] args)
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
            LichDauDAO = dao.LichDauDAO;
            TranDauItems = LichDauDAO.GetLichThiDau();
            TranDauItem = null;
            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
        }
        #endregion

        #region Command

        private void ExecuteTaoLichDauCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation,
                "Bạn có chắc chắn muốn tạo lịch thi đấu?" + Environment.NewLine +
                "Mọi kết quả giải đấu sẽ được reset?") == System.Windows.MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Tao lich dau", EmailNguoiDung));
            if (LichDauDAO.TaoLichThiDau(NgayTaoLich))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, 
                    "Tạo lịch đấu thành công");
                TranDauItems = LichDauDAO.GetLichThiDau();
                TranDauItem = null;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                    "Tạo lịch đấu không thành công");
            IsControlsEnable = false;
            
        }

        private void ExecuteEditTranDauCommand(object obj)
        {
            IsControlsEnable = true;
        }
        private bool CanExecuteEditTranDauCommand(object obj)
        {
            return IsAccept && TranDauItems.Count > 0 && TranDauItem != null;
        }

        private void ExecuteKetQuaTranDauCommand(object obj)
        {
            IsControlsEnable = false;
            Log.Info(string.Format("{0} Xem ket qua tran dau", EmailNguoiDung));
            ViewForwarder.ForwardModal("SCRC051VM_KetQuaTranDau",TranDauItem);
        }
        private bool CanExecuteKetQuaTranDauCommand(object obj)
        {
            return TranDauItems.Count > 0 && TranDauItem != null;
        }

        private void ExecuteSelectTranDauCommand(object obj)
        {
            if (TranDauItem != null)
            {
                TrongTaiItems = LichDauDAO.GetLstTrongTai(TranDauItem);
                TrongTaiItem = TrongTaiItems.Where(tt => tt.MaTrongTai == TranDauItem.TrongTai).FirstOrDefault();
            }
            IsControlsEnable = false;
        }

        private void ExecuteSaveTranDauCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn lưu thông tin không?") == System.Windows.MessageBoxResult.No)
                return;
            TimeSpan _gio;
            if (!TimeSpan.TryParseExact(TranDauItem.Gio, @"hh\:mm\:ss", 
                System.Globalization.CultureInfo.CurrentCulture, out _gio))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors,
                    "Giờ nhập không hợp lệ");
                return;
            }
                TranDauItem.TrongTai = TrongTaiItem.MaTrongTai;
            TranDauItem.TenTrongTai = TrongTaiItem.TenTrongTai;
            Log.Info(string.Format("{0} Thay doi thong tin tran dau", EmailNguoiDung));
            if (LichDauDAO.UpdateTranDau(TranDauItem))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thay đổi thông tin trận đấu thành công.");
                TranDauItems = LichDauDAO.GetLichThiDau();
                TranDauItem = null;
                TrongTaiItem = null;
                IsControlsEnable = false;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thay đổi thông tin trận đấu không thành công.");
        }
        private bool CanExecuteSaveTranDauCommand(object obj)
        {
            return IsControlsEnable;
        }

        private void ExecuteCancelEditTrandauCommand(object obj)
        {
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Thông tin chưa được lưu. Bạn chắc chắn muốn dừng lại?")
                == System.Windows.MessageBoxResult.No)
                return;
            TranDauItems = LichDauDAO.GetLichThiDau();
            //TranDauItem = TranDauItems.Where(td => td.MaTranDau == TranDauItem.MaTranDau).FirstOrDefault();
            IsControlsEnable = false;
        }
        private bool CanExecuteCancelEditTrandauCommand(object obj)
        {
            return IsControlsEnable;
        }
        #endregion

        #region Dao
        ISCRC050 LichDauDAO { get; set; }

        class Dao
        {
            [Dependency]
            public ISCRC050 LichDauDAO { get; set; }
        }
        #endregion
    }
}
