using Microsoft.Practices.Unity;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 31/03/2017 - SCED020VM_SwitchThongTinDangKy.cs
 */
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED020VM_SwitchThongTinDangKy : BaseViewModel
    {
        #region Class Variables
        private int _curentPageIndex;
        //Danh sach man hinh switch
        private List<BaseViewModel> _pagesViewModel = new List<BaseViewModel>();
        //Man hinh hien tai dang switch toi
        private BaseViewModel _currentPageViewModel;
        public BaseViewModel CurrentPageViewModel
        {
            get { return _currentPageViewModel; }
            set
            {
                _currentPageViewModel = value;
                this.RaisePropertyChanged("CurrentPageViewModel");
            }

        }

        bool _isDangKy = true;
        public bool IsDangKy
        {
            get { return _isDangKy; }
            set
            {
                _isDangKy = value;
                RaisePropertyChanged("IsDangKy");
            }
        }

        string _visibleStatus;

        public string VisibleStatus
        {
            get { return _visibleStatus; }
            set { _visibleStatus = value; }
        }

        string _backContent = "";

        public string BackContent
        {
            get { return _backContent; }
            set
            {
                _backContent = value;
                RaisePropertyChanged("BackContent");
            }
        }

        string _nextContent = "";
        public string NextContent
        {
            get { return _nextContent; }
            set
            {
                _nextContent = value;
                RaisePropertyChanged("NextContent");
            }
        }
        public object WindowSwitch
        {
            get { return Args[0]; }
        }

        #endregion

        #region Constructor
        public SCED020VM_SwitchThongTinDangKy(params object[] args)
            : base(args)
        {

        }
        #endregion
        SCED030VM_DangKyDoiBong _dangKyDoiBong = new SCED030VM_DangKyDoiBong();
        SCED080VM_ThemCauThuDoiBong _themCauThu = new SCED080VM_ThemCauThuDoiBong();
        #region Override
        protected override void InitializeProperties()
        {
            var dao = DiContainer.Inject(new Dao());
            DangKyDoiBongDAO = dao.DangKyDoiBongDAO;
            if (string.IsNullOrEmpty(WindowSwitch.ToString()))
            {
                _curentPageIndex = 0;
                //_pagesViewModel = new List<BaseViewModel>() 
                //{
                //    new SCED030VM_DangKyDoiBong(),
                //    new SCED080VM_ThemCauThuDoiBong()
                //    //new SCED040VM_ThongTinHLV()
                //};
                _pagesViewModel = new List<BaseViewModel>();
                _pagesViewModel.Add(_dangKyDoiBong);
                _pagesViewModel.Add(_themCauThu);

                CurrentPageViewModel = _pagesViewModel[0];
                IsDangKy = true;
                VisibleStatus = "Visible";
                BackContent = "Hủy";
                NextContent = "Tiếp Tục";
            }

            //if (WindowSwitch.GetType() == hlv.GetType())
            //{
            //    CurrentPageViewModel = new SCED040VM_ThongTinHLV(WindowSwitch);
            //    IsDangKy = false;
            //    VisibleStatus = "Hidden";
            //}
        }
        #endregion

        #region Command
        private void ExecuteNextCommand(object obj)
        {

            _curentPageIndex++;

            if (_curentPageIndex > _pagesViewModel.Count - 1)
            {
                if (_themCauThu.KiemTraCauThu())
                    CloseDialogBox();
                else _curentPageIndex--;
            }
                
            else
            {
                //Dang ky doi bong
                if (!_dangKyDoiBong.DangKyDoiBong())
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Khởi tạo đội bóng không thành công.Vui lòng thử lại");
                    _curentPageIndex--;
                    return;
                }
                CurrentPageViewModel = _pagesViewModel[_curentPageIndex];
                _themCauThu.MaDoiBong = _dangKyDoiBong.DoiBongItem.MaDoi;
                _themCauThu.CauThuItems = new ObservableCollection<CauThuModel>();
                BackContent = "Quay Lại";
                NextContent = "Đăng Ký";
            }
        }

        private bool CanExecuteNextCommand(object obj)
        {
            if (_curentPageIndex == 0)
            {
                return _dangKyDoiBong.ValidateAll();
            }
            return true;
        }

        private void ExecuteBackCommand(object obj)
        {
            _curentPageIndex--;
            if (_curentPageIndex < 0)
            {
                CloseDialogBox();
            }

            else
            {
                _dangKyDoiBong.DeleteDoiBong();
                CurrentPageViewModel = _pagesViewModel[_curentPageIndex];
                BackContent = "Hủy";
                NextContent = "Tiếp Tục";
                _themCauThu.DeleteAvaMultiCauThu();
            }
        }

        /*
         * Window close button click
         */
        private void ExecuteCloseWindowCommand(object sender)
        {
            if (_curentPageIndex > _pagesViewModel.Count - 1)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                "Đăng kí đội bóng và cầu thủ thành công");
            }
            else
            {
                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation,
                "Thông tin chưa được lưa, bạn chắc chắn muốn thoát?") == MessageBoxResult.Yes)
                {
                    //xóa ảnh đội bóng
                    string destinationPath = Constants.IMAGE_DOIBONGAVA_FOLDER + "\\" + "ava" + _dangKyDoiBong.DoiBongItem.MaDoi.Trim() + ".jpg";
                    File.Delete(destinationPath);
                    _dangKyDoiBong.DeleteDoiBong();
                    //xóa ảnh của toàn bộ cầu thủ
                    _themCauThu.DeleteAvaMultiCauThu();
                }
                else
                {
                    this.CloseAction();
                    //CloseDialogBox();
                }
            }
                

        }
        public Action CloseAction { get; set; }
        #endregion

        #region Dao
        ISCED020 DangKyDoiBongDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCED020 DangKyDoiBongDAO { get; set; }
        }
        #endregion
    }
}
