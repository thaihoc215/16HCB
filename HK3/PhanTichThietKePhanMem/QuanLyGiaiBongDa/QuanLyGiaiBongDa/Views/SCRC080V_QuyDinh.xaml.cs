using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuanLyGiaiBongDa.ViewModels;
using QuanLyGiaiBongDa.Common;
using QuanLyGiaiBongDa.Models;

namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SCRC080V_QuyDinh.xaml
    /// </summary>
    public partial class SCRC080V_QuyDinh : UserControl
    {
        public SCRC080V_QuyDinh()
        {
            InitializeComponent();
            SCRC080VM_QuyDinh vm = new SCRC080VM_QuyDinh();
            this.DataContext = vm;
        }

        private void BTN_LOGOUT_00_Click(object sender, RoutedEventArgs e)
        {
            var vm = (SCRC080VM_QuyDinh)DataContext;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() =>
                {
                    var window = Window.GetWindow(this);
                    if (window != null)
                    {
                        window.Close();
                    }
                });
        }
    }
}
