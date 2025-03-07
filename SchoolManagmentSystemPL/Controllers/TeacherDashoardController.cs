using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemDAL.ViewModels;
using System.Linq;

public class TeacherDashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeacherDashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var teacherId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(teacherId))
        {
            return RedirectToAction("Login", "Account");
        }

        int totalExams = _context.Exams.Count(e => e.TeacherId == teacherId);

        DateOnly lastWeek = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));

        int attendanceThisWeek = _context.TeacherAttendances
            .Where(a => a.TeacherId == teacherId && a.Status == AttendanceStatus.Absent && a.Date >= lastWeek)
            .Count();

        var managedClass = _context.Classes
            .Where(c => c.ManagerId == teacherId)
            .Select(c => new
            {
                ClassName = c.Name,
                ClassId = c.Id
            }).FirstOrDefault();

        int totalStudents = 0, totalSubjects = 0;
        List<StudentInfoVM> students = new List<StudentInfoVM>();

        if (managedClass != null)
        {
            totalStudents = _context.Students.Count(s => s.ClassId == managedClass.ClassId);
            totalSubjects = _context.classesAndSubjects.Count(cs => cs.classId == managedClass.ClassId);

            students = _context.Students
                .Where(s => s.ClassId == managedClass.ClassId)
                .Select(s => new StudentInfoVM
                {
                    Name = s.User.UserName ?? "No Name",
                    Degree = _context.StudentDegrees
                                .Where(d => d.StudentId == s.User.Id)
                                .Sum(d => (int?)d.Degree) ?? 0,
                    Attendance = _context.StudentAttendances
                                    .Where(a => a.StudentId == s.User.Id && a.Status == AttendanceStatus.Absent)
                                    .Count()
                }).ToList();
        }
        else
            return View(new TeacherDashboardVM());

        int averageDegree = students.Any() ? (int)students.Average(s => s.Degree) : 0;
        int averageAttendance = students.Any() ? (int)students.Average(s => s.Attendance) : 0;
        string topStudent = students.OrderByDescending(s => s.Degree).Select(s => s.Name).FirstOrDefault() ?? "No Top Student";


        var schedule = _context.ClassLessons
            .Where(s => s.ClassId == managedClass.ClassId
                        && s.TeacherId == teacherId
                        && s.Date.Date == DateTime.Now.Date)
            .Select(s => new TeacherSchedualVM
            {
                Subject = s.Subject.Name ?? "No Subject",
                Class = managedClass.ClassName ?? "No Class",
                Date = s.Date,
                StartTime = s.StartTime.ToString(@"hh\:mm tt"),
                EndTime = s.EndTime.ToString(@"hh\:mm tt")
            }).ToList();


        int[] weeklyAttendance = new int[7];

        for (int i = 0; i < 7; i++)
        {
            DateOnly day = DateOnly.FromDateTime(DateTime.Now.AddDays(-i));
            weeklyAttendance[6 - i] = _context.TeacherAttendances
                .Count(a => a.TeacherId == teacherId && a.Status == AttendanceStatus.Absent && a.Date == day);
        }

        var viewModel = new TeacherDashboardVM
        {
            TotalExamsCreated = totalExams,
            AttendanceThisWeek = attendanceThisWeek,
            ManagedClassName = managedClass?.ClassName ?? "No Class Assigned",
            TotalStudentsInClass = totalStudents,
            TotalSubjectsInClass = totalSubjects,
            Students = students,
            AverageAttendance = averageAttendance,
            AverageDegree = averageDegree,
            TopStudent = topStudent,
            WeeklySchedule = schedule,
            WeeklyAttendance = weeklyAttendance
        };

        return View(viewModel);
    }

}
