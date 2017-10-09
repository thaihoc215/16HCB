using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 07/05/2017 - SCRC071VM_DSCauThuDoiBong.cs
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC071VM_DSCauThuDoiBong : BaseViewModel
    {
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
        #endregion

		#region Constructor
        public SCRC071VM_DSCauThuDoiBong(params object[] args)
            : base(args)
        {

        }
		#endregion
		
        #region Override
		protected override void InitializeProperties()
        {
            CauThuItems = Args[0] as ObservableCollection<CauThuModel>;
		}
        #endregion

        #region Command
        /*
         * Close Window
         */
        private void ExecuteCloseCommand(object obj)
        {
            CloseDialogBox();
        }
        #endregion

        #region Dao
        class Dao
        {
        }
        #endregion
    }
}
