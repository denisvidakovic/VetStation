using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace VetStation.CustomDataSources
{
    class DSOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        public string Jmbg { get; set; }
        public string RegNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public static List<DSOwner> ModelToCustomDataSource(IEnumerable<Owner> input)
        {
            List<DSOwner> output = new List<DSOwner>();

            foreach (Owner owner in input)
            {
                DSOwner dsOwner = ModelToCustomDataSource(owner);
                output.Add(dsOwner);
            }
            return output;
        }

        public static DSOwner ModelToCustomDataSource(Owner owner)
        {
            DSOwner dsOwner = new DSOwner
            {
                Id = owner.Id,
                Name = owner.FirstLastName,
                Lname = owner.LastName,
                PhoneNumber = owner.PhoneNumber,
                Jmbg = owner.Jmbg,
                RegNumber = owner.RegistrationNumberOfProperty,
                Address = owner.Address,
                Email = owner.Email
            };
            return dsOwner;
        }
    }
}
