using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParabolaDB.Attributes
{
    public class PositiveValueValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value!=null)&&(double)value >= 0f )
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The number must be positive");
        }
    }
}