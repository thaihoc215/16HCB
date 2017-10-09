/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 27/03/2017 - SCRC060V_Thongtin.xaml.cs
 */
using QuanLyGiaiBongDa.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SCRC060V_Thongtin.xaml
    /// </summary>
    public partial class SCRC060V_Thongtin : UserControl
    {
        public SCRC060V_Thongtin()
        {
            InitializeComponent();
            SCRC060VM_Thongtin vm = new SCRC060VM_Thongtin();
            this.DataContext = vm;
        }

        private void BTN_LOGOUT_00_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (SCRC060VM_Thongtin)DataContext;
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
