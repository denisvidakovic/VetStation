using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("DDDMeasures")]
    public class DDDMeasure:ActiveRecordBase<DDDMeasure>
    {
        [PrimaryKey(PrimaryKeyType.Native, "DDDMeasureId")]
        public int Id { get; set; }

        [Property("Date")]
        public DateTime Date { get; set; }

        [Property("MeasureName")]
        public string MeasureName { get; set; }

        [Property("MeasureType")]
        public string MeasureType { get; set; }

        [Property("Place")]
        public string Place { get; set; }

        [Property("UsedRemedy")]
        public string UsedRemedy { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }

        [BelongsTo("AnimalId")]
        public Animal Animal { get; set; }

        [BelongsTo("PersonnelId")]
        public Personnel Personnel { get; set; }

        public DDDMeasure()
        {
            Date = DateTime.Now;
            MeasureName = "";
            MeasureType = "";
            Place = "";
            UsedRemedy = "";
        }
    }
}
