using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCollections.Models
{
    public class PersonsCollection : IValidatableObject
    {
        public PersonsCollection()
        {
            Persons = new List<Person>();
        }

        public List<Person> Persons { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var item in Persons)
            {
                if (!string.IsNullOrEmpty(item.FirstName))
                {
                    yield return new ValidationResult("Surname is required", new[] { "Persons.Surname" }); // This doesn't put an error message on the view. Is there a way to make this work?
                }
            }
        }
    }
}