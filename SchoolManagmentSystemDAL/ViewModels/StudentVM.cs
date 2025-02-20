using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class StudentVM
    {
        public  string StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public DateTime HireDate { get; set; }
        public string ParentName { get; set; }
        public int? ClassId { get; set; }
        public string? ClassName { get; set; }
    }
}
