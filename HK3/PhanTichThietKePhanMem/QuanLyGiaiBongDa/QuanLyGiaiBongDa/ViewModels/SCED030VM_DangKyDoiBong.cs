/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 31/03/2017 - SCED030VM_DangKyDoiBong.cs
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
    partial class SCED030VM_DangKyDoiBong : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCED030VM_DangKyDoiBong));
        #region Class Variables
        DoiBongModel _doiBongItem = new DoiBongModel();
        public DoiBongModel DoiBongItem
        {
            get { return _doiBongItem; }
            set
            {
                _doiBongItem = value;
                RaisePropertyChanged("DoiBongItem");
            }
        }

        HuanLuyenVienModel _hlvItem = new HuanLuyenVienModel();
        public HuanLuyenVienModel HlvItem
        {
            get { return _hlvItem; }
            set
            {
                _hlvItem = value;
                RaisePropertyChanged("HlvItem");
            }
        }
        ObservableCollection<HuanLuyenVienModel> _hlvItems = new ObservableCollection<HuanLuyenVienModel>();
        public ObservableCollection<HuanLuyenVienModel> HlvItems
        {
            get { return _hlvItems; }
            set
            {
                _hlvItems = value;
                RaisePropertyChanged("HlvItems");
            }
        }

        SanVanDongModel _sVDItem = new SanVanDongModel();
        public SanVanDongModel SVDItem
        {
            get { return _sVDItem; }
            set
            {
                _sVDItem = value;
                RaisePropertyChanged("SVDItem");
            }
        }
        ObservableCollection<SanVanDongModel> _sVDItems = new ObservableCollection<SanVanDongModel>();
        public ObservableCollection<SanVanDongModel> SVDItems
        {
            get { return _sVDItems; }
            set
            {
                _sVDItems = value;
                RaisePropertyChanged("SVDItems");
            }
        }

        //Doi bong profile picture source
        BitmapImage _doiBongAva;
        public BitmapImage DoiBongAva
        {
            get { return _doiBongAva; }
            set
            {
                _doiBongAva = value;
                RaisePropertyChanged("DoiBongAva");
            }
        }

        string _tenDoi = string.Empty;
        public string TenDoi
        {
            get { return _tenDoi; }
            set
            {
                _tenDoi = value;
                RaisePropertyChanged("TenDoi");
            }
        }
        public string MaHLVBefore { get; set; }
        public string MaSVDBefore { get; set; }

        private string EmailNguoiDung = string.Empty;
        #endregion

        #region Constructor
        public SCED030VM_DangKyDoiBong(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
            var dao = DiContainer.Inject(new Dao());
            DangKyDoiBongDAO = dao.DangKyDoiBongDAO;
            DoiBongItem = new DoiBongModel();
            string maDB = DangKyDoiBongDAO.CountMaxDoiBong();
            maDB = maDB.Substring(0, 2) + (Convert.ToInt32(maDB.Substring(2)) + 1).ToString("00000");
            DoiBongItem.MaDoi = maDB;
            HlvItems = new ObservableCollection<HuanLuyenVienModel>(DangKyDoiBongDAO
                .GetDanhSachHLV()
                .Where(hlv => hlv.DoiBong == string.Empty || hlv.DoiBong == null).ToList());
            HlvItem = null;
            SVDItems = new ObservableCollection<SanVanDongModel>(DangKyDoiBongDAO
                .GetDanhSachSVD()
                .Where(svd => svd.DoiBongSoHuu == string.Empty || svd.DoiBongSoHuu == null).ToList());
            SVDItem = null;
            //Lấy mã HLV và SVĐ trước khi thay đổi

            MaHLVBefore = string.Empty;
            MaSVDBefore = string.Empty;

            string logoPath = Constants.IMAGE_DOIBONGAVA_FOLDER + "/" + "NOAVA.jpg";
            DoiBongAva = Constants.SetImageSource(logoPath);

            EmailNguoiDung = Constants.UserUsing.Email;
        }
        #endregion

        #region Command
        //Duong dan file anh duoc upload
        public string LogoFilepath { get; set; }
        private void ExecuteChooseLogoCommand(object obj)
        {
            Log.Info(string.Format("{0} Chon logo doi bong", EmailNguoiDung));
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                LogoFilepath = open.FileName; // Stores Original Path in Textbox    
                DoiBongAva = Constants.SetImageSource(LogoFilepath);
                DoiBongItem.Logo = "ava" +(DoiBongItem.MaDoi).Trim() + ".jpg";
                //string name = System.IO.Path.GetFileName(filepath);
                //string destinationPath = GetDestinationPath(name, "\\QuanLyGiaiBongDa\\component\\Images\\DoibongAva");
            }
        }
        #endregion

        #region Dao
        ISCED030 DangKyDoiBongDAO { get; set; }
        class Dao
        {
            [Dependency]
            public ISCED030 DangKyDoiBongDAO { get; set; }
        }
        #endregion
        
        #region Public
        public bool ValidateAll()
        {
            return !string.IsNullOrEmpty(TenDoi) && !string.IsNullOrEmpty(DoiBongItem.HuanLuyenVien)
                && !string.IsNullOrEmpty(DoiBongItem.SanVanDong);
        }

        public bool DangKyDoiBong()
        {
            DoiBongItem.HuanLuyenVien = HlvItem.MaHLV;
            DoiBongItem.SanVanDong = SVDItem.MaSan;
            DoiBongItem.TenDoi = TenDoi;
            Log.Info(string.Format("{0} Dang ky doi bong", EmailNguoiDung));
            if (DangKyDoiBongDAO.AddDoibongChuaCauThu(DoiBongItem, MaHLVBefore, MaSVDBefore))
            {
                if (!string.IsNullOrEmpty(LogoFilepath))
                {
                    string destinationPath = Constants.IMAGE_DOIBONGAVA_FOLDER + "\\" + DoiBongItem.Logo;
                    File.Copy(DoiBongAva.UriSource.LocalPath, destinationPath, true);
                }
                //save to resouces                  
                MaHLVBefore = HlvItem == null ? string.Empty : HlvItem.MaHLV;
                MaSVDBefore = SVDItem == null ? string.Empty : SVDItem.MaSan;
                return true;
            }
            return false;
        }

        public void DeleteDoiBong()
        {
            HlvItem = new HuanLuyenVienModel();
            SVDItem = new SanVanDongModel();
            DoiBongItem.HuanLuyenVien = string.Empty;
            DoiBongItem.SanVanDong = string.Empty;

            Log.Info(string.Format("{0} Xoa doi bong", EmailNguoiDung));
            DangKyDoiBongDAO.DeleteDoiBong(DoiBongItem.MaDoi);
        }
        #endregion
    }
}
