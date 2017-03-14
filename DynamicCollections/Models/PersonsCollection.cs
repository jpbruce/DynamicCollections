using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCollections.Models
{
    public class PersonsCollection
    {
        public PersonsCollection()
        {
            Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }
    }
}
