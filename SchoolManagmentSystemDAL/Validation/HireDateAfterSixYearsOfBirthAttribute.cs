using SchoolManagmentSystemDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Validation
{
    public class HireDateAfterSixYearsOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (StudentVM)validationContext.ObjectInstance; 

            if (model.DateOfBirth == null || value == null)
            {
                return ValidationResult.Success; 
            }

            DateTime hireDate = (DateTime)value;
            DateTime minimumHireDate = model.DateOfBirth.AddYears(6);

            if (hireDate < minimumHireDate)
            {
                return new ValidationResult("Hire date must be at least 6 years after the birthdate.");
            }

            return ValidationResult.Success;
        }
    }
}
