using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Television_Channel_Program.CustomAnnotations
{
    public class EstablishedYearAnnotations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value == null) 
            {
                return new ValidationResult("Established year is required");
            }
            else
            {
                int year = (int)value;
                if (year < 1900 || year > DateTime.Now.Year)
                {
                    return new ValidationResult("Established year must be between 1900 and current year");
                }
                return ValidationResult.Success;
            }
            
        }
    }
}