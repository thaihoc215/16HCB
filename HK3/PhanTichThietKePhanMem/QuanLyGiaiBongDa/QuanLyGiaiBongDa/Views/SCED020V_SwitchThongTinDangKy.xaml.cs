/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 31/03/2017 - SwitchableWindow.xaml.cs
 */
using MahApps.Metro.Controls;
using QuanLyGiaiBongDa.ViewModels;
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

namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SwitchableWindow.xaml
    /// </summary>
    public partial class SCED020V_SwitchThongTinDangKy : MetroWindow
    {
        public SCED020V_SwitchThongTinDangKy()
        {
            InitializeComponent();
            this.Closing += SCED020V_SwitchThongTinDangKy_Closing;
        }

        private void SCED020V_SwitchThongTinDangKy_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var vm = (SCED020VM_SwitchThongTinDangKy)DataContext;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => e.Cancel = true);
        }
    }
}
