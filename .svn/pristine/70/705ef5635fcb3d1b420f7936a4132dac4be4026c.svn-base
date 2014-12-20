using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("Vaccinations")]
    public class Vaccination:ActiveRecordBase<Vaccination>
    {
        [PrimaryKey(PrimaryKeyType.Native,"VaccinationsId")]
        public int Id { get; set; }

        [Property("Date")]
        public DateTime Date { get; set; }

        [Property("UsedMedicament")]
        public string UsedMedicament { get; set; }

        [Property("VaccinationFor")]
        public string VacinationFor { get; set; }

        [Property("Place")]
        public string Place { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }

        [BelongsTo("AnimalId")]
        public Animal Animal { get; set; }

        [BelongsTo("PErsonnelId")]
        public Personnel Personnel { get; set; }


        public Vaccination()
        {
            Date = DateTime.Now;
            UsedMedicament = "";
            VacinationFor = "";
            Place = "";
        }
    }
}
