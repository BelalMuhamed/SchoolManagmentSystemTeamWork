using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class SubjectWithTeachers
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Teacher> Teachers { get; set; }  
        public string? SelectedTeacherId { get; set; }
    }
}
