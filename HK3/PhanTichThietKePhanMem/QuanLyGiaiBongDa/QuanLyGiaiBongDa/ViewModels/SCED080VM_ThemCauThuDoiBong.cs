/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 05/04/2017 - SCED080VM_ThemCauThuDoiBong.cs
 */
using log4net;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Dao;
using QuanLyGiaiBongDa.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCED080VM_ThemCauThuDoiBong : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED080VM_ThemCauThuDoiBong));
        #region Class Variables
        ViTriModel _viTriItem = new ViTriModel();
        public ViTriModel ViTriItem
        {
            get { return _viTriItem; }
            set
            {
                _viTriItem = value;
                RaisePropertyChanged("ViTriItem");
            }
        }
        ObservableCollection<ViTriModel> _viTriItems = new ObservableCollection<ViTriModel>();
        public ObservableCollection<ViTriModel> ViTriItems
        {
            get { return _viTriItems; }
            set { _viTriItems = value; }
        }

        CauThuModel _cauThuItem = new CauThuModel();
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

        string _hoTen = string.Empty;
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                _hoTen = value;
                RaisePropertyChanged("HoTen");
            }
        }

        string _quocTich = string.Empty;
        public string QuocTich
        {
            get { return _quocTich; }
            set
            {
                _quocTich = value;
                RaisePropertyChanged("QuocTich");
            }
        }
        //Lay ma doi bong tu man hinh switch
        string _maDoiBong = "";
        public string MaDoiBong
        {
            get { return _maDoiBong; }
            set
            {
                _maDoiBong = value;
                RaisePropertyChanged("MaDoiBong");
            }
        }

        //Danh sach quy dinh
        QuyDinhModel _quyDinh = new QuyDinhModel();
        public QuyDinhModel QuyDinh
        {
            get { return _quyDinh; }
            set
            {
                _quyDinh = value;
                RaisePropertyChanged("QuyDinh");
            }
        }

        //image ava cau thu
        BitmapImage _cauThuAva;

        public BitmapImage CauThuAva
        {
            get { return _cauThuAva; }
            set
            {
                _cauThuAva = value;
                RaisePropertyChanged("CauThuAva");
            }
        }

        //Đương dẫn khởi tạo và sau khi được chọn
        private string _avaFilepath { get; set; }

        private string EmailNguoiDung = string.Empty;
        #endregion

        #region Constructor
        public SCED080VM_ThemCauThuDoiBong(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            DangKyCauThuDAO = dao.DangKyCauThuDAO;
            ViTriItems = DangKyCauThuDAO.GetDanhSachViTri();
            ViTriItem = ViTriItems[0];

            //Lay danh sach quy dinh
            var lstQuyDinh = DangKyCauThuDAO.GetListQuyDinh();
            QuyDinh.TuoiMax = lstQuyDinh.Where(t => t.Key.Trim() == "TuoiMax").FirstOrDefault().Value;
            QuyDinh.TuoiMin = lstQuyDinh.Where(t => t.Key.Trim() == "TuoiMin").FirstOrDefault().Value;
            QuyDinh.SoLuongMin = lstQuyDinh.Where(t => t.Key.Trim() == "SoLuongMin").FirstOrDefault().Value;
            QuyDinh.SoLuongMax = lstQuyDinh.Where(t => t.Key.Trim() == "SoLuongMax").FirstOrDefault().Value;
            QuyDinh.CTNgoai = lstQuyDinh.Where(t => t.Key.Trim() == "CTNgoai").FirstOrDefault().Value;

            IsControlsEnable = false;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        /*
         * Open control add cau thu
         */
        private void ExecuteOpenAddCauThuCommand(object obj)
        {
            IsControlsEnable = true;
            CauThuItem = new CauThuModel();
            int maCT = DangKyCauThuDAO.GetMaxCauThu() + 1;
            CauThuItem = new CauThuModel(maCT);
            CauThuAva = Constants.SetImageSource(Constants.IMAGE_CAUTHUAVA_FOLDER + "//" + "NOAVA.jpg");
        }



        /*
         * Xoa cau thu da them
         */
        private void ExecuteXoaCauThuCommand(object obj)
        {
            IsControlsEnable = false;
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Xác nhận xóa cầu thủ?") == System.Windows.MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Xoa cau thu", EmailNguoiDung));
            if (DangKyCauThuDAO.DeleteCauThu(CauThuItem.MaCauThu))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa cầu thủ thành công.");
                IsControlsEnable = false;
                if (!string.IsNullOrEmpty(CauThuItem.AnhDaiDien))
                {
                    string destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + CauThuItem.AnhDaiDien;
                    File.Delete(destinationPath);
                    CauThuAva = null;
                }
                CauThuItems = DangKyCauThuDAO.GetDsCauThuDoiBong(MaDoiBong);
                CauThuItem = null;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa cầu thủ không thành công.");

        }
        private bool CanExecuteXoaCauThuCommand(object obj)
        {
            return CauThuItem != null && CauThuItems.Count > 0;
        }

        /*
         * Set đội trưởng cho đội bóng
         */
        private void ExecuteSetDoiTruongCommand(object obj)
        {
            IsControlsEnable = false;
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Xác nhận chọn đội trưởng?") == System.Windows.MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Set doi truong cho doi bong", EmailNguoiDung));
            if (DangKyCauThuDAO.SetDoiTruong(CauThuItem))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Chọn đội trưởng thành công.");
                IsControlsEnable = false;
                CauThuItem = null;
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Chọn đội trưởng không thành công.");
        }
        private bool CanExecuteSetDoiTruongCommand(object obj)
        {
            return CauThuItems.Count > 0 && CauThuItem != null;
        }

        /*
         * chon avata cho cau thu
         */
        private void ExecuteChooseAvaCommand(object obj)
        {
            Log.Info(string.Format("{0} Chon ava cau thu", EmailNguoiDung));
            //open file diaglog de chon anh
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                _avaFilepath = open.FileName; // Stores Original Path in Textbox    
                CauThuAva = Constants.SetImageSource(_avaFilepath);
            }
        }
        private bool CanExecuteChooseAvaCommand(object obj)
        {
            return IsControlsEnable;
        }
        /*
         * Thực hiện thêm cầu thủ
         */
        private void ExecuteAddCauThuCommand(object obj)
        {
            CauThuItem.DoiBong = MaDoiBong;
            CauThuItem.ViTri = ViTriItem.MaVT;
            CauThuItem.HoTen = HoTen;
            CauThuItem.QuocTich = QuocTich;
            //Kiem tra tuoi cau thu theo quy dinh
            int age = DateTime.Now.Year - CauThuItem.NgaySinh.Year;
            if (age < QuyDinh.TuoiMin || age > QuyDinh.TuoiMax)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Cầu thủ phải trong độ tuổi "
                    + QuyDinh.TuoiMin + " - " + QuyDinh.TuoiMax);
                return;
            }
            //Kiem tra so luong cau thu
            int soluongCt = DangKyCauThuDAO.GetDsCauThuDoiBong(MaDoiBong).Count();
            if (soluongCt >= QuyDinh.SoLuongMax)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ của đội bóng từ "
                    + QuyDinh.SoLuongMin + " - " + QuyDinh.SoLuongMax);
                return;
            }
            //Kiem tra so luong cau thu ngoai
            int soluongCtNgoai = DangKyCauThuDAO.GetDsCauThuDoiBong(MaDoiBong).Where(ct => ct.QuocTich.ToLower() != "việt nam").Count();
            if (soluongCtNgoai >= 3 && CauThuItem.QuocTich.ToLower() != "việt nam")
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ ngoại không được vượt quá "
                    + QuyDinh.CTNgoai);
                return;
            }

            //Set name for image in database
            if (!string.IsNullOrEmpty(_avaFilepath))
                CauThuItem.AnhDaiDien = "avaCT" + (CauThuItem.MaCauThu).ToString() + ".jpg";
            Log.Info(string.Format("{0} Them cau thu doi bong", EmailNguoiDung));
            if (DangKyCauThuDAO.AddCauThu(CauThuItem))
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                        string.Format("Thêm cầu thủ {0} thành công", CauThuItem.MaCauThu));
                IsControlsEnable = false;

                if (!string.IsNullOrEmpty(_avaFilepath))
                {
                    string destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + CauThuItem.AnhDaiDien;
                    File.Copy(_avaFilepath, destinationPath, true);
                }
                CauThuItem = null;
                CauThuItems = DangKyCauThuDAO.GetDsCauThuDoiBong(MaDoiBong);
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm cầu thủ không thành công.");

        }
        private bool CanExecuteAddCauThuCommand(object obj)
        {
            return IsControlsEnable == true && !string.IsNullOrEmpty(HoTen) && ViTriItem != null
                && !string.IsNullOrEmpty(QuocTich); ;
        }
        /// <summary>
        /// Kiểm tra số lượng cầu thủ trước khi kết thúc việc đăng kí đội bóng
        /// </summary>
        /// <returns></returns>
        public bool KiemTraCauThu()
        {
            int soluongCt = DangKyCauThuDAO.GetDsCauThuDoiBong(MaDoiBong).Count();
            //soluongCt =< QuyDinh.SoLuongMin || 
            if (soluongCt <= QuyDinh.SoLuongMin)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ của đội bóng từ "
                    + QuyDinh.SoLuongMin + " - " + QuyDinh.SoLuongMax);
                return false;
            }
            return true;
        }
        /*
         * Hủy thêm cầu thủ
         */
        private void ExecuteCanCelAddCauThuCommand(object obj)
        {
            IsControlsEnable = false;
            CauThuItem = new CauThuModel();
        }
        #endregion

        #region Dao
        ISCED080 DangKyCauThuDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCED080 DangKyCauThuDAO { get; set; }
        }
        #endregion

        #region Public
        /// <summary>
        /// Xóa toàn bộ ảnh của cầu thủ khi hủy đăng kí đội bóng
        /// </summary>
        public void DeleteAvaMultiCauThu()
        {
            if (CauThuItems.Count > 0)
                foreach (var cthu in CauThuItems)
                {
                    if(!string.IsNullOrEmpty(cthu.AnhDaiDien.Trim()))
                    {
                        string destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + cthu.AnhDaiDien;
                        File.Delete(destinationPath);
                    }
                    
                }
        }
        #endregion  
    }
}
