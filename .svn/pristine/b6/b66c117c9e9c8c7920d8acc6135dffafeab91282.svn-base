using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;

namespace Model
{
    [ActiveRecord("Owners") ]
    public class Owner:ActiveRecordBase<Owner>
    {
        [PrimaryKey(PrimaryKeyType.Native,"OwnerId")]
        public int Id { get; set; }

        [Property("FirstName")]
        public string FirstName { get; set; }

        [Property("LastName")]
        public string LastName { get; set; }

        [Property("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Property("Jmbg")]
        public string Jmbg { get; set; }

        [Property("RegistrationNumberOfProperty")]
        public string RegistrationNumberOfProperty { get; set; }

        [Property("Address")]
        public string Address { get; set; }

        [Property("DateOfEntry")]
        public DateTime DateOfEntry { get; set; }

        [Property("Email")]
        public string Email { get; set; }

        [Property("Visible")]
        public int Visible { get; set; }

        public string FirstLastName 
        {
            get { return FirstName + " " + LastName; }
        }

        [HasMany(typeof(Animal), "OwnerId", "Animals")]
        public IList<Animal> Animals { get; set; }
    }
}
