using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Repos
{
    public class ScheduleRepo : GenericRepo<ClassLesson>
    {
        public ScheduleRepo(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<int>> GetDistinctYearsAsync()
        {
            return await context.ClassLessons
               .Select(cl => cl.Date.Year)
               .Distinct()
               .OrderBy(year => year)
               .ToListAsync();
        }



    }
}
