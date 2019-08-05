using FacturasOsprint.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturasOsprint.ReportsView
{
    public partial class FormFactura : Form
    {
        private readonly List<Factura> _facturas;
        public FormFactura(Factura factura)
        {
            _facturas = new List<Factura>
            {
                factura
            };
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _facturas));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", _facturas.FirstOrDefault().Servicios));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("HideBg", "False", true));
            this.reportViewer1.RefreshReport();
        }

        private bool printing = false;

        private void reportViewer1_PrintingBegin(object sender, ReportPrintEventArgs e)
        {
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("HideBg", "True", true));
            this.printing = true;
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            if (this.printing == true)
            {
                this.printing = false;
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("HideBg", "False", true));
            }
        }

        private void reportViewer1_RenderingBegin(object sender, CancelEventArgs e)
        {
            if (this.reportViewer1.DisplayMode == DisplayMode.PrintLayout)
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("HideBg", "True", true));
            else
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("HideBg", "False", true));

        }
    }
}
