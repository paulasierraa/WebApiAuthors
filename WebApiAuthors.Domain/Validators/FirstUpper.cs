using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthors.Validators
{
    public class FirstUpper:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)//valor del campo , validationContext 
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var firstLetter = value.ToString()[0].ToString();

            if(firstLetter!=firstLetter.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }
            return ValidationResult.Success;
        }
    }
}
