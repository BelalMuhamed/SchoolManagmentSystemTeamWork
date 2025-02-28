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
    public class ClassExamRepo : GenericRepo<ClassExam>
    {
        public ClassExamRepo(ApplicationDbContext context) : base(context)
        {
        }
        public ClassExam Filter(Func<ClassExam,bool> predicate)
        {
            return context.ClassExams.FirstOrDefault(predicate);
        }
    }
}
