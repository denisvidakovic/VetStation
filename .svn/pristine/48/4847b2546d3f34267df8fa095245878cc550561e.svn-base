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
    public partial class FrmClinicTreatment : Form
    {
        private Animal _animal;
        public FrmClinicTreatment()
        {
            InitializeComponent();
        }
        public FrmClinicTreatment(Animal animal)
        {
            _animal = animal;
            InitializeComponent();
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
                        ClinicTreatment ct = new ClinicTreatment();
                        ct.Date = clClinicTreatment.SelectionStart;
                        ct.Diagnosis = txtDiagnosis.Text;
                        ct.Therapy = txtTherapy.Text;
                        ct.UsedMedicine = txtMedicine.Text;
                        ct.Animal = animal;
                        ct.Personnel = personnel;
                        ct.Save();
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

        private void FrmClinicTreatment_Load(object sender, EventArgs e)
        {
            if(_animal != null)
            {
                cmbAnimal.Enabled = false;
                cmbAnimal.Items.Add(_animal);
                cmbAnimal.DisplayMember = "Name";
            }
            else
            {
                cmbAnimal.DataSource = Animal.FindAll();
                cmbAnimal.DisplayMember = "FromatedName";
                cmbAnimal.ValueMember = "Id";
            }
            cmbPersonnel.DataSource = Personnel.FindAll();
            cmbPersonnel.DisplayMember = "FormatedName";
            cmbPersonnel.ValueMember = "Id";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
