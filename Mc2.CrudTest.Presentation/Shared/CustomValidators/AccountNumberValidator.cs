using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.CustomValidators
{
  

    public class AccountNumberValidator : ValidationAttribute
    {
        // public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            string AccNo = (string)value;

            if ( value == null  || AccNo.Length < 10 )
                return new ValidationResult($"Account Number is not valid", new[] { validationContext.MemberName });

            return null;// means Valid            
        }
    }
}
