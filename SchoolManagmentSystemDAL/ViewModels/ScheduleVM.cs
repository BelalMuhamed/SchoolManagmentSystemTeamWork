using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class ScheduleVM
    {
        public int SelectedYear { get; set; }
        public List<ClassLesson> Lessons { get; set; }
        public List<int> AvailableYears { get; set; }
    }
}
