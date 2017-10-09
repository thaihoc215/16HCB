/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 17/03/2017 - SCMN010VM_MainWindow
 */
using log4net;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCMN010VM_MainWindow : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCMN010VM_MainWindow));
        #region Class Variables
        string _tenTaiKhoan = "";
        public string TenTaiKhoan
        {
            get { return _tenTaiKhoan; }
            set
            {
                _tenTaiKhoan = value;
                RaisePropertyChanged("TenTaiKhoan");
            }
        }

        string _loaiTaiKhoan = "";
        public string LoaiTaiKhoan
        {
            get { return _loaiTaiKhoan; }
            set
            {
                _loaiTaiKhoan = value;
                RaisePropertyChanged("LoaiTaiKhoan");
            }
        }

        int _menuTabIndex = 0;

        public int MenuTabIndex
        {
            get { return _menuTabIndex; }
            set
            {
                _menuTabIndex = value;
                RaisePropertyChanged("MenuTabIndex");
            }
        }

        string _SCRC020Screen = null;

        public string SCRC020Screen
        {
            get { return _SCRC020Screen; }
            set
            {
                _SCRC020Screen = value;
                RaisePropertyChanged("SCRC020Screen");
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
        public SCMN010VM_MainWindow(params object[] args)
            : base(args)
        {
            
        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            UserLogin = (NguoiDungModel)Args[0];
            
            TenTaiKhoan = UserLogin.HoTen;
            LoaiTaiKhoan = UserLogin.TenLoai;
            SCRC020Screen = "SCRC020V_DanhSachChung.xaml";
        }
        #endregion

        #region Command
        void ExecuteLogoutCommand(object obj)
        {
        }

        void ExecuteCancelCommand(object obj)
        {
        }

        void ExecuteMenuTabChangeCommand(object obj)
        {
            //switch (MenuTabIndex)
            //{
            //    case 0: break;
            //    case 1:
            //        {
            //            SCRC020Screen = string.Empty;
            //            SCRC020Screen = "SCRC020V_DanhSachChung.xaml";
            //            InitializeProperties();
            //            break;
            //        }
            //    default:
            //        break;
            //}
        }

        #endregion

        #region Dao
        class Dao
        {
        }
        #endregion
    }
}
