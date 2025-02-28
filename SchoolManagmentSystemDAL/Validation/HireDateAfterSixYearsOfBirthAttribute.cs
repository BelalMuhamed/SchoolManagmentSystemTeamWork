using SchoolManagementSystemDAL.ViewModels;
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
            DateTime dateOfBirth;

            if (validationContext.ObjectInstance is StudentVM studentModel)
            {
                dateOfBirth = studentModel.DateOfBirth;
            }
            else if (validationContext.ObjectInstance is TeacherVM teacherModel)
            {
                dateOfBirth = teacherModel.DateOfBirth;
            }
            else
            {
                return ValidationResult.Success;
            }

            if (dateOfBirth == null || value == null)
            {
                return ValidationResult.Success;
            }

            DateTime hireDate = (DateTime)value;
            DateTime minimumHireDate = dateOfBirth.AddYears(6);

            if (hireDate < minimumHireDate)
            {
                return new ValidationResult("Hire date must be at least 6 years after the birthdate.");
            }

            return ValidationResult.Success;
        }
    }
}
