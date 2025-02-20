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
            List<Student> SearchedStudents = await context.Students.Where(s => (string.IsNullOrEmpty(SearchItem) || s.User.UserName.Trim().ToLower().Contains(SearchItem.Trim().ToLower()))).ToListAsync();
            return SearchedStudents;
        }
    }
}
