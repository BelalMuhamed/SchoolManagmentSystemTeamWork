using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using SchoolManagmentSystemDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace SchoolManagmentSystemBLL.Repos
{
    public class ManageTeacherAttendanceRepo : GenericRepo<TeacherAttendance>
    {
       
       
        public ManageTeacherAttendanceRepo(ApplicationDbContext context ) : base(context)
        {
            


        }
        public async Task<List<TeacherAttendance>> GetTeachersAttendanceByDate(DateOnly? DayDate)
        {
            DayDate ??= DateOnly.FromDateTime(DateTime.Now);
            return await context.TeacherAttendances.Include(t => t.teacher).ThenInclude(t => t.User).Where(t => t.teacher.User.IsDeleted == false && t.Date == DayDate.Value).ToListAsync();
           
        }
        public async Task AddAttendanceOfAllTeachersAysnc(List<TeacherAttendance> teacherAttendances)
        {

            await context.AddRangeAsync(teacherAttendances);
        }
       

    }
}
