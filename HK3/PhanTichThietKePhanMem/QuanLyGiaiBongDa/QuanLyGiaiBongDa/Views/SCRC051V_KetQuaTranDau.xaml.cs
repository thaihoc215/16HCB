using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SCRC051V_KetQuaTranDau.xaml
    /// </summary>
    public partial class SCRC051V_KetQuaTranDau : MetroWindow
    {
        public SCRC051V_KetQuaTranDau()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
