using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

namespace SchoolManagmentSystemPL.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly UnitofWork unit;
        private readonly IMapper mapper;

        public StudentDashboardController(UnitofWork _unit, IMapper _mapper)
        {
            unit = _unit;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Schedule()
        {
            int selectedYear = DateTime.Now.Year;
            
            string studentId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var classId = unit.StudentRepo.Filter(s => s.UserId == studentId).FirstOrDefault().ClassId;
            var lessons = await unit.ClassLessonRepo.GetAll();
            var filteredLessons = lessons
                .Where(cl => cl.Date.Year == selectedYear && cl.ClassId == classId)
                .ToList();
            ViewData["ClassExam"] = await unit.ClassExamRepo.GetAll();
            var availableYears = await unit.ClassLessonRepo.GetDistinctYearsAsync();
            var vm = new ScheduleVM
            {
                SelectedYear = selectedYear,
                Lessons = filteredLessons,
                AvailableYears = availableYears
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Attendance()
        {
            string studentId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            List<StudentAttendance> attendances =await  unit.StudentAttendanceRepo.GetByStudentId(studentId);
            List<StudentAttendanceVM> vm = mapper.Map<List<StudentAttendanceVM>>(attendances);
            return View(vm);
        }

    }
}
