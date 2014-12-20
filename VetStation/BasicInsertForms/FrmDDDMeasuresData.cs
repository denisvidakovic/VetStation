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
    public partial class FrmDDDMeasuresData : Form
    {
        public FrmDDDMeasuresData()
        {
            InitializeComponent();
        }

        private void FrmDDDMeasuresData_Load(object sender, EventArgs e)
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
            Animal animal = (Animal)cmbAnimal.SelectedItem;
            Personnel personnel = (Personnel)cmbPersonnel.SelectedItem;

            if (animal == null || personnel == null)
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

                            DDDMeasure measure = new DDDMeasure
                            {
                                Animal = animal,
                                Personnel = personnel,
                                Date = clMeasures.SelectionStart,
                                Place = txtPlace.Text,
                                MeasureName = txtMeasureName.Text,
                                MeasureType = txtMeasureType.Text,
                                UsedRemedy = txtUsedRemedy.Text
                            };

                            measure.Save();

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
