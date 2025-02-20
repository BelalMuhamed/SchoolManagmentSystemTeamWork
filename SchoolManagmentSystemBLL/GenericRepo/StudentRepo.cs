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
        public List<Student> SearchByNameOrClass(string SearchItem)
        {
            List<Student> SearchedStudents = string.IsNullOrEmpty(SearchItem)
             ? new List<Student>()
             : context.Students
                 .Where(c => c.User.UserName.ToLower().Contains(SearchItem.Trim().ToLower()) || c.Class.Name.ToLower().Contains(SearchItem.Trim().ToLower())).ToList();
                 

            return SearchedStudents; 
           }
    }
}
