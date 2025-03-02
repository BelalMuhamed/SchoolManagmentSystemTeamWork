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
        public async Task<IActionResult> Schedule(int? year)
        {
            int selectedYear = year ?? DateTime.Now.Year;


            var lessons = await unit.ClassLessonRepo.GetAll();
            var filteredLessons = lessons
                .Where(cl => cl.Date.Year == selectedYear)
                .ToList();

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
        public async Task<IActionResult> Attendance(string studentId)
        {
            List<StudentAttendance> attendances =await  unit.StudentAttendanceRepo.GetByStudentId(studentId);
            List<StudentAttendanceVM> vm = mapper.Map<List<StudentAttendanceVM>>(attendances);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendance(StudentAttendanceVM model)
        {
            if (ModelState.IsValid)
            {
                var attendance = mapper.Map<StudentAttendance>(model);
                await unit.StudentAttendanceRepo.Add(attendance);
                await unit.save();
                return RedirectToAction("Attendance");
            }
            return View(model);
        }
    }
}
