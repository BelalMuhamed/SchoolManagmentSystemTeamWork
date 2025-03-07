using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class TeacherSchedualVM
    {
        public string Subject { get; set; }
        public string Class { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
