using Castle.Core.Resource;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.GenericRepo
{
  public  class StudentRepo : GenericRepo<Student>
    {
       

        public StudentRepo( ApplicationDbContext context) : base(context)
        {
            
        }

       

        public async Task<List<Student>> SearchByName(string SearchItem)
        {
            List<Student> SearchedStudents = await context.Students.Where(s => (string.IsNullOrEmpty(SearchItem) || s.User.UserName.Trim().ToLower().Contains(SearchItem.Trim().ToLower()))&& s.User.IsDeleted == false).ToListAsync();
            return SearchedStudents;
        }
        public async Task<Student> GetByName(string studentName)
        {
             return await context.Students.FirstOrDefaultAsync(s => s.User.UserName == studentName);
        }
        public async Task<Student> GetByIDAsync(string Id)
        {
            return await context.Students.FirstOrDefaultAsync(s => s.UserId == Id);
        }
    }
}

