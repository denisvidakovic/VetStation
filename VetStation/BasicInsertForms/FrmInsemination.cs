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
    public partial class FrmInsemination : Form
    {
        public FrmInsemination()
        {

            InitializeComponent();
        }

        private void FrmInsemination_Load(object sender, EventArgs e)
        {
            cmbAnimal.DataSource = Animal.FindAll();
            cmbAnimal.DisplayMember = "FromatedName";
            cmbAnimal.ValueMember = "Id";

            cmbBullBreed.DataSource = Breed.FindAll();
            cmbBullBreed.DisplayMember = "Name";
            cmbBullBreed.ValueMember = "Id";

            cmbPersonnel.DataSource = Personnel.FindAll();
            cmbPersonnel.DisplayMember = "FormatedName";
            cmbPersonnel.ValueMember = "Id";

            List<int> expectedSuccess = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                expectedSuccess.Add(i);
            }
            cmbExpectedSuccess.DataSource = expectedSuccess;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Breed bullBreed = (Breed)cmbBullBreed.SelectedItem;
            Animal animal = (Animal)cmbAnimal.SelectedItem;
            Personnel personnel = (Personnel)cmbPersonnel.SelectedItem;

            if (bullBreed == null || animal == null || personnel == null)
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
                            Insemination insemination = new Insemination();
                            insemination.BullBreed = bullBreed;
                            insemination.BullName = txtBullName.Text;
                            insemination.Date = clInsemination.SelectionStart;
                            insemination.ExpectedSuccess = (int)cmbExpectedSuccess.SelectedItem;
                            insemination.Personnel = personnel;
                            insemination.Animal = animal;
                            insemination.Save();

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
