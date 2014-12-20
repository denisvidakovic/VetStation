using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Castle.ActiveRecord;
using Model;
using VetStation.BasicInsertForms;

namespace VetStation
{
    public partial class FrmAnimalData : Form
    {
        private Owner _owner;
        public FrmAnimalData()
        {
            InitializeComponent();
        }

        public FrmAnimalData(Owner o)
        {
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bs-Latn-BA");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("bs-Latn-BA");
            _owner = o;
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    try
                    {
                        Animal animal = new Animal
                                                       {
                                                           Owner = (Owner)cmbOwners.SelectedItem,
                                                           Name = txtName.Text,
                                                           Age = (string)cmbAge.SelectedValue,
                                                           Breed = (Breed)cmbBreed.SelectedItem,
                                                           EntryDate = clAnimal.SelectionStart,
                                                           Gender = rbFemale.Checked ? AnimalGender.Female : AnimalGender.Male,
                                                           RegistrationNumber = txtRegNumber_Animal.Text,
                                                           Type = (AnimalType)cmbType.SelectedItem,
                                                           Visible = 1
                                                       };


                        animal.Save();

                        ts.VoteCommit();
                        lblInfo.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblInfo.Text = "Došlo je do problema. Podatke nemoguće spasiti";
                    }
                }
            }
        }


        private void FrmAnimalData_Load(object sender, EventArgs e)
        {
            cmbOwners.DataSource = Model.Owner.FindAllByProperty("Visible",1);
            cmbOwners.DisplayMember = "FirstLastName";
            cmbOwners.ValueMember = "Id";

            if (_owner != null)
            {
                cmbOwners.SelectedItem = _owner;
            }
            cmbBreed.DataSource = Model.Breed.FindAll();
            cmbBreed.DisplayMember = "Name";
            cmbBreed.ValueMember = "Id";

            cmbType.DataSource = Model.AnimalType.FindAll();
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Id";

            HandleAnimalAge();
        }

        private void HandleAnimalAge()
        {
           List<string> ages = new List<string>();
            ages.Add("Nepoznato");
            for(int i = 1; i<=11;i++)
            {
                if(i == 1)
                    ages.Add( i + " mjesec");
                else if(i <= 4)
                    ages.Add(i + " mjeseca");
                else
                    ages.Add(i + " mjeseci");
            }
            for(int i = 1; i <= 10 ; i++)
            {
                ages.Add(i + " godina");
            }

            ages.Add("Više od 10 godina");

            cmbAge.DataSource = ages;
        }

        private void btnAddNewBreed_Click(object sender, EventArgs e)
        {
            FrmBreedData breedData = new FrmBreedData();
            breedData.Show();
            breedData.FormClosed += new FormClosedEventHandler(breedData_FormClosed);
        }

        void breedData_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmbBreed.DataSource = Model.Breed.FindAll();
            cmbOwners.DisplayMember = "Name";
            cmbOwners.ValueMember = "Id";
        }

        private void btnAddNewType_Click(object sender, EventArgs e)
        {
            FrmAnimalTypeData frm = new FrmAnimalTypeData();
            frm.Show();
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmbType.DataSource = Model.AnimalType.FindAll();
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Id";
        }

        private void btnAddNewOwne_Click(object sender, EventArgs e)
        {

            FrmOwnerData frmOwner = new FrmOwnerData();
            frmOwner.Show();
            frmOwner.FormClosed += new FormClosedEventHandler(frmOwner_FormClosed);
        }

        void frmOwner_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmbOwners.DataSource = Model.Owner.FindAll();
            cmbOwners.DisplayMember = "FirstLastName";
            cmbOwners.ValueMember = "Id";

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(Owner != null)
                this.Owner.Show();

            this.Close();
        }
    }
}
