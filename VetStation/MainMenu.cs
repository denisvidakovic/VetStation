using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VetStation.BasicInsertForms;
using VetStation.ReportForms;

namespace VetStation
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports _frmReports = new frmReports();
            _frmReports.Owner = this;
            _frmReports.Show();

            this.Hide();
        }

        private void btnDataInput_Click(object sender, EventArgs e)
        {
            FrmOwnerData _frmOwnerData = new FrmOwnerData();
            _frmOwnerData.Owner = this;
            _frmOwnerData.Show();

            this.Hide();
        }

        private void btnAnimalData_Click(object sender, EventArgs e)
        {
            FrmAnimalData _frmAnimalData = new FrmAnimalData();
            _frmAnimalData.Owner = this;
            _frmAnimalData.Show();

            this.Hide();
        }

        private void btnClinicTreatment_Click(object sender, EventArgs e)
        {
            FrmClinicTreatment _frmClinic = new FrmClinicTreatment();
            _frmClinic.Owner = this;
            _frmClinic.Show();

            this.Hide();
        }

        private void btnInsemination_Click(object sender, EventArgs e)
        {
            FrmInsemination _frmInsemination = new FrmInsemination();
            _frmInsemination.Owner = this;
            _frmInsemination.Show();

            this.Hide();
        }

        private void btnDddMeasures_Click(object sender, EventArgs e)
        {
            FrmDDDMeasuresData _frmDdd = new FrmDDDMeasuresData();
            _frmDdd.Owner = this;
            _frmDdd.Show();

            this.Hide();
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            FrmDiagnosticData _frmDiagnostic = new FrmDiagnosticData();
            _frmDiagnostic.Owner = this;
            _frmDiagnostic.Show();

            this.Hide();
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            FrmVaccination _frmVaccination = new FrmVaccination();
            _frmVaccination.Owner = this;
            _frmVaccination.Show();

            this.Hide();
        }
    }
}
