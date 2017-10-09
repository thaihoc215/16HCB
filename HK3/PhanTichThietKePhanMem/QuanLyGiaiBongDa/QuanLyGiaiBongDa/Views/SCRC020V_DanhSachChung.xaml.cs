using QuanLyGiaiBongDa.ViewModels;
/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 23/03/2017 - SCRC020V_DanhSachChung.xaml
 */
using System.Windows.Controls;

namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SCRC020V_DanhSachChung.xaml
    /// </summary>
    public partial class SCRC020V_DanhSachChung : UserControl
    {
        public SCRC020V_DanhSachChung()
        {
            InitializeComponent();
            SCRC020VM_DanhSachChung vm = new SCRC020VM_DanhSachChung();
            this.DataContext = vm;
        }
    }
}
