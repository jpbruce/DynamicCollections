using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;

namespace DynamicCollections.Models
{
    [Validator(typeof(PersonsViewModelValidator))]
    public class PersonsViewModel
    {
        public FluentFoo FluentFoo { get; set; }

        public List<Person> Persons { get; set; } = new List<Person>();

        public void PostPersons()
        {
            foreach (Person thisPerson in Persons)
            {
                thisPerson.PostToService();
            }
        }
    }

    public class FluentFoo
    {
        public string FluentRequired { get; set; }
    }

    public class Person : IValidatableObject
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public MailingAddress Address { get; set; }

        public class MailingAddress
        {
            public string AddressLine1 { get; set; }
        }

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                yield return new ValidationResult("Required from IValidatableObject", new[] { "FirstName" });
            }

            if (string.IsNullOrEmpty(Address.AddressLine1))
            {
                yield return new ValidationResult("Required", new[] { "Address.AddressLine1" });
            }
        }

        internal void PostToService()
        {
            throw new NotImplementedException();
        }
    }

    public class PersonsViewModelValidator : AbstractValidator<PersonsViewModel>
    {
        public PersonsViewModelValidator()
        {
            RuleFor(x => x.FluentFoo.FluentRequired).NotEmpty().WithMessage("Required From FluentValidation");
        }
    }
}