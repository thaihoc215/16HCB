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

    partial class SCRC030VM_DanhSachCauThu : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC030VM_DanhSachCauThu));
        #region Class Variables
        //Danh sach cau thu
        CauThuModel _cauThuItem = new CauThuModel();
        public CauThuModel CauThuItem
        {
            get { return _cauThuItem; }
            set
            {
                _cauThuItem = value;
                if (value != null)
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
        //Doi bong
        DoiBongModel _doiBongItem = new DoiBongModel();//dieu kien search
        public DoiBongModel DoiBongItem
        {
            get { return _doiBongItem; }
            set
            {
                _doiBongItem = value;
                RaisePropertyChanged("DoiBongItem");
            }
        }
        private DoiBongModel _doiBongEditItem = new DoiBongModel();//noi dung edit
        public DoiBongModel DoiBongEditItem
        {
            get { return _doiBongEditItem; }
            set
            {
                _doiBongEditItem = value;
                RaisePropertyChanged("DoiBongEditItem");
            }
        }
        ObservableCollection<DoiBongModel> _doiBongItems = new ObservableCollection<DoiBongModel>();
        public ObservableCollection<DoiBongModel> DoiBongItems
        {
            get { return _doiBongItems; }
            set
            {
                _doiBongItems = value;
                RaisePropertyChanged("DoiBongItems");
            }
        }
        //Vi tri
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
            set
            {
                _viTriItems = value;
                RaisePropertyChanged("ViTriItems");
            }
        }
        string searchCauThu = "";
        public string SearchCauThu
        {
            get { return searchCauThu; }
            set
            {
                searchCauThu = value;
                RaisePropertyChanged("SearchCauThu");
            }
        }

        bool _isControlEnable = false;
        public bool IsControlEnable
        {
            get { return _isControlEnable; }
            set
            {
                _isControlEnable = value;
                RaisePropertyChanged("IsControlEnable");
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

        //Editcontent
        string _changeCauThu = "Lưu";
        public string ChangeCauThu
        {
            get { return _changeCauThu; }
            set
            {
                _changeCauThu = value;
                RaisePropertyChanged("ChangeCauThu");
            }
        }

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

        string _logoString = string.Empty;

        public string LogoString
        {
            get { return _logoString; }
            set
            {
                _logoString = value;
                RaisePropertyChanged("LogoString");
            }
        }
        //Đương dẫn khởi tạo và sau khi được chọn
        private string _avaFilepath { get; set; }

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
        public SCRC030VM_DanhSachCauThu(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            DsCauThuDAO = dao.DsCauThuDAO;
            CauThuItems = DsCauThuDAO.GetListCauThu();
            CauThuItem = null;
            DoiBongItems = DsCauThuDAO.GetListDoiBong();
            DoiBongItem = null;
            DoiBongEditItem = null;
            ViTriItems = DsCauThuDAO.GetListViTri();
            ViTriItem = null;

            //Lay danh sach quy dinh
            var lstQuyDinh = DsCauThuDAO.GetListQuyDinh();
            QuyDinh.TuoiMax = lstQuyDinh.Where(t => t.Key.Trim() == "TuoiMax").FirstOrDefault().Value;
            QuyDinh.TuoiMin = lstQuyDinh.Where(t => t.Key.Trim() == "TuoiMin").FirstOrDefault().Value;
            QuyDinh.SoLuongMin = lstQuyDinh.Where(t => t.Key.Trim() == "SoLuongMin").FirstOrDefault().Value;
            QuyDinh.SoLuongMax = lstQuyDinh.Where(t => t.Key.Trim() == "SoLuongMax").FirstOrDefault().Value;
            QuyDinh.CTNgoai = lstQuyDinh.Where(t => t.Key.Trim() == "CTNgoai").FirstOrDefault().Value;

            IsAccept = Constants.UserUsing.LoaiNV > 2 ? false : true;
            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        #region Search Cau thu
        private void ExecuteSearchCauThuCommand(object obj)
        {
            Log.Info(string.Format("{0} Tim kiem cau thu", EmailNguoiDung));
            CauThuItems = DsCauThuDAO.SearchCauThu(SearchCauThu, DoiBongItem.MaDoi);
            if (CauThuItems.Count == 0)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Không tìm thấy cầu thủ");
                ResetCauThu();
                IsControlEnable = false;
                return;
            }
            ResetCauThu();
            CauThuItem = CauThuItems[0];
            HoTen = CauThuItem.HoTen;
            QuocTich = CauThuItem.QuocTich;
            IsControlEnable = false;
        }
        private bool CanExecuteSearchCauThuCommand(object obj)
        {
            return DoiBongItem != null;
        }

        private void ExecuteSearchAllCommand(object obj)
        {
            CauThuItems = DsCauThuDAO.GetListCauThu();
            if (CauThuItems.Count == 0)
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Danh sách cầu thủ trống");
            ResetCauThu();
            IsControlEnable = false;
        }
        #endregion

        #region Edit cau thu
        bool isEditCauThu = false;
        /*
         * Binding cầu thủ được chọn trên datagrid
         */
        private void ExecuteCauThuChangedCommand(object obj)
        {
            if (CauThuItem != null)
            {
                DoiBongEditItem = DoiBongItems.Where(db => db.MaDoi == CauThuItem.DoiBong).FirstOrDefault();
                ViTriItem = ViTriItems.Where(vt => vt.MaVT == CauThuItem.ViTri).FirstOrDefault();
                IsControlEnable = false;
                //Set image source bit map for logo
                LogoString = Constants.IMAGE_CAUTHUAVA_FOLDER + "/" +
            (string.IsNullOrEmpty(CauThuItem.AnhDaiDien) ? "NOAVA.jpg" : CauThuItem.AnhDaiDien);
                CauThuAva = Constants.SetImageSource(LogoString);
                HoTen = CauThuItem.HoTen;
                QuocTich = CauThuItem.QuocTich;
            }

        }
        /*
         * Open control thêm cầu thủ
         */
        private void ExecuteOpenAddCauThuCommand(object obj)
        {
            ResetCauThu();
            isEditCauThu = false;
            IsControlEnable = true;

            CauThuItem = new CauThuModel(DsCauThuDAO.GetMaxCauThu() + 1);
            CauThuAva = Constants.SetImageSource(Constants.IMAGE_CAUTHUAVA_FOLDER + "/" + "NOAVA.jpg");
            ChangeCauThu = "Thêm";
        }

        /*
         * Open control edit cầu thủ
         */
        private void ExecuteOpenEditCauThuCommand(object obj)
        {
            //ResetCauThu();
            IsControlEnable = true;
            isEditCauThu = true;
            ChangeCauThu = "Lưu";
            //if(CauThuItems)
        }
        private bool CanExecuteOpenEditCauThuCommand(object obj)
        {
            return IsAccept && CauThuItem != null && CauThuItems.Count > 0;
        }


        /*
         * chon avata cho cau thu
         */
        private void ExecuteChooseAvaCommand(object obj)
        {
            Log.Info(string.Format("{0} Chon logo cau thu", EmailNguoiDung));
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
            return IsControlEnable;
        }

        //Xac nhan Them, chinh sua cau thu
        private void ExecuteConfirmChangeCauThuCommand(object obj)
        {
            CauThuItem.DoiBong = DoiBongEditItem.MaDoi;
            CauThuItem.ViTri = ViTriItem.MaVT;
            CauThuItem.HoTen = HoTen;
            
            int soluongCtNgoai = DsCauThuDAO.SearchCauThu("", CauThuItem.DoiBong).Where(ct => ct.QuocTich.ToLower() != "việt nam").Count();
            //Kiem tra tuoi cau thu theo quy dinh
            int age = DateTime.Now.Year - CauThuItem.NgaySinh.Year;
            if (age < QuyDinh.TuoiMin || age > QuyDinh.TuoiMax)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Cầu thủ phải trong độ tuổi "
                    + QuyDinh.TuoiMin + " - " + QuyDinh.TuoiMax);
                return;
            }
            

            //Set name for image in database
            if (!string.IsNullOrEmpty(_avaFilepath))
                CauThuItem.AnhDaiDien = "avaCT" + (CauThuItem.MaCauThu).ToString() + ".jpg";
            if (isEditCauThu) //Chinh sua cau thu
            {
                //Kiem tra so luong cau thu ngoai
                if (soluongCtNgoai >= 3 && CauThuItem.QuocTich.ToLower() == "việt nam" && QuocTich.ToLower()!="việt nam")
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ ngoại không được vượt quá "
                        + QuyDinh.CTNgoai);
                    return;
                }

                if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn thay đổi thông tin cầu thủ không?")
                == System.Windows.MessageBoxResult.No)
                {
                    CauThuAva = Constants.SetImageSource(LogoString);
                    return;
                }

                CauThuItem.QuocTich = QuocTich;
                Log.Info(string.Format("{0} Thay doi thong tin cau thu", EmailNguoiDung));
                if (DsCauThuDAO.UpdateCauThu(CauThuItem))
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Thay đổi thông tin cầu thủ thành công");
                    IsControlEnable = false;
                    int maCt = CauThuItem.MaCauThu;
                    //luu anh cau thu vao resource
                    if (!string.IsNullOrEmpty(_avaFilepath))
                    {
                        string destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + CauThuItem.AnhDaiDien;
                        File.Copy(_avaFilepath, destinationPath, true);
                    }
                    CauThuItems = DsCauThuDAO.GetListCauThu();
                    CauThuItem = CauThuItems.Where(ct => ct.MaCauThu == maCt).FirstOrDefault();
                    //CauThuAva = Constants.SetImageSource(destinationPath);

                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thay đổi thông tin cầu thủ không thành công");
            }

            else // Them cau thu 
            {
                CauThuItem.QuocTich = QuocTich;
                if (soluongCtNgoai >= 3 && CauThuItem.QuocTich.ToLower() != "việt nam")
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ ngoại không được vượt quá "
                        + QuyDinh.CTNgoai);
                    return;
                }

                int soluongCt = DsCauThuDAO.SearchCauThu("", CauThuItem.DoiBong).Count();
                if (soluongCt >= QuyDinh.SoLuongMax)
                {
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ của đội bóng từ "
                        + QuyDinh.SoLuongMin + " - " + QuyDinh.SoLuongMax);
                    return;
                }
                Log.Info(string.Format("{0} Them cau thu", EmailNguoiDung));
                if (DsCauThuDAO.AddCauThu(CauThuItem))
                {
                    //Kiem tra so luong cau thu

                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information,
                        string.Format("Thêm cầu thủ {0} thành công", CauThuItem.MaCauThu));
                    IsControlEnable = false;
                    if (!string.IsNullOrEmpty(_avaFilepath))
                    {
                        string destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + CauThuItem.AnhDaiDien;
                        File.Copy(_avaFilepath, destinationPath, true);
                    }

                    ResetCauThu();
                    CauThuItems = DsCauThuDAO.GetListCauThu();
                    isEditCauThu = true;
                }
                else
                    MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Thêm cầu thủ không thành công");

            }
        }

        private bool CanExecuteConfirmChangeCauThuCommand(object obj)
        {
            return IsControlEnable && !string.IsNullOrEmpty(HoTen) && ViTriItem != null && DoiBongEditItem != null
                && !string.IsNullOrEmpty(QuocTich);
        }

        /*
         * Huy them sua cau thu
         */
        private void ExecuteCancelCauThuCommand(object obj)
        {
            ResetCauThu();
            if (isEditCauThu)
                CauThuAva = Constants.SetImageSource(LogoString);
            else
                CauThuAva = Constants.SetImageSource(Constants.IMAGE_CAUTHUAVA_FOLDER + "/" + "NOAVA.jpg");
            IsControlEnable = false;
        }
        private bool CanExecuteCancelCauThuCommand(object obj)
        {
            return IsControlEnable;
        }

        /*
         * Xoa cau thu cua doi bong
         */
        private void ExecuteDeleteCauThuCommand(object obj)
        {
            int soluongCt = DsCauThuDAO.GetListCauThu().Where(ct => ct.DoiBong == CauThuItem.DoiBong).Count();
            //soluongCt =< QuyDinh.SoLuongMin || 
            if (soluongCt <= QuyDinh.SoLuongMin)
            {
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Số lượng cầu thủ của đội bóng từ "
                    + QuyDinh.SoLuongMin + " - " + QuyDinh.SoLuongMax);
                return;
            }
            if (MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Confirmation, "Bạn có chắc chắn muốn xóa cầu thủ không?")
                == System.Windows.MessageBoxResult.No)
                return;
            Log.Info(string.Format("{0} Xoa cau thu", EmailNguoiDung));
            if (DsCauThuDAO.DeleteCauThu(CauThuItem.MaCauThu))
            {

                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Information, "Xóa cầu thủ thành công");
                IsControlEnable = false;
                if (!string.IsNullOrEmpty(CauThuItem.AnhDaiDien))
                {
                    string destinationPath = Constants.IMAGE_CAUTHUAVA_FOLDER + "\\" + CauThuItem.AnhDaiDien;
                    File.Delete(destinationPath);
                    CauThuAva = null;
                }

                ResetCauThu();
                CauThuItems = DsCauThuDAO.GetListCauThu();
            }
            else
                MessageBoxUtil.ShowMessage(MessageBoxUtil.MessageTypes.Errors, "Xóa cầu thủ không thành công");
        }

        private bool CanExecuteDeleteCauThuCommand(object obj)
        {
            return IsAccept && CauThuItem != null && CauThuItems.Count > 0;
        }

        void ResetCauThu()
        {
            CauThuItem = new CauThuModel();
            HoTen = CauThuItem.HoTen;
            QuocTich = CauThuItem.QuocTich;
            ViTriItem = null;
            DoiBongEditItem = null;
        }
        #endregion
        #endregion

        #region Dao
        ISCRC030 DsCauThuDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCRC030 DsCauThuDAO { get; set; }
        }
        #endregion
    }
}
