using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemDAL.ViewModels
{
    public class TeacherVM
    { 
            public string? UserId { get; set; }
            public string TeacherName { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            [DataType(DataType.EmailAddress)]
            public string TeacherEmail { get; set; }

            [Required(ErrorMessage = "Phone number is required.")]
            [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Enter a valid international phone number.")]
            public string PhoneNumber { get; set; }

            public string Address { get; set; }

        //[Required(ErrorMessage = "Date of Birth is required.")]
       //[DateOfBirthValidation]
       // public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;

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
        public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;

        public Gender gender { get; set; }

            //[Required(ErrorMessage = "Hire date required.")]
            //[HireDateAfterSixYearsOfBirth]
            public DateTime HireDate { get; set; } = DateTime.Now.Date;

            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }

                 [Required(ErrorMessage = "Subject is required.")]
                         public int SubjectId { get; set; }

                          public string? SubjectName { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public virtual List<Class>? Classes { get; set; } = new List<Class>();
        }

    }

