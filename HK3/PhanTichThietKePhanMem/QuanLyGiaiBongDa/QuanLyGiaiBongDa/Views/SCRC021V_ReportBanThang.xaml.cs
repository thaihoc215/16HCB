using QuanLyGiaiBongDa.QUANLYGIAIBONGDADataSet1TableAdapters;
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
    /// Interaction logic for SCRC021V_ReportBanThang.xaml
    /// </summary>
    public partial class SCRC021V_ReportBanThang : Window
    {
        public SCRC021V_ReportBanThang()
        {
            InitializeComponent();
            _reportViewer.Load += _reportViewer_Load;
        }
        private bool _isReportViewerLoaded;
        private void _reportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 =
                            new Microsoft.Reporting.WinForms.ReportDataSource();

                QUANLYGIAIBONGDADataSet1 dataset = new QUANLYGIAIBONGDADataSet1();
                dataset.BeginInit();

                reportDataSource1.Name = "DanhSachBanThangReport";
                reportDataSource1.Value = dataset.DanhSachBanThang;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource =
                            "QuanLyGiaiBongDa.SCRC021_ReportBanThang.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                DanhSachBanThangTableAdapter datasetAdapter = new DanhSachBanThangTableAdapter();
                datasetAdapter.ClearBeforeFill = true;
                datasetAdapter.Fill(dataset.DanhSachBanThang);

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}
