using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class AssignSubbjectWithTeachersToStudentVM
    {
        public int ClassId { get; set; }
        public List<SubjectWithTeachers> Subjects { get; set; }
    }
}
