using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DynamicCollections.Models
{
    public class PersonsViewModel
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public void PostPersons()
        {
            foreach (Person thisPerson in Persons)
            {
                thisPerson.PostToService();
            }
        }
    }

    public class Person
    {
        [Required(ErrorMessage = "Required From Annotation")] // shows message next to First Name field when FluentValidation is disabled
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal void PostToService()
        {
            throw new NotImplementedException();
        }
    }

    public class PersonsViewModelValidator : AbstractValidator<PersonsViewModel>
    {
        public PersonsViewModelValidator()
        {
            RuleForEach(x => x.Persons).SetValidator(new PersonValidator());
        }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            // Doesn't show message next to First Name field, but does validate correctly
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Required From FluentValidation");
        }
    }
}