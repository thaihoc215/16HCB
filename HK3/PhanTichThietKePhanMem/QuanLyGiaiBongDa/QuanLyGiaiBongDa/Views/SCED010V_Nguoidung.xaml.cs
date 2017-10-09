using System;
using System.Windows;
using QuanLyGiaiBongDa.ViewModels;
using System.Windows.Controls;


namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SCED010V_Nguoidung.xaml
    /// </summary>
    public partial class SCED010V_Nguoidung : UserControl
    {
        public SCED010V_Nguoidung()
        {
            InitializeComponent();
            SCED010VM_Nguoidung vm = new SCED010VM_Nguoidung();
            this.DataContext = vm;
        }
        private void BTN_LOGOUT_00_Click(object sender, RoutedEventArgs e)
        {
            var vm = (SCED010VM_Nguoidung)DataContext;
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
