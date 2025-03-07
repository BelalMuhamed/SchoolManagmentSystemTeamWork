using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class AdminStatisticsVM
    {
        public int TotalStudents { get; set; }
        public int TotalTeachers { get; set; }
        public int TotalClasses { get; set; }
        public int TotalSubjects { get; set; }
        public int TodayStudentAttendance { get; set; }
        public int TodayTeacherAttendance { get; set; }
        // Weekly Attendance Data
        public List<string> WeeklyDates { get; set; } = new List<string>(); // Stores last 7 days as strings
        public List<int> WeeklyStudentAttendance { get; set; } = new List<int>(); // Stores student attendance counts for each day
        public List<int> WeeklyTeacherAttendance { get; set; } = new List<int>(); // Stores teacher attendance counts for each day

    }
}
