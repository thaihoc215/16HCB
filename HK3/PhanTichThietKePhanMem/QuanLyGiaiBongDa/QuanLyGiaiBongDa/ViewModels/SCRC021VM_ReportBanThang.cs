using log4net;
using QuanLyGiaiBongDa.Common;

namespace QuanLyGiaiBongDa.ViewModels
{
    partial class SCRC021VM_ReportBanThang : BaseViewModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SCRC021VM_ReportBanThang));
        #region Constructor
        public SCRC021VM_ReportBanThang(params object[] args)
            : base(args)
        {

        }
        #endregion

        #region Override
        protected override void InitializeProperties()
        {
            Log.Info("InitializeProperties");
        }
        #endregion
    }
}
