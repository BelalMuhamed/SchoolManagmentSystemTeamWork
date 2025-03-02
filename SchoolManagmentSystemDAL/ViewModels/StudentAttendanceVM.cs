using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
   public class StudentAttendanceVM
    {
       
            public string StudentId { get; set; }
            public string StudentName { get; set; }
            public DateTime Date { get; set; }
            public AttendanceStatus Status { get; set; }
        
    }
}
