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
    public partial class VrmVaccination : Form
    {
        public VrmVaccination()
        {
            InitializeComponent();
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

                            Vaccination vaccination = new Vaccination
                                                          {
                                                              Animal = animal,
                                                              Personnel = personnel,
                                                              Date = clVaccination.SelectionStart,
                                                              Place = txtPlace.Text,
                                                              UsedMedicament = txtUsedMedicament.Text,
                                                              VacinationFor = txtVaccinationFor.Text
                                                          };

                            vaccination.Save();

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

        private void VrmVaccination_Load(object sender, EventArgs e)
        {
            cmbAnimal.DataSource = Animal.FindAll();
            cmbAnimal.DisplayMember = "FromatedName";
            cmbAnimal.ValueMember = "Id";

            cmbPersonnel.DataSource = Personnel.FindAll();
            cmbPersonnel.DisplayMember = "FormatedName";
            cmbPersonnel.ValueMember = "Id";
        }
    }
}
