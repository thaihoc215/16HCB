/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 17/03/2017 - SCLG010VM_Login
 */
using log4net;
using Microsoft.Practices.Unity;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Threading;
using System.Windows;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCLG010VM_Login : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCLG010VM_Login));

        #region Class Variables
        string _userID = "";
        public string UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                RaisePropertyChanged("UserID");
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
        public SCLG010VM_Login(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            Login = dao.Login;
            //UserID = "1";
            //PassWord = "1234567";
            
        }
        #endregion

        #region Command
        void ExecuteLoginCommand(object obj)
        {
            
            UserLogin = Login.GetUser(UserID,PassWord);
            if (UserLogin == null)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Tài khoản hoặc mật khẩu không đúng");
                Log.Error("Login Fail");
                return;
            }
            Constants.UserUsing = UserLogin;
            ViewForwarder.ForwardModeless("SCMN010VM_MainWindow", Constants.UserUsing);
            Log.Info(string.Format("{0} Loggin",UserLogin.Email));
            CloseDialogBox();
            
        }

        bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrEmpty(UserID) && !string.IsNullOrEmpty(PassWord);
        }
        
        void ExecuteCancelCommand(object obj)
        {
            Log.Info(string.Format("Close program"));
            CloseDialogBox();
        }

        void ExecuteOpenDoiMatKhauCommand(object obj)
        {
            ViewForwarder.ForwardModal("SCLG011VM_DoiMatKhau");
            Log.Info(string.Format("Change Password"));
        }
        #endregion

        #region Dao
        ISCLG010 Login { get; set; }
        class Dao
        {
            [Dependency]
            public ISCLG010 Login { get; set; }
        }
        #endregion      
    }
    
}
