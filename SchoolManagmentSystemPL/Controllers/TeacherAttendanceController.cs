using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;

namespace SchoolManagmentSystemPL.Controllers
{
    public class TeacherAttendanceController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> user;

        public TeacherAttendanceController(ApplicationDbContext context,UserManager<ApplicationUser> user)
        {
            this.context = context;
            this.user = user;
        }
        public async Task<IActionResult> Index()
        {
            //IList<ApplicationUser> list = await user.GetUsersInRoleAsync("Teacher");
            ////List<string>  name =  list.Select(s => s.UserName).ToList();
            //List<ApplicationUser> users = new List<ApplicationUser>();

            return View("Attendance");
            //List<Attendance> users = new List<Attendance>();
            //user.Users
        }
    }
}
