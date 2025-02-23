using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Extend
{
    public class ApplicationUser : IdentityUser
    { 
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; } = false;
    }
    public enum Gender
    {
        Male,
        Female
    }
}
