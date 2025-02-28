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
    public class TeacherRepo : GenericRepo<Teacher>
    {
        public TeacherRepo(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Teacher>> SearchByName(string SearchItem)
        {
            List<Teacher> SearchedTeachers = await context.Teachers
                .Where(t => (string.IsNullOrEmpty(SearchItem) || t.User.UserName.Trim().ToLower().Contains(SearchItem.Trim().ToLower()))
                && t.User.IsDeleted == false)
                .ToListAsync();

            return SearchedTeachers;
        }

        public async Task<Teacher> GetByName(string teacherName)
        {
            return await context.Teachers.FirstOrDefaultAsync(t => t.User.UserName == teacherName);
        }

        public async Task<Teacher> GetByIDAsync(string Id)
        {
            return await context.Teachers.FirstOrDefaultAsync(t => t.UserId == Id);
        }
        public async Task<List<Teacher>> GetAllAsync()
        {
            return await context.Teachers.Include(t => t.User).Where(u => u.User.IsDeleted == false).ToListAsync();
        }
    }
}
