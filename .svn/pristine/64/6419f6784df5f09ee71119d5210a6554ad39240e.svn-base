using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Castle.ActiveRecord;
using Data;
using Model;
using VetStation.BasicInsertForms;
using VetStation.CustomDataSources;
using Timer = System.Windows.Forms.Timer;

enum PDFType
{
    Tuberkulinizacija,
    BrucelozaTbcCmt,
    Vakcinacija,
    MilkCard
}

namespace VetStation
{
    public partial class FrmMain : Form
    {
        private PDFType pdfType;
        private List<string> _ownersNames;
        private Personnel[] _personnel;
        private List<string> _personnelNames;
        private Owner [] _owners;
        private Owner _selectedOwner;
        private Animal _selectedAnimal;
        private DataGridViewCellEventArgs _mouseLocation;
        DataTable tbl = new DataTable();

        private Timer _hideInfoTimer = new Timer();

        public FrmMain()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bs-Latn-BA");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("bs-Latn-BA");
            //if (CheckDummySecurity())
                InitializeComponent();
            //else
            //{
            //    MessageBox.Show("Vasa aplikacija je istekla, molimo vas da kupite citavu verziju ako zelite koristiti program", "Version Application Expired", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //    Application.Exit();
            //}


        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _hideInfoTimer.Tick += new EventHandler(_hideInfoTimer_Tick);
                _hideInfoTimer.Interval = 5000;

                _ownersNames = new List<string>();
                _personnelNames = new List<string>();

                _owners = Model.Owner.FindAllByProperty("Visible", 1);
                _personnel = Personnel.FindAll();
                if(_personnel != null)
                {
                    foreach (Personnel personnel in _personnel)
                    {
                        _personnelNames.Add(personnel.FormatedName);
                    }
                }
                if (_owners != null)
                {
                    foreach (Owner owner in _owners)
                    {
                        _ownersNames.Add(owner.FirstLastName);
                    }
                    HandleUsers(_owners.ToList());
                }

                AutoCompleteStringCollection ownerAutocompleteCollection = new AutoCompleteStringCollection();
                ownerAutocompleteCollection.AddRange(_ownersNames.ToArray());
                txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtName.AutoCompleteCustomSource = ownerAutocompleteCollection;
                txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection personnelAutocompleteCollection = new AutoCompleteStringCollection();
                personnelAutocompleteCollection.AddRange(_personnelNames.ToArray());

                //txtTreatmentPersonel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtTreatmentPersonel.AutoCompleteCustomSource = personnelAutocompleteCollection;
                //txtTreatmentPersonel.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //txtInseminationPersonnel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtInseminationPersonnel.AutoCompleteCustomSource = personnelAutocompleteCollection;
                //txtInseminationPersonnel.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //txtDiagnosticPersonnel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtDiagnosticPersonnel.AutoCompleteCustomSource = personnelAutocompleteCollection;
                //txtDiagnosticPersonnel.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //txtVaccinationPersonnel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtVaccinationPersonnel.AutoCompleteCustomSource = personnelAutocompleteCollection;
                //txtVaccinationPersonnel.AutoCompleteSource = AutoCompleteSource.CustomSource;

                //txtMeasurePersonnel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //txtMeasurePersonnel.AutoCompleteCustomSource = personnelAutocompleteCollection;
                //txtMeasurePersonnel.AutoCompleteSource = AutoCompleteSource.CustomSource;

                Personnel[] p = Personnel.FindAll();
                ddlTreatmentPersonel.DataSource = Personnel.FindAll();
                ddlTreatmentPersonel.DisplayMember = "FormatedName";
                ddlTreatmentPersonel.ValueMember = "Id";

                cmbInseminationPersonnel.DataSource = Personnel.FindAll();
                cmbInseminationPersonnel.DisplayMember = "FormatedName";
                cmbInseminationPersonnel.ValueMember = "Id";

                cmbDiagnosticPersonnel.DataSource = Personnel.FindAll();
                cmbDiagnosticPersonnel.DisplayMember = "FormatedName";
                cmbDiagnosticPersonnel.ValueMember = "Id";

                cmbVaccinationPersonnel.DataSource = Personnel.FindAll();
                cmbVaccinationPersonnel.DisplayMember = "FormatedName";
                cmbVaccinationPersonnel.ValueMember = "Id";

                cmbMeasurePersonnel.DataSource = Personnel.FindAll();
                cmbMeasurePersonnel.DisplayMember = "FormatedName";
                cmbMeasurePersonnel.ValueMember = "Id";                
            }
            catch (Exception ex)
            {
             
            }
        }

        void _hideInfoTimer_Tick(object sender, EventArgs e)
        {
            _hideInfoTimer.Stop();
            lblTreatmentInfo.Visible = false;
            lblOwnerInfo.Visible = false;
            lblVaccinationInfo.Visible = false;
            lblTreatmentInfo.Visible = false;
            lblMeasureInfo.Visible = false;
            lblInseminationInfo.Visible = false;
            lblDiagnosticInfo.Visible = false;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                foreach (Owner owner in _owners)
                {
                    if(owner.FirstLastName.ToLower() == txtName.Text.ToLower())
                    {
                        SetOWnerSource(owner);
                    }
                }
            }
        }
        private List<string> HandleAnimalAge()
        {
            List<string> ages = new List<string>();
            ages.Add("Nepoznato");
            for (int i = 1; i <= 11; i++)
            {
                if (i == 1)
                    ages.Add(i + " mjesec");
                else if (i <= 4)
                    ages.Add(i + " mjeseca");
                else
                    ages.Add(i + " mjeseci");
            }
            for (int i = 1; i <= 10; i++)
            {
                ages.Add(i + " godina");
            }

            ages.Add("Više od 10 godina");

            return ages;
        }
        private void HandleUsers(List<Owner> list)
        {
            if (list.Count > 0)
            {
                bsUsers.DataSource = _owners;
                bnUsers.BindingSource = bsUsers;

                bsUsers.DataSource = list;
                bnUsers.BindingSource = bsUsers;

                txtOwnerId.DataBindings.Clear();
                txtOwnerId.DataBindings.Add("Text", bsUsers, "Id");

                txtIdentificationNumber.DataBindings.Clear();
                txtIdentificationNumber.DataBindings.Add("Text", bsUsers, "Jmbg");

                txtPropertyNumber.DataBindings.Clear();
                txtPropertyNumber.DataBindings.Add("Text", bsUsers, "RegistrationNumberOfProperty");

                txtPropertyNumber.DataBindings.Clear();
                txtPropertyNumber.DataBindings.Add("Text", bsUsers, "RegistrationNumberOfProperty");

                txtName.DataBindings.Clear();
                txtName.DataBindings.Add("Text", bsUsers, "FirstLastName");

                txtAddress.DataBindings.Clear();
                txtAddress.DataBindings.Add("Text", bsUsers, "Address");

                txtPhoneNumber.DataBindings.Clear();
                txtPhoneNumber.DataBindings.Add("Text", bsUsers, "PhoneNumber");

                txtEmail.DataBindings.Clear();
                txtEmail.DataBindings.Add("Text", bsUsers, "Email");

                bsUsers.MoveLast();
                _selectedOwner = (Owner) bsUsers.Current;
                if (_selectedOwner.Animals.Where(a => a.Visible == 1).ToList().Count >= 1)
                {
                    dgvAnimals.DataSource = DSAnimal.ModelToCustomDataSource(_selectedOwner.Animals.Where(a => a.Visible == 1));
                    SetAnimalSource(_selectedOwner.Animals[_selectedOwner.Animals.Where(a => a.Visible == 1).ToList().Count - 1]);
                }
            }
            else
            {
                Owner i = new Owner();
                bsUsers.DataSource = new List<Owner>() { i };
                bnUsers.BindingSource = bsUsers;
            }
        }
        private void SetOWnerSource(Owner owner)
        {
            try
            {
                _selectedOwner = owner;
                bsUsers.Position = _owners.ToList().IndexOf(owner);
                txtOwnerId.Text = owner.Id.ToString();
                txtAddress.Text = owner.Address;
                txtEmail.Text = owner.Email;
                txtIdentificationNumber.Text = owner.Jmbg;
                txtPhoneNumber.Text = owner.PhoneNumber;
                txtPropertyNumber.Text = owner.RegistrationNumberOfProperty;
                txtName.Text = owner.FirstLastName;

                dgvAnimals.DataSource = DSAnimal.ModelToCustomDataSource(owner.Animals.Where(a=>a.Visible == 1));

                if (owner.Animals.Where(a => a.Visible == 1).ToList().Count > 0)
                {
                    SetAnimalSource(owner.Animals.Where(a => a.Visible == 1).ToList()[0]);
                }
                else
                {
                    SetAnimalSource(new Animal());
                }

            }
            catch (Exception ex)
            {
                string h = "";

            }
        }

        private void txtIdentificationNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtIdentificationNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                foreach (Owner owner in _owners)
                {
                    if(owner.Jmbg == txtIdentificationNumber.Text)
                        SetOWnerSource(owner);
                }
            }
        }

        private void dgvAnimals_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            _mouseLocation = e;
        }

        private void dgvAnimals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_mouseLocation.RowIndex >= 0 && _mouseLocation.RowIndex < dgvAnimals.Rows.Count)
            {
                int selectedAnimalId = (int)dgvAnimals.Rows[_mouseLocation.RowIndex].Cells[0].Value;
                if (_selectedOwner != null)
                {
                    foreach (Animal animal in _selectedOwner.Animals)
                    {
                        if (animal.Id == selectedAnimalId)
                            SetAnimalSource(animal);
                    }
                }
            }
            
        }

        private void SetAnimalSource(Animal animal)
        {
            ddlAnimalTypes.DataSource = AnimalType.FindAll();
            ddlAnimalTypes.DisplayMember = "Name";
            ddlAnimalTypes.ValueMember = "Id";

            cmbAnimalBreed.DataSource = Breed.FindAll();
            cmbAnimalBreed.DisplayMember = "Name";
            cmbAnimalBreed.ValueMember = "Id";

            List<string> sex = new List<string>(){"Muški","Ženski"};
            cmbSex.DataSource = sex;
            cmbAnimalAge.DataSource = HandleAnimalAge();
            if (animal.Id != 0)
            {    
                ddlAnimalTypes.SelectedItem = animal.Type;
                _selectedAnimal = animal;
                txtAnimalId.Text = animal.Id.ToString();
                cmbAnimalAge.SelectedItem = animal.Age;
                txtAnimalRn.Text = animal.RegistrationNumber;
                cmbAnimalBreed.SelectedItem = animal.Breed;
                
                txtAnimalName.Text = animal.Name;
                cmbSex.SelectedItem = animal.Gender == AnimalGender.Male ? "Muški" : "Ženski";

            }
            else
            {
                _selectedAnimal = null;
                txtAnimalId.Text = string.Empty;
                txtAnimalRn.Text = string.Empty;
                txtAnimalName.Text = string.Empty;
 
            }

            HandleTreatments(animal.ClinicTreatments.Where(t=>t.Visible == 1).ToList());
            HandleInsemination(animal.AnimalInsemination.Where(t => t.Visible == 1).ToList());
            HandleDiagnostic(animal.AnimalDiagnostics.Where(t => t.Visible == 1).ToList());
            HandleVaccination(animal.AnimalVaccinations.Where(t => t.Visible == 1).ToList());
            HandleDDDMeasures(animal.DDDMeasures.Where(t => t.Visible == 1).ToList()); 
          
        }

        private void HandleInsemination(IList<Insemination> iList)
        {
            cmbBullBreed.DataSource = Breed.FindAll();
            cmbBullBreed.DisplayMember = "Name";
            cmbBullBreed.ValueMember = "Id";

            cmbExpectedSuccess.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                cmbExpectedSuccess.Items.Add(i);
            }

            cmbExpectedSuccess.ValueMember = "";
            cmbExpectedSuccess.SelectedItem = 1;
            if (iList.Count > 0)
            {
                bsInsemination.DataSource = iList;
                bnInsemination.BindingSource = bsInsemination;



                cmbExpectedSuccess.DataBindings.Clear();
                cmbExpectedSuccess.DataBindings.Add("SelectedItem", bsInsemination, "ExpectedSuccess");


                txtBullName.DataBindings.Clear();
                txtBullName.DataBindings.Add("Text", bsInsemination, "BullName");


                cmbBullBreed.DataBindings.Clear();
                cmbBullBreed.DataBindings.Add("SelectedValue", bsInsemination, "BullBreed.Id");
                bsInsemination.MoveLast();
            }
            else
            {
                Insemination i = new Insemination();
                bsInsemination.DataSource = new List<Insemination>(){i};
                bnInsemination.BindingSource = bsInsemination;
            }
           
        }

        private void HandleTreatments(IList<ClinicTreatment> iList)
        {
            if (iList.Count > 0)
            {
                bsClinicTreatments.DataSource = iList;
                bnTreatments.BindingSource = bsClinicTreatments;

                txtDiagnosis.DataBindings.Clear();
                txtDiagnosis.DataBindings.Add("Text", bsClinicTreatments, "Diagnosis");

                txtTherapy.DataBindings.Clear();
                txtTherapy.DataBindings.Add("Text", bsClinicTreatments, "Therapy");

                txtMedicine.DataBindings.Clear();
                txtMedicine.DataBindings.Add("Text", bsClinicTreatments, "UsedMedicine");

                dtpTreatments.DataBindings.Clear();
                dtpTreatments.DataBindings.Add("Value", bsClinicTreatments, "Date");

              
                ddlTreatmentPersonel.DataBindings.Clear();
                ddlTreatmentPersonel.DataBindings.Add("SelectedValue", bsClinicTreatments, "Personnel.Id");

                bsClinicTreatments.MoveLast(); 
            }
            else
            {
                ClinicTreatment c = new ClinicTreatment();
                bsClinicTreatments.DataSource = new List<ClinicTreatment>(){c};
                bnTreatments.BindingSource = bsClinicTreatments;
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (_selectedAnimal != null)
            {
                
                ClinicTreatment ct = new ClinicTreatment();
                _selectedAnimal.ClinicTreatments.Add(ct);
                HandleTreatments(_selectedAnimal.ClinicTreatments);
            }
        }

        private void btnTreatmentSave_Click(object sender, EventArgs e)
        {
            Personnel personnel =(Personnel) ddlTreatmentPersonel.SelectedItem;
            if(_selectedAnimal == null)
            {
                lblTreatmentInfo.Text = "* Molimo izaberite životinju";
                lblTreatmentInfo.Visible = true;
                _hideInfoTimer.Start();
                return;
            }
            if (personnel != null)
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            ClinicTreatment ct = (ClinicTreatment)bsClinicTreatments.Current;
                            if(ct == null)
                                ct = new ClinicTreatment();
                            ct.Date = dtpTreatments.Value;
                            ct.Diagnosis = txtDiagnosis.Text;
                            ct.Therapy = txtTherapy.Text;
                            ct.UsedMedicine = txtMedicine.Text;
                            ct.Animal = _selectedAnimal;
                            ct.Personnel = personnel;
                            ct.Visible = 1;
                            ct.Save();
                            ts.VoteCommit();
                            lblTreatmentInfo.Visible = true;
                            lblTreatmentInfo.Text = "* Podaci uspješno snimljeni";

                            if (!_selectedAnimal.ClinicTreatments.Contains(ct))
                            {
                                _selectedAnimal.ClinicTreatments.Add(ct);
                                HandleTreatments(_selectedAnimal.ClinicTreatments);
                            }
                        }
                        catch (Exception ex)
                        {
                            lblTreatmentInfo.Text = "* Doslo je do greške.";
                           
                        }
                    }

                }
            }
            else
            {
                lblTreatmentInfo.Text = "* Molimo izaberite izvršioca";
            }

            lblTreatmentInfo.Visible = true;
            _hideInfoTimer.Start();
        }

        private void btnInseminationSave_Click(object sender, EventArgs e)
        {
            Personnel personnel = (Personnel) cmbInseminationPersonnel.SelectedItem;
            if(_selectedAnimal == null)
            {
                lblInseminationInfo.Visible = true;
                _hideInfoTimer.Start();
                lblInseminationInfo.Text = "* Molimo izaberite životinju";
                return;
            }
            if (personnel != null)
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            Insemination i = (Insemination)bsInsemination.Current;
                            if(i == null)
                                i = new Insemination();

                            i.Date = dtpTreatments.Value;
                            i.BullBreed = (Breed) cmbBullBreed.SelectedItem;
                            i.BullName = txtBullName.Text;
                            i.ExpectedSuccess = (int) cmbExpectedSuccess.SelectedItem;
                            i.Animal = _selectedAnimal;
                            i.Personnel = personnel;
                            i.Visible = 1;
                            i.Save();
                            ts.VoteCommit();
                            lblInseminationInfo.Visible = true;
                            lblInseminationInfo.Text = "* Podaci uspješno snimljeni";
                            
                            if(!_selectedAnimal.AnimalInsemination.Contains(i))
                            {
                                _selectedAnimal.AnimalInsemination.Add(i);
                                HandleInsemination(_selectedAnimal.AnimalInsemination);
                            }
                        }
                        catch (Exception ex)
                        {
                            lblInseminationInfo.Text = "* Doslo je do greške.";
                         
                        }
                    }

                }
            }
            else
            {
                lblInseminationInfo.Text = "* Molimo izaberite izvršioca";

            }

            lblInseminationInfo.Visible = true;
            _hideInfoTimer.Start();
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            if (_selectedAnimal != null)
            {
                Insemination i = new Insemination();
                _selectedAnimal.AnimalInsemination.Add(i);
                HandleInsemination(_selectedAnimal.AnimalInsemination);
            }
        }

        private void bindingNavigatorAddNewItem2_Click(object sender, EventArgs e)
        {
            if(_selectedAnimal != null)
            {
                Diagnostic d = new Diagnostic();
                _selectedAnimal.AnimalDiagnostics.Add(d);
                HandleDiagnostic(_selectedAnimal.AnimalDiagnostics);
            }
        }

        private void HandleDiagnostic(IList<Diagnostic> iList)
        {
           if(iList.Count > 0)
           {
               bsDiagnostic.DataSource = iList;
               bnDiagnostic.BindingSource = bsDiagnostic;

               dtpDiagnostic.DataBindings.Clear();
               dtpDiagnostic.DataBindings.Add("Value", bsDiagnostic, "SamplingDate");

               dtpDiagnosticExaminationDate.DataBindings.Clear();
               dtpDiagnosticExaminationDate.DataBindings.Add("Value", bsDiagnostic, "ExaminationDate");

               chkBlod.DataBindings.Clear();
               chkBlod.DataBindings.Add("Checked", bsDiagnostic, "BlodExamination");

               chkMilk.DataBindings.Clear();
               chkMilk.DataBindings.Add("Checked", bsDiagnostic, "MilkExamination");

               chkOther.DataBindings.Clear();
               chkOther.DataBindings.Add("Checked", bsDiagnostic, "OtherExamination");

               rbPositive.DataBindings.Clear();
               rbPositive.DataBindings.Add("Checked", bsDiagnostic, "ExaminationPositive");

               rbNegative.DataBindings.Clear();
               rbNegative.DataBindings.Add("Checked", bsDiagnostic, "ExaminationNegative");


               cmbDiagnosticPersonnel.DataBindings.Clear();
               cmbDiagnosticPersonnel.DataBindings.Add("SelectedItem", bsDiagnostic, "Personnel.Id");
               
               bsDiagnostic.MoveLast();
           }
           else
           {
               Diagnostic d = new Diagnostic();
               bsDiagnostic.DataSource = new List<Diagnostic>(){d};
               bnDiagnostic.BindingSource = bsDiagnostic;
           }
        }

        private void btnDiagnosticSave_Click(object sender, EventArgs e)
        {
            Personnel personnel = (Personnel)cmbDiagnosticPersonnel.SelectedItem;
            if (_selectedAnimal == null)
            {
                lblDiagnosticInfo.Visible = true;
                _hideInfoTimer.Start();
                lblDiagnosticInfo.Text = "* Molimo izaberite životinju";
                return;
            }
            if (personnel != null)
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            Diagnostic d = (Diagnostic)bsDiagnostic.Current;
                            if (d == null)
                                d = new Diagnostic();

                            d.ExaminationIllness = txtExaminationIllness.Text;
                            d.BlodExamination = chkBlod.Checked;
                            d.MilkExamination = chkMilk.Checked;
                            d.OtherExamination = chkOther.Checked;
                            d.ExaminationResult = rbPositive.Checked;
                            d.ExaminationDate = dtpDiagnosticExaminationDate.Value;
                            d.SamplingDate = dtpDiagnostic.Value;
                            d.Animal = _selectedAnimal;
                            d.Personnel = personnel;
                            d.Visible = 1;
                            d.Save();
                            ts.VoteCommit();
                            lblDiagnosticInfo.Visible = true;
                            lblDiagnosticInfo.Text = "* Podaci uspješno snimljeni";

                            if (!_selectedAnimal.AnimalDiagnostics.Contains(d))
                            {
                                _selectedAnimal.AnimalDiagnostics.Add(d);
                                HandleDiagnostic(_selectedAnimal.AnimalDiagnostics);
                            }
                        }
                        catch (Exception ex)
                        {
                            lblDiagnosticInfo.Text = "* Doslo je do greške.";

                        }
                    }

                }
            }
            else
            {
                lblDiagnosticInfo.Text = "* Molimo izaberite izvršioca";
   
            }

            lblDiagnosticInfo.Visible = true;
            _hideInfoTimer.Start();
        }

        private void bindingNavigatorAddNewItem3_Click(object sender, EventArgs e)
        {
            if (_selectedAnimal != null)
            {
                Vaccination v = new Vaccination();
                _selectedAnimal.AnimalVaccinations.Add(v);
                HandleVaccination(_selectedAnimal.AnimalVaccinations);
            }
        }

        private void HandleVaccination(IList<Vaccination> iList)
        {

            if (iList.Count > 0)
            {
                bsVaccination.DataSource = iList;
                bnVaccination.BindingSource = bsVaccination;

                dtpVaccination.DataBindings.Clear();
                dtpVaccination.DataBindings.Add("Value", bsVaccination, "Date");

                txtUsedMedicament.DataBindings.Clear();
                txtUsedMedicament.DataBindings.Add("Text", bsVaccination, "UsedMedicament");

                txtVaccinationFor.DataBindings.Clear();
                txtVaccinationFor.DataBindings.Add("Text", bsVaccination, "VacinationFor");

                txtPlace.DataBindings.Clear();
                txtPlace.DataBindings.Add("Text", bsVaccination, "Place");

                cmbVaccinationPersonnel.DataBindings.Clear();
                cmbVaccinationPersonnel.DataBindings.Add("SelectedValue", bsVaccination, "Personnel.Id");
                
                bsVaccination.MoveLast();
            }
            else
            {   Vaccination v = new Vaccination();
                bsVaccination.DataSource = new List<Vaccination>(){v};
                bnVaccination.BindingSource = bsVaccination;
            }
        }

        private void btnVaccinationSave_Click(object sender, EventArgs e)
        {
            Personnel personnel = (Personnel) cmbVaccinationPersonnel.SelectedItem;
            if (_selectedAnimal == null)
            {
                lblVaccinationInfo.Visible = true;
                _hideInfoTimer.Start();
                lblVaccinationInfo.Text = "* Molimo izaberite životinju";
                return;
            }
            if (personnel != null)
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            Vaccination v = (Vaccination)bsVaccination.Current;
                            if (v == null)
                                v = new Vaccination();

                            v.Place = txtPlace.Text;
                            v.UsedMedicament = txtUsedMedicament.Text;
                            v.VacinationFor = txtVaccinationFor.Text;
                            v.Date = dtpVaccination.Value;
                            v.Animal = _selectedAnimal;
                            v.Personnel = personnel;
                            v.Visible = 1;
                            v.Save();
                            ts.VoteCommit();
                            lblVaccinationInfo.Visible = true;
                            lblVaccinationInfo.Text = "* Podaci uspješno snimljeni";

                            if (!_selectedAnimal.AnimalVaccinations.Contains(v))
                            {
                                _selectedAnimal.AnimalVaccinations.Add(v);
                                HandleVaccination(_selectedAnimal.AnimalVaccinations);
                            }
                        }
                        catch (Exception ex)
                        {

                            lblVaccinationInfo.Text = "* Doslo je do greške.";
                        }
                    }

                }
            }
            else
            {
                lblVaccinationInfo.Text = "* Molimo izaberite izvršioca";
            }

            lblVaccinationInfo.Visible = true;
            _hideInfoTimer.Start();
        }

        private void bindingNavigatorAddNewItem4_Click(object sender, EventArgs e)
        {
            if (_selectedAnimal != null)
            {
                DDDMeasure measure = new DDDMeasure();
                _selectedAnimal.DDDMeasures.Add(measure);
                HandleDDDMeasures(_selectedAnimal.DDDMeasures);
            }
        }

        private void HandleDDDMeasures(IList<DDDMeasure> iList)
        {
            if (iList.Count > 0)
            {
                bsMeasures.DataSource = iList;
                bnMeasures.BindingSource = bsMeasures;

                dtpMeasuers.DataBindings.Clear();
                dtpMeasuers.DataBindings.Add("Value", bsMeasures, "Date");

                txtMeasureName.DataBindings.Clear();
                txtMeasureName.DataBindings.Add("Text", bsMeasures, "MeasureName");

                txtMeasureType.DataBindings.Clear();
                txtMeasureType.DataBindings.Add("Text", bsMeasures, "MeasureType");

                txtUsedRemedy.DataBindings.Clear();
                txtUsedRemedy.DataBindings.Add("Text", bsMeasures, "UsedRemedy");

                txtMeasurePlace.DataBindings.Clear();
                txtMeasurePlace.DataBindings.Add("Text", bsMeasures, "Place");

                cmbMeasurePersonnel.DataBindings.Clear();
                cmbMeasurePersonnel.DataBindings.Add("SelectedValue", bsVaccination, "Personnel.Id");

                bsMeasures.MoveLast();
            }
            else
            {
                DDDMeasure measure = new DDDMeasure();
                bsMeasures.DataSource = new List<DDDMeasure>() { measure };
                bnMeasures.BindingSource = bsMeasures;
            }
        }

        private void btnMeasureSave_Click(object sender, EventArgs e)
        {
            Personnel personnel = (Personnel) cmbMeasurePersonnel.SelectedItem;
            if (_selectedAnimal == null)
            {
                lblMeasureInfo.Visible = true;
                _hideInfoTimer.Start();
                lblMeasureInfo.Text = "* Molimo izaberite životinju";
                return;
            }
            if (personnel != null)
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            DDDMeasure measure = (DDDMeasure)bsMeasures.Current;
                            if (measure == null)
                                measure = new DDDMeasure();

                            measure.Place = txtPlace.Text;
                            measure.MeasureName = txtMeasureName.Text;
                            measure.MeasureType = txtMeasureType.Text;
                            measure.Date = dtpMeasuers.Value;
                            measure.Place = txtMeasurePlace.Text;
                            measure.UsedRemedy = txtUsedRemedy.Text;
                            measure.Visible = 1;
                            measure.Animal = _selectedAnimal;
                            measure.Personnel = personnel;
                            measure.Visible = 1;
                            measure.Save();
                            ts.VoteCommit();
                            lblMeasureInfo.Visible = true;
                            lblMeasureInfo.Text = "* Podaci uspješno snimljeni";

                            if (!_selectedAnimal.DDDMeasures.Contains(measure))
                            {
                                _selectedAnimal.DDDMeasures.Add(measure);
                                HandleDDDMeasures(_selectedAnimal.DDDMeasures);
                            }
                        }
                        catch (Exception ex)
                        {

                            lblMeasureInfo.Text = "* Doslo je do greške.";
                        }
                    }

                }
            }
            else
            {
                lblMeasureInfo.Text = "* Molimo izaberite izvršioca";
            }

            lblMeasureInfo.Visible = true;
            _hideInfoTimer.Start();
        }

        private void btnSaveOwnerChanges_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim() == "" || txtName.Text.Split(' ').Length < 2)
            {
                lblOwnerInfo.Visible = true;
                lblOwnerInfo.Text = "*Ime i prezime nepravilno popunjeno";
                _hideInfoTimer.Start();
                return;
            }
            if(_selectedOwner != null)
            {
                using (SessionScope sc = new SessionScope())
                {
                    using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                    {
                        try
                        {
                            _selectedOwner.Address = txtAddress.Text;
                            _selectedOwner.Email = txtEmail.Text;
                            _selectedOwner.FirstName = txtName.Text.Split(' ')[0];
                            _selectedOwner.LastName = txtName.Text.Split(' ')[1];

                            if (txtIdentificationNumber.Text.Replace("_", "").Length == 13)
                                _selectedOwner.Jmbg = txtIdentificationNumber.Text;
                            _selectedOwner.PhoneNumber = txtPhoneNumber.Text;
                            _selectedOwner.RegistrationNumberOfProperty = txtPropertyNumber.Text;
                            
                            _selectedOwner.Save();
                            ts.VoteCommit();
                            lblOwnerInfo.Visible = true;
                            lblOwnerInfo.Text = "* Podaci uspješno snimljeni";
                        }
                        catch (Exception ex)
                        {
                            lblMeasureInfo.Text = "* Doslo je do greške.";
                        }
                    }
                }
            }
            _hideInfoTimer.Start();
        }

        private void btnAddNewOwner_Click(object sender, EventArgs e)
        {
            FrmOwnerData frmOwnerData = new FrmOwnerData();
            frmOwnerData.Show();
            frmOwnerData.Closing += new CancelEventHandler(frmOwnerData_Closing);
        }

        void frmOwnerData_Closing(object sender, CancelEventArgs e)
        {
            _owners = Model.Owner.FindAllByProperty("Visible", 1);
            _selectedOwner = _owners[_owners.Length - 1];
            _ownersNames.Clear();
            foreach (Owner owner in _owners)
            {
                _ownersNames.Add(owner.FirstLastName);
            }
            txtName.AutoCompleteCustomSource.Clear();
            AutoCompleteStringCollection ownerAutocompleteCollection = new AutoCompleteStringCollection();
            ownerAutocompleteCollection.AddRange(_ownersNames.ToArray());
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteCustomSource = ownerAutocompleteCollection;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //SetOWnerSource(_selectedOwner);
            HandleUsers(_owners.ToList());
        }

        private void btnAddNewAnimal_Click(object sender, EventArgs e)
        {
            FrmAnimalData frmAnimalData = new FrmAnimalData();
            frmAnimalData.Show();
            frmAnimalData.Closing += new CancelEventHandler(frmAnimalData_Closing);
        }

        void frmAnimalData_Closing(object sender, CancelEventArgs e)
        {
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (_selectedOwner != null)
                    {
                        _selectedOwner.Animals = Model.Owner.Find(_selectedOwner.Id).Animals.Where(a=>a.Visible==1).ToList();
                        if (_selectedOwner.Animals.Count >= 1)
                        {
                            dgvAnimals.DataSource = DSAnimal.ModelToCustomDataSource(_selectedOwner.Animals.Where(a => a.Visible == 1));
                            if(_selectedAnimal == null)
                                _selectedAnimal = _selectedOwner.Animals[_selectedOwner.Animals.Count - 1];
                            SetAnimalSource(_selectedAnimal);
                        }

                    }
                }
            }
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            switch (pdfType)
            {
                case PDFType.Tuberkulinizacija:
                    btnCreatePDF_Tuberkulinizacija_Click(sender, e);
                    break;
                case PDFType.BrucelozaTbcCmt:
                    btnCreatePDF_Bruceloza_Click(sender, e);
                    break;
                case PDFType.Vakcinacija:
                    btnCreatePDF_Vakcinacija_Click(sender, e);
                    break;
                case PDFType.MilkCard:
                    btnCreatePDF_MilkCard_Click(sender, e);
                    break;
            }
        }

        private void btnCreatePDF_Tuberkulinizacija_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Adobe PDF (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".pdf"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            PDFHelper pdfHelper = new PDFHelper();
                            pdfHelper.CreatePdfTuberkulinizacija(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreatePDF_Bruceloza_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Adobe PDF (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".pdf"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            PDFHelper pdfHelper = new PDFHelper();
                            pdfHelper.CreatePdfBruceloza(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreatePDF_Vakcinacija_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Adobe PDF (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".pdf"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            PDFHelper pdfHelper = new PDFHelper();
                            pdfHelper.CreatePdfVakcinacija(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreatePDF_MilkCard_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Adobe PDF (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".pdf"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            PDFHelper pdfHelper = new PDFHelper();
                            pdfHelper.CreatePdfMilkCard(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreateExcel_Click(object sender, EventArgs e)
        {
            switch (pdfType)
            {
                case PDFType.Tuberkulinizacija:
                    btnCreateExcel_Tuberkulinizacija(sender, e);
                    break;
                case PDFType.BrucelozaTbcCmt:
                    btnCreateExcel_Bruceloza(sender, e);
                    break;
                case PDFType.Vakcinacija:
                    btnCreateExcel_Vakcinacija(sender, e);
                    break;
                case PDFType.MilkCard:
                    btnCreateExcel_MilkCard(sender, e);
                    break;
            }
        }

        private void btnCreateExcel_Tuberkulinizacija(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".xls"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            ExcelHelper excelHelper = new ExcelHelper();
                            excelHelper.CreateExcelTuberkulinizacija(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreateExcel_Bruceloza(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".xls"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            ExcelHelper excelHelper = new ExcelHelper();
                            excelHelper.CreateExcelBruceloza(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreateExcel_Vakcinacija(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".xls"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            ExcelHelper excelHelper = new ExcelHelper();
                            excelHelper.CreateExcelVakcinacija(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnCreateExcel_MilkCard(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog1.FileName.Equals(String.Empty))
                {
                    FileInfo f = new FileInfo(saveFileDialog1.FileName);
                    if (f.Extension.Equals(".xls"))
                    {
                        if (tbl.Rows.Count > 0)
                        {
                            ExcelHelper excelHelper = new ExcelHelper();
                            excelHelper.CreateExcelMilkCard(saveFileDialog1.FileName, tbl);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file type");
                    }
                }
                else
                {
                    MessageBox.Show("You did pick a location " + "to save file to");
                }
            }
        }

        private void btnClearGridView_Click(object sender, EventArgs e)
        {
            if (dGVSerchResults.Rows.Count > 0)
                dGVSerchResults.DataSource = null;

            tbl = null;
            tbl = new DataTable();
        }

        private void txtSpecSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreatePDF_Click(sender, e);
            }
        }

        bool CheckDummySecurity()
        {
            bool enableApplication = true;
            DateTime checkDate = new DateTime(2012, 4, 12);
            try
            {
                WebRequest req = WebRequest.Create("http://www.earthtools.org/timezone-1.1/17.803888/43.346111");
                WebResponse resp = req.GetResponse();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(resp.GetResponseStream());
                foreach (XmlNode childNode in xmlDocument.ChildNodes)
                {
                    if (childNode.Name == "timezone")
                    {
                        foreach (XmlNode xmlNode in childNode.ChildNodes)
                        {
                            if (xmlNode.Name == "utctime")
                            {
                                DateTime time = DateTime.ParseExact(xmlNode.InnerText, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
                                if (checkDate.AddDays(10) < time)
                                    enableApplication = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (checkDate.AddDays(10) < DateTime.UtcNow)
                    enableApplication = false;
            }

            return enableApplication;
        }

        private void dateTimeOwnerCreationPicker_ValueChanged(object sender, EventArgs e)
        {
            DirectDataAccess.GetOwnersByCreationDate(tbl, dateTimeOwnerCreationPicker.Value.Date.ToShortDateString());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _owners = Model.Owner.FindAllByProperty("Visible", 1);
            HandleUsers(_owners.ToList());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if(_selectedOwner != null)
                    {
                        _selectedOwner.Visible = 0;
                        _selectedOwner.Save();

                        ts.VoteCommit();
                    }

                }
            }
            _owners = Model.Owner.FindAllByProperty("Visible", 1);
            _selectedOwner = _owners[_owners.Length - 1];
            _ownersNames.Clear();
            foreach (Owner owner in _owners)
            {
                _ownersNames.Add(owner.FirstLastName);
            }
            txtName.AutoCompleteCustomSource.Clear();
            AutoCompleteStringCollection ownerAutocompleteCollection = new AutoCompleteStringCollection();
            ownerAutocompleteCollection.AddRange(_ownersNames.ToArray());
            txtName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName.AutoCompleteCustomSource = ownerAutocompleteCollection;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //SetOWnerSource(_selectedOwner);
            HandleUsers(_owners.ToList());
        }

        private void btnDeleteAnimal_Click(object sender, EventArgs e)
        {
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (_selectedAnimal != null)
                    {
                        _selectedAnimal.Visible = 0;
                        _selectedAnimal.Save();

                        ts.VoteCommit();
                    }
                }
            }

            List<Animal> visibleAnimals = _selectedOwner.Animals.Where(a => a.Visible == 1).ToList();
            List<DSAnimal> animals = DSAnimal.ModelToCustomDataSource(visibleAnimals);
            dgvAnimals.DataSource = animals;

            if (visibleAnimals.Count > 0)
            {
                SetAnimalSource(visibleAnimals[0]);
            }
            else
            {
                SetAnimalSource(new Animal());
            }
        }

        private void bindingNavigatorMoveNextItem5_Click(object sender, EventArgs e)
        {
            Owner sOwner = (Owner) bsUsers.Current;
            if(sOwner != null)
            {
                _selectedOwner = sOwner;
                SetOWnerSource(_selectedOwner);   
            }
        }

        private void bindingNavigatorMovePreviousItem5_Click(object sender, EventArgs e)
        {
            Owner sOwner = (Owner)bsUsers.Current;
            if (sOwner != null)
            {
                _selectedOwner = sOwner;
                SetOWnerSource(_selectedOwner);
            }
        }

        private void bindingNavigatorMoveLastItem5_Click(object sender, EventArgs e)
        {
            Owner sOwner = (Owner)bsUsers.Current;
            if (sOwner != null)
            {
                _selectedOwner = sOwner;
                SetOWnerSource(_selectedOwner);
            }
        }

        private void bindingNavigatorMoveFirstItem5_Click(object sender, EventArgs e)
        {
            Owner sOwner = (Owner)bsUsers.Current;
            if (sOwner != null)
            {
                _selectedOwner = sOwner;
                SetOWnerSource(_selectedOwner);
            }
        }

        private void btnSaveAnimal_Click(object sender, EventArgs e)
        {
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (_selectedAnimal != null)
                    {
                        if (ddlAnimalTypes.SelectedItem != null)
                            _selectedAnimal.Type = (AnimalType) ddlAnimalTypes.SelectedItem;

                        _selectedAnimal.Name = txtAnimalName.Text;

                        if (cmbSex.SelectedItem != null)
                            _selectedAnimal.Gender =(string) cmbSex.SelectedItem == "Muški"
                                                     ? AnimalGender.Male
                                                     : AnimalGender.Female;

                        if (cmbAnimalAge.SelectedItem != null)
                            _selectedAnimal.Age = cmbAnimalAge.SelectedItem.ToString();

                        _selectedAnimal.RegistrationNumber = txtAnimalRn.Text;

                        _selectedAnimal.Save();

                        ts.VoteCommit();
                    }
                }
            }
        }

        private void btnTratmentsDelete_Click(object sender, EventArgs e)
        {
            ClinicTreatment treatment = (ClinicTreatment)bsClinicTreatments.Current;
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (treatment != null)
                    {
                        treatment.Visible = 0;
                        treatment.Save();

                        ts.VoteCommit();
                    }

                }
            }
            if(_selectedAnimal != null)
            {
                _selectedAnimal.ClinicTreatments = ClinicTreatment.FindAllByProperty("Visible", 1);
                HandleTreatments(_selectedAnimal.ClinicTreatments);
            }
        }

        private void btnInseminationDelete_Click(object sender, EventArgs e)
        {
            Insemination insemination = (Insemination)bsInsemination.Current;
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (insemination != null)
                    {
                        insemination.Visible = 0;
                        insemination.Save();

                        ts.VoteCommit();
                    }

                }
            }
            if (_selectedAnimal != null)
            {
                _selectedAnimal.AnimalInsemination = Insemination.FindAllByProperty("Visible", 1);
                HandleInsemination(_selectedAnimal.AnimalInsemination);
            }
        }

        private void btnDiagnosticDelete_Click(object sender, EventArgs e)
        {
            Diagnostic diagnostic = (Diagnostic)bsDiagnostic.Current;
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (diagnostic != null)
                    {
                        diagnostic.Visible = 0;
                        diagnostic.Save();

                        ts.VoteCommit();
                    }

                }
            }
            if (_selectedAnimal != null)
            {
                _selectedAnimal.AnimalDiagnostics = Diagnostic.FindAllByProperty("Visible", 1);
                HandleDiagnostic(_selectedAnimal.AnimalDiagnostics);
            }
        }

        private void btnVavinnationDelete_Click(object sender, EventArgs e)
        {
            Vaccination vaccination = (Vaccination)bsVaccination.Current;
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (vaccination != null)
                    {
                        vaccination.Visible = 0;
                        vaccination.Save();

                        ts.VoteCommit();
                    }

                }
            }
            if (_selectedAnimal != null)
            {
                _selectedAnimal.AnimalVaccinations = Vaccination.FindAllByProperty("Visible", 1);
                HandleVaccination(_selectedAnimal.AnimalVaccinations);
            }
        }

        private void btnMeasuresDelete_Click(object sender, EventArgs e)
        {
            DDDMeasure measure = (DDDMeasure)bsVaccination.Current;
            using (SessionScope sc = new SessionScope())
            {
                using (TransactionScope ts = new TransactionScope(OnDispose.Rollback))
                {
                    if (measure != null)
                    {
                        measure.Visible = 0;
                        measure.Save();

                        ts.VoteCommit();
                    }

                }
            }
            if (_selectedAnimal != null)
            {
                _selectedAnimal.DDDMeasures = DDDMeasure.FindAllByProperty("Visible", 1);
                HandleDDDMeasures(_selectedAnimal.DDDMeasures);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPersonnelData frm = new FrmPersonnelData();
            frm.Show();
            frm.Closed += new EventHandler(frm_Closed);
        }

        void frm_Closed(object sender, EventArgs e)
        {
            Personnel[] p = Personnel.FindAll();
            ddlTreatmentPersonel.DataSource = Personnel.FindAll();
            ddlTreatmentPersonel.DisplayMember = "FormatedName";
            ddlTreatmentPersonel.ValueMember = "Id";

            cmbInseminationPersonnel.DataSource = Personnel.FindAll();
            cmbInseminationPersonnel.DisplayMember = "FormatedName";
            cmbInseminationPersonnel.ValueMember = "Id";

            cmbDiagnosticPersonnel.DataSource = Personnel.FindAll();
            cmbDiagnosticPersonnel.DisplayMember = "FormatedName";
            cmbDiagnosticPersonnel.ValueMember = "Id";

            cmbVaccinationPersonnel.DataSource = Personnel.FindAll();
            cmbVaccinationPersonnel.DisplayMember = "FormatedName";
            cmbVaccinationPersonnel.ValueMember = "Id";

            cmbMeasurePersonnel.DataSource = Personnel.FindAll();
            cmbMeasurePersonnel.DisplayMember = "FormatedName";
            cmbMeasurePersonnel.ValueMember = "Id";
        }

        private void btnGovedaTuberkulinizacija_Click(object sender, EventArgs e)
        {
            if (dGVSerchResults.Rows.Count > 0)
                dGVSerchResults.DataSource = null;

            tbl = null;
            tbl = new DataTable();

            DirectDataAccess.GetTuberkulinizaciju(tbl);
            pdfType = PDFType.Tuberkulinizacija;

            dGVSerchResults.DataSource = tbl;
        }

        private void bindingNavigatorAddNewItem4_Click_1(object sender, EventArgs e)
        {
            if (_selectedAnimal != null)
            {
                DDDMeasure measure = new DDDMeasure();
                _selectedAnimal.DDDMeasures.Add(measure);
                HandleDDDMeasures(_selectedAnimal.DDDMeasures);
            }
        }

        private void Bruceloza_Click(object sender, EventArgs e)
        {
            if (dGVSerchResults.Rows.Count > 0)
                dGVSerchResults.DataSource = null;

            tbl = null;
            tbl = new DataTable();

            DirectDataAccess.GetBrucelozu(tbl);
            pdfType = PDFType.BrucelozaTbcCmt;

            dGVSerchResults.DataSource = tbl;
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            if (dGVSerchResults.Rows.Count > 0)
                dGVSerchResults.DataSource = null;

            tbl = null;
            tbl = new DataTable();

            DirectDataAccess.GetVakcinacija(tbl);
            pdfType = PDFType.Vakcinacija;

            dGVSerchResults.DataSource = tbl;
        }

        private void btnMilkCard_Click(object sender, EventArgs e)
        {
            if (dGVSerchResults.Rows.Count > 0)
                dGVSerchResults.DataSource = null;

            tbl = null;
            tbl = new DataTable();

            DirectDataAccess.GetMilkCard(tbl);
            pdfType = PDFType.MilkCard;

            dGVSerchResults.DataSource = tbl;
        }
    }
}
