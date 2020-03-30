﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursachBD
{
    public partial class View4 : Form
    {
        private string filter;
        private bool _isReportViewerLoaded;
        private BDDataSet dataset;
        private string viewer;
        private string tables;
        public View4(BDDataSet dt, string flt, string view, string tb)
        {
            InitializeComponent();
            _isReportViewerLoaded = false;
            dataset = dt;
            filter = flt;
            viewer = view;
            tables = tb;
        }

        private void View4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "BDDataSet.Stancii". При необходимости она может быть перемещена или удалена.
            this.StanciiTableAdapter.Fill(this.BDDataSet.Stancii);

            this.reportViewer1.RefreshReport();
            if (!_isReportViewerLoaded)
            {
                ReportDataSource reportDataSource1 = new ReportDataSource();
                DataTable table = dataset.Tables[$"{tables}"];
                string expression;
                expression = string.Format($"{table.Columns[1].ColumnName} LIKE '{filter}%'");
                DataRow[] foundRows;
                foundRows = table.Select(expression);
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = foundRows;
                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                reportViewer1.LocalReport.ReportEmbeddedResource = $"{viewer}";
                reportViewer1.RefreshReport();
                _isReportViewerLoaded = true;
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
