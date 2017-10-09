using QuanLyGiaiBongDa.Common;
using System.Windows;

namespace QuanLyGiaiBongDa
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            ViewForwarder.Application = App.Current;
            ViewForwarder.ForwardModal("SCLG010VM_Login");
            //log4net.Config.XmlConfigurator.Configure();

            //NguoiDungModel UserId = new NguoiDungModel();
            //UserId.HoTen = "test";
            //ViewForwarder.ForwardModal("SCMN010VM_MainWindow", UserId);
        }
    }
     
    
}
