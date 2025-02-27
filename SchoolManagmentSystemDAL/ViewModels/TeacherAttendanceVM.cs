using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
   public  class TeacherAttendanceVM
    {
        
        public int Id { get; set; }


        public string? TeacherId { get; set; }
        public string? TeacherName { get; set; }


        
        public AttendanceStatus Status { get; set; }


        public DateTime Date { get; set; } = DateTime.Now;
    }
}
