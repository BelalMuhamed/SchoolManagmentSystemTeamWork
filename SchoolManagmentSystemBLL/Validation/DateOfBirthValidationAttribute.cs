using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Validation
{
     public class DateOfBirthValidationAttribute : ValidationAttribute
    {


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dob)
            {
                DateTime minDate = new DateTime(2008, 1, 1);
                DateTime maxDate = DateTime.Now.Date; 

                if (dob < minDate)
                {
                    return new ValidationResult("Date of Birth must be after 2007.");
                }
                if (dob > maxDate)
                {
                    return new ValidationResult("Date of Birth cannot be in the future.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
