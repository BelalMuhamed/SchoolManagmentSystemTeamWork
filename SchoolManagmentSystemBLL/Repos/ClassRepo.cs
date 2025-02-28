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
    public class ClassRepo : GenericRepo<Class>
    {
        public ClassRepo(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Class>> GetAllAsync()
        {
            var classes = await  context.Classes
            .Include(c => c.classsubjesct)
                .ThenInclude(cs => cs.Subject)
            .Include(c => c.User) 
            .ToListAsync();

            return   classes;
        }
    }
}
