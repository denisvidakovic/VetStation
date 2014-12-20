using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("Breeds")]
    public class Breed : ActiveRecordBase<Breed>
    {
        [PrimaryKey(PrimaryKeyType.Native,"BreedId")]
        public int Id { get; set; }

        [Property("Name")]
        public string Name { get; set; }
        
    }
}
