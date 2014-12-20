using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{

    [ActiveRecord("Diagnostics")]
    public class Diagnostic:ActiveRecordBase<Diagnostic>
    {
        [PrimaryKey(PrimaryKeyType.Native,"DiagnosticsId")]
        public int Id { get; set; }

        [Property("SamplingDate")]
        public DateTime SamplingDate { get; set; }

        [Property("BlodExamination")]
        public bool BlodExamination { get; set; }

        [Property("OtherExamination")]
        public bool OtherExamination { get; set; }

        [Property("MilkExamination")]
        public bool MilkExamination { get; set; }

        [Property("ExaminationResult")]
        public bool ExaminationResult { get; set; }

        [Property("ExaminationIllness")]
        public string ExaminationIllness { get; set; }

        public bool ExaminationPositive
        {
            get { return ExaminationResult; }
        }
        public bool ExaminationNegative
        {
            get { return !ExaminationPositive; }
        }
        [Property("ExaminationDate")]
        public DateTime ExaminationDate { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }


        [BelongsTo("PersonnelId")]
        public Personnel Personnel { get; set; }

        [BelongsTo("AnimalId")]
        public Animal Animal { get; set; }

        public Diagnostic()
        {
            SamplingDate = DateTime.Now;
            ExaminationDate = DateTime.Now;
            ExaminationIllness = "";
            
        }
    }
}
