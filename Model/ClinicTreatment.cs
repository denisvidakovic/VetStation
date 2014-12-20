using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("ClinicTreatments")]
    public class ClinicTreatment:ActiveRecordBase<ClinicTreatment>
    {
        [PrimaryKey(PrimaryKeyType.Native,"ClinicTreatmentsId")]
        public int Id { get; set; }

        [Property("Date")]
        public DateTime Date { get; set; }

        [Property("Diagnosis")]
        public string Diagnosis { get; set; }

        [Property("Therapy")]
        public string Therapy { get; set; }

        [Property("UsedMedicine")]
        public string UsedMedicine { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }

        [BelongsTo("AnimalId")]
        public Animal Animal { get; set; }

        [BelongsTo("PersonnelId")]
        public Personnel Personnel { get; set; }

        public ClinicTreatment()
        {
            Date = DateTime.Now;
            Diagnosis = "";
            Therapy = "";
            UsedMedicine = "";
        }
    }
}
