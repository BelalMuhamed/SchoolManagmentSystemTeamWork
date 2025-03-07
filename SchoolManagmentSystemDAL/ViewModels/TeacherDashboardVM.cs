using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class TeacherDashboardVM
    {
        public int TotalExamsCreated { get; set; }
        public int AttendanceThisWeek { get; set; }
        public string ManagedClassName { get; set; }
        public int TotalStudentsInClass { get; set; }
        public int TotalSubjectsInClass { get; set; }
        public List<StudentInfoVM> Students { get; set; }
        public int AverageAttendance { get; set; }
        public int AverageDegree { get; set; }
        public string TopStudent { get; set; }
        public List<TeacherSchedualVM> WeeklySchedule { get; set; }
        public int[] WeeklyAttendance { get; set; }
    }
}
