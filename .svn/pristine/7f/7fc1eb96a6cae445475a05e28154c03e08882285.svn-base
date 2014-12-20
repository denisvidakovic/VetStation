using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.ActiveRecord;
using Model;

namespace VetStation.BasicInsertForms
{
    public partial class FrmDiagnosticData : Form
    {
        public FrmDiagnosticData()
        {
            InitializeComponent();
        }

        private void FrmDiagnosticData_Load(object sender, EventArgs e)
        {
            cmbAnimal.DataSource = Animal.FindAll();
            cmbAnimal.DisplayMember = "FromatedName";
            cmbAnimal.ValueMember = "Id";

            cmbPersonnel.DataSource = Personnel.FindAll();
            cmbPersonnel.DisplayMember = "FormatedName";
            cmbPersonnel.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Animal animal = (Animal) cmbAnimal.SelectedItem;
            Personnel personnel = (Personnel) cmbPersonnel.SelectedItem;

            if(animal == null || personnel == null)
            {
                
            }
            else
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            string examinationType = "";
                            if (chkBlod.Checked)
                                examinationType += chkBlod.Text;
                            if (chkMilk.Checked)
                                examinationType += chkMilk.Text;
                            if (chkOther.Checked)
                                examinationType += chkOther.Text;

                            Diagnostic diagnostic = new Diagnostic();
                            diagnostic.Animal = animal;
                            diagnostic.Personnel = personnel;
                            diagnostic.ExaminationDate = clDiagnostic.SelectionStart;
                            diagnostic.ExaminationIllness = txtExaminationIllness.Text;
                            //diagnostic.ExaminationTypes = examinationType;
                            diagnostic.SamplingDate = clDiagnostic.SelectionStart;

                            diagnostic.Save();
                            ts.VoteCommit();

                            lblInfo.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            lblInfo.Text = "Nemoguće snimiti podatak";
                        }

                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
