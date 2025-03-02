using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
   public  class StudentAttendanceRepo:GenericRepo<StudentAttendance>
    {
        public StudentAttendanceRepo(ApplicationDbContext context) : base(context)
        {
        }

      
        public async Task<List<StudentAttendance>> GetByStudentId(string studentId)
        {
            return await context.StudentAttendances.Include(t => t.student).ThenInclude(t => t.User).Where(t => t.student.User.IsDeleted == false &&t.StudentId==studentId ).ToListAsync();

        }

    }

    }
