using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

namespace SchoolManagmentSystem.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitofWork _unitofWork;
        public HomeController(ILogger<HomeController> logger, UnitofWork unitofWork)
        {
            _logger = logger;
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            var result = new AdminStatisticsVM
            {
                TotalStudents = _unitofWork.StudentRepo.GetAll().Result.Count(),
                TotalTeachers = _unitofWork.TeacherRepo.GetAll().Result.Count(),
                TotalClasses = _unitofWork.ClassRepo.GetAll().Result.Count(),
                TotalSubjects = _unitofWork.SubjectRepo.GetAll().Result.Count(),
                TodayStudentAttendance = _unitofWork.StudentAttendanceRepo.Filter(s => s.Date.Date == DateTime.Now.Date && s.Status == AttendanceStatus.Absent).Count(),
                TodayTeacherAttendance = _unitofWork.manageteacherAttendanceRepo.Filter(s => s.Date == today && s.Status == AttendanceStatus.Absent).Count()
            };

            // Fetch attendance for the last 7 days
            for (int i = 6; i >= 0; i--)
            {
                DateOnly date = DateOnly.FromDateTime(DateTime.Now.AddDays(-i));
                result.WeeklyDates.Add(date.ToString("MMM dd"));

                DateTime dateTime = date.ToDateTime(new TimeOnly());
                int studentAttendance = _unitofWork.StudentAttendanceRepo.Filter(s => s.Date.Date == dateTime.Date && s.Status == AttendanceStatus.Absent).Count();
                int teacherAttendance = _unitofWork.manageteacherAttendanceRepo.Filter(s => s.Date == date && s.Status == AttendanceStatus.Absent).Count();

                result.WeeklyStudentAttendance.Add(studentAttendance);
                result.WeeklyTeacherAttendance.Add(teacherAttendance);
            }

            return View(result);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
