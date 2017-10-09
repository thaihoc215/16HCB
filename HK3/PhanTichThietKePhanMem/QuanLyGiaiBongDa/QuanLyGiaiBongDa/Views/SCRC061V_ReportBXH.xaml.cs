/*
 * 1642021 - Ha Nguyen Thai Hoc
 * 30/03/2017 - SCRC061V_ReportBXH.xaml.cs
 */
using QuanLyGiaiBongDa.QUANLYGIAIBONGDADataSet1TableAdapters;
using System;
using System.Windows;

namespace QuanLyGiaiBongDa.Views
{
    /// <summary>
    /// Interaction logic for SCRC061V_ReportBXH.xaml
    /// </summary>
    public partial class SCRC061V_ReportBXH : Window
    {
        public SCRC061V_ReportBXH()
        {
            InitializeComponent();
            _reportViewer.Load += _reportViewer_Load;
        }
        private bool _isReportViewerLoaded;
        void _reportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 =
                            new Microsoft.Reporting.WinForms.ReportDataSource();

                QUANLYGIAIBONGDADataSet1 dataset = new QUANLYGIAIBONGDADataSet1();
                dataset.BeginInit();

                reportDataSource1.Name = "QUANLYGIAIBONGDAData";
                reportDataSource1.Value = dataset.BangXepHang;
                this._reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this._reportViewer.LocalReport.ReportEmbeddedResource =
                            "QuanLyGiaiBongDa.SCRC061_ReportBXH.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                BangXepHangTableAdapter datasetAdapter = new BangXepHangTableAdapter();
                datasetAdapter.ClearBeforeFill = true;
                datasetAdapter.Fill(dataset.BangXepHang);

                _reportViewer.RefreshReport();
   
                _isReportViewerLoaded = true;
            }
        }
    }
}
