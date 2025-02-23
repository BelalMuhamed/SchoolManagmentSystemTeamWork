using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class StudentVM
    {

      

        public string StudentName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [DataType(DataType.EmailAddress)]
        public string StudentEmail { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Enter a valid international phone number.")]
    
        public string PhoneNumber { get; set; }


        public string Address { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        
        [DateOfBirthValidation]
        public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;

                
                if (DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        public Gender gender { get; set; }
        [Required(ErrorMessage = "Hire date required.")]
        [DateOfBirthValidation]
        public DateTime HireDate { get; set; } = DateTime.Now.Date;
        [Required(ErrorMessage = "Please select a class.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid class.")]
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public virtual List<Class>? Classes { get; set; } = new List<Class>();
    }
}
