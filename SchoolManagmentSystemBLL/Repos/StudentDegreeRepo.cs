using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Repos
{
    public class StudentDegreeRepo : GenericRepo<StudentDegree>
    {
        public StudentDegreeRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
