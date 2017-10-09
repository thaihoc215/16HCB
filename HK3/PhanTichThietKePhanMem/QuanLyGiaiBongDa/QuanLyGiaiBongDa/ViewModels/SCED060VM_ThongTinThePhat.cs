using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED060VM_ThongTinThePhat : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED060VM_ThongTinThePhat));
        #region Class Variables
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

        CauThuModel _cauThuItem;
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

        KeyValuePair<string, string> _loaiTheItem = new KeyValuePair<string, string>();
        public KeyValuePair<string, string> LoaiTheItem
        {
            get { return _loaiTheItem; }
            set
            {
                _loaiTheItem = value;
                RaisePropertyChanged("CauThuItem");
            }
        }

        Dictionary<string, string> _loaiTheItems = new Dictionary<string, string>();
        public Dictionary<string, string> LoaiTheItems
        {
            get { return _loaiTheItems; }
            set
            {
                _loaiTheItems = value;
                RaisePropertyChanged("LoaiTheItems");
            }
        }


        private bool _isAdd = false;
        public bool IsAdd
        {
            get { return _isAdd; }
            set
            {
                _isAdd = value;
                RaisePropertyChanged("IsAdd");
            }
        }

        string _isAddButton = string.Empty;

        public string IsAddButton
        {
            get { return _isAddButton; }
            set
            {
                _isAddButton = value;
                RaisePropertyChanged("IsAddButton");
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
        public SCED060VM_ThongTinThePhat(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            ThePhatDAO = dao.ThePhatDAO;
            ThePhatItem = (ThePhatModel)Args[0];
            IsAdd = (bool)Args[1];
            CauThuItems = ThePhatDAO.GetDSCauThu();         
            LoaiTheItems = ThePhatDAO.GetDSThePhat();        
            if (IsAdd)
            {
                string doiNha = (string)Args[2];
                string doiKhach = (string)Args[3];
               
                var ctit = CauThuItems.Where(db=>db.DoiBong == doiNha || db.DoiBong == doiKhach).ToList();
                CauThuItems = new ObservableCollection<CauThuModel>();
                foreach (var item in ctit)
                {
                    CauThuItems.Add(item);
                }
                if (CauThuItems.Count > 0)
                    CauThuItem = CauThuItems[0];
                if (LoaiTheItems.Count > 0)
                    LoaiTheItem = LoaiTheItems.FirstOrDefault();
                IsAddButton = "Thêm";
            }
                
            else
            {
                IsAddButton = "Xóa";
                if (CauThuItems.Count > 0)
                    CauThuItem = CauThuItems.Where(ct => ct.MaCauThu == ThePhatItem.CauThu).FirstOrDefault();
                if(LoaiTheItems.Count>0)
                    LoaiTheItem = LoaiTheItems.Where(loai => loai.Key == ThePhatItem.LoaiThe).FirstOrDefault();
            }

            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        private void ExecuteEditThePhatCommand(object obj)
        {
            if (IsAdd)
            {
                if(ThePhatItem.ThoiDiem > 120)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thời điểm thẻ phạt không hợp lệ, phải <= 120");
                    return;
                }
                ThePhatItem.CauThu = CauThuItem.MaCauThu;
                ThePhatItem.LoaiThe = LoaiTheItem.Key;
                Log.Info(string.Format("{0} Them the phat", EmailNguoiDung));
                if (ThePhatDAO.AddThePhat(ThePhatItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thêm thẻ phạt thành công");
                    CloseDialogBox();
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm thẻ phạt không thành công");
            }
            else
            {
                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa thẻ phạt không?")
                    == System.Windows.MessageBoxResult.No)
                    return;
                Log.Info(string.Format("{0} Xoa the phat", EmailNguoiDung));
                if (ThePhatDAO.DeleteThePhat(ThePhatItem.MaThePhat))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa thẻ phạt thành công");
                    CloseDialogBox();
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa thẻ phạt không thành công");
            }
        }

        private bool CanExecuteEditThePhatCommand(object obj)
        {
            if(IsAdd)
                return CauThuItems.Count > 0 && !string.IsNullOrEmpty(LoaiTheItem.Key) && ThePhatItem.ThoiDiem >=0;
            return IsAccept && true;
        }

        private void ExecuteCloseCommand(object obj)
        {
            CloseDialogBox();
        }
        #endregion

        #region Dao
        ISCED060 ThePhatDAO { get; set; }

        

        class Dao
        {
            [Dependency]
            public ISCED060 ThePhatDAO { get; set; }
        }
        #endregion
    }
}
