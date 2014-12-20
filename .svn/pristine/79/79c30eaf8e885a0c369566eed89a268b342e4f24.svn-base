using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;

namespace Model
{
    public enum AnimalGender { Male = 1, Female = 2}

    [ActiveRecord("Animals")]
    public class Animal:ActiveRecordBase<Animal>
    {
        [PrimaryKey(PrimaryKeyType.Native,"AnimalId")]
        public int Id { get; set; }

        [Property("Name")]
        public string Name { get; set; }

        [Property("EntryDate")]
        public DateTime EntryDate { get; set; }

        [Property("Gender")]
        public int GenderInt { get; set; }

        public AnimalGender Gender
        {
            get { return (AnimalGender) GenderInt; }
            set { GenderInt = (int) value; }
        }

        [Property("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }

        [Property("Age")]
        public string Age { get; set; }

        [BelongsTo("OwnerId")]
        public Owner Owner { get; set; }

        [BelongsTo("AnimalTypeId")]
        public AnimalType Type { get; set; }

        [BelongsTo("BreedId")]
        public Breed Breed { get; set; }

        public string FromatedName
        {
            get {return "Životinja: " + Name + "; Vlasnik: " + Owner.FirstLastName;
            }
        }

        [HasMany(typeof(Diagnostic),"AnimalId","Diagnostics")]
        public IList<Diagnostic> AnimalDiagnostics { get; set; }

        [HasMany(typeof(Insemination), "AnimalId", "Inseminations")]
        public IList<Insemination> AnimalInsemination { get; set; }

        [HasMany(typeof(ClinicTreatment), "AnimalId", "ClinicTreatments")]
        public IList<ClinicTreatment> ClinicTreatments { get; set; }

        [HasMany(typeof(Vaccination), "AnimalId", "Vaccinations")]
        public IList<Vaccination> AnimalVaccinations { get; set; }

        [HasMany(typeof(DDDMeasure), "AnimalId", "DDDMeasures")]
        public IList<DDDMeasure> DDDMeasures { get; set; }

        public Animal()
        {
            AnimalDiagnostics = new List<Diagnostic>();
            AnimalInsemination = new List<Insemination>();
            ClinicTreatments = new List<ClinicTreatment>();
            AnimalVaccinations = new List<Vaccination>();
            DDDMeasures = new List<DDDMeasure>();
        }

        public static List<Animal> GetAnimalsForOwner(int ownerId)
        {
             List<Animal> animals = new List<Animal>();
            try
            {
                SimpleQuery<Animal> query = new SimpleQuery<Animal>(QueryLanguage.Hql, "from Animal as a where a.Owner.Id =?", ownerId);
                animals = query.Enumerate().ToList();
            }
            catch (Exception ex)
            {
            }
            return animals;
        }
    }
}
