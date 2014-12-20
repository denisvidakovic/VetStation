
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("Inseminations")]
    public class Insemination:ActiveRecordBase<Insemination>
    {
        [PrimaryKey(PrimaryKeyType.Native,"InseminationId")]
        public int Id { get; set; }

        [Property("Date")]
        public DateTime Date { get; set; }

        [Property("ExpectedSuccess")]
        public int ExpectedSuccess { get; set; }

        [Property("BullName")]
        public string BullName { get; set; }

        [BelongsTo("BullBreedId")]
        public Breed BullBreed { get; set; }

        [BelongsTo("PersonnelId")]
        public Personnel Personnel { get; set; }

        [BelongsTo("AnimalId")]
        public Animal Animal { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }


        public Insemination()
        {
            Date = DateTime.Now;
            ExpectedSuccess = 1;
            BullName = "";
        }
    }
}
