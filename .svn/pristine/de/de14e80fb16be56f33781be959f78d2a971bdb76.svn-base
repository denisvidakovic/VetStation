using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data;

namespace VetStation.ReportForms
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            DirectDataAccess.GetOwnersByFirstName(tbl, txtSearch.Text);
            dataGridView1.DataSource = tbl;
        }

        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            PDFHelper pdfHelper = new PDFHelper();
            pdfHelper.CreatePdfFromQuery(txtSearch.Text, tbl);
        }
    }
}
