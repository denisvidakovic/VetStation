using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("Personnel") ]
    public class Personnel:ActiveRecordBase<Personnel>
    {
        [PrimaryKey(PrimaryKeyType.Native,"PersonnelId")]
        public int Id { get; set; }

        [Property("FirstName")]
        public string FirstName { get; set; }

        [Property("LastName")]
        public string LastName { get; set; }

        [Property("Title")]
        public string Title { get; set; }

        public string FormatedName
        {
            get { return FirstName + " " + LastName; }
        }

    }
}
