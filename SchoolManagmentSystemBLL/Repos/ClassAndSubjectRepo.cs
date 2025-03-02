using Microsoft.EntityFrameworkCore;
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
     public class ClassAndSubjectRepo : GenericRepo<ClassAndSubjects>
    {
        public ClassAndSubjectRepo(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<ClassAndSubjects>> GetByClassID(int classid)
        {
            return await context.classesAndSubjects.Where(cs=>cs.classId== classid).Include(s=>s.Subject).ToListAsync();
        }
    }
}
