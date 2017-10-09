using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCLG011VM_DoiMatKhau : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCLG011VM_DoiMatKhau));
        #region Class Variables
        string _email = "";
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        string _passWord = "";
        public string PassWord
        {
            get { return _passWord; }
            set
            {
                _passWord = value;
                RaisePropertyChanged("PassWord");
            }
        }
        string _newPass = string.Empty;
        public string NewPass
        {
            get
            {
                return _newPass;
            }

            set
            {
                _newPass = value;
                RaisePropertyChanged("NewPass");
            }
        }

        string _checkNewPass = string.Empty;
        public string CheckNewPass
        {
            get
            {
                return _checkNewPass;
            }

            set
            {
                _checkNewPass = value;
                RaisePropertyChanged("CheckNewPass");
            }
        }


        NguoiDungModel _userLogin = new NguoiDungModel();
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
        public SCLG011VM_DoiMatKhau(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            DoiMatKhauDAO = dao.DoiMatKhauDAO;
            Login = dao.Login;
        }
        #endregion

        #region Command
        void ExecuteSaveCommand(object obj)
        {

            UserLogin = Login.GetUser(Email, PassWord);
            if (UserLogin == null)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Tài khoản hoặc mật khẩu không đúng");
                return;
            }
            if(CheckNewPass!=NewPass)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Mật khẩu nhập lại không đúng");
                return;
            }
            UserLogin.Pass = NewPass;
            Log.Info(string.Format("{0} Doi mat khau", UserLogin.Email));
            if (DoiMatKhauDAO.DoiMatKhau(UserLogin))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thay đổi mật khẩu người dùng thành công");
                CloseDialogBox();
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thay đổi mật khẩu người dùng không thành công");
        }

        bool CanExecuteSaveCommand(object obj)
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(PassWord) && !string.IsNullOrEmpty(NewPass)
                && !string.IsNullOrEmpty(CheckNewPass);
        }

        void ExecuteCancelCommand(object obj)
        {
            Log.Info("Close window");
            CloseDialogBox();
        }
        #endregion

        #region Dao
        ISCLG011 DoiMatKhauDAO { get; set; }
        ISCLG010 Login { get; set; }

        class Dao
        {
            [Dependency]
            public ISCLG011 DoiMatKhauDAO { get; set; }
            [Dependency]
            public ISCLG010 Login { get; set; }
        }
        #endregion
    }
}
