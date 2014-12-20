using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("AnimalTypes")]
    public class AnimalType:ActiveRecordBase<AnimalType>
    {
        [PrimaryKey(PrimaryKeyType.Native,"AnimalTypeId")]
        public int Id { get; set; }

        [Property("Name")]
        public string Name { get; set; }

    }
}
