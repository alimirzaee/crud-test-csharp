using Mc2.CrudTest.Shared.Common;
using PhoneNumbers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Shared.CustomValidators
{


    public class PhoneNumberValidator : ValidationAttribute
    {
        // public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {

            string result = PhoneNumberValidatorClass.IsValid((string)value);

            if (result == null)
                return null;// means Valid

            return new ValidationResult($"Phone Number is not valid", new[] { validationContext.MemberName });
        }
    }
}
