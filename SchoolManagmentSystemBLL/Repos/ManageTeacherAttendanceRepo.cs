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
    public class ManageTeacherAttendanceRepo : GenericRepo<TeacherAttendance>
    {
        public ManageTeacherAttendanceRepo(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<TeacherAttendance>> GetTeachersAttendanceByDate(DateTime? DayDate)
        {
            DayDate ??= DateTime.Today;
            return await context.TeacherAttendances.Include(t => t.teacher).ThenInclude(t => t.User).Where(t => t.teacher.User.IsDeleted == false && t.Date.Date == DayDate.Value.Date).ToListAsync();
           
        }
          
    }
}
