using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemDAL.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class StudentDegreeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentDegreeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var studentDegrees = await _context.StudentDegrees
                .ToListAsync();

            return View(studentDegrees);
        }

        // Show the create form
        public IActionResult Create()
        {
            var model = new StudentDegreeVM
            {
                Students = _context.Students.ToList(),
                Subjects = _context.Subjects.ToList(),
                Classs = _context.Classes.ToList(),
                Teachers = _context.Teachers.ToList()
            };

            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDegreeVM model)
        {
            if (!ModelState.IsValid)
            {

                model.Students = _context.Students.Include(s => s.User).ToList();
                model.Subjects = _context.Subjects.ToList();
                model.Classs = _context.Classes.ToList();
                model.Teachers = _context.Teachers.Include(t => t.User).ToList();
                return View(model);
            }

            var studentDegree = new StudentDegree
            {
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
                ClassId = model.ClassId,
                TeacherId = model.TeacherId,
                Degree = model.Degree,
                Status = model.Status
            };

            _context.StudentDegrees.Add(studentDegree);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(string studentId, int subjectId, int classId, string teacherId)
        {
            var studentDegree = await _context.StudentDegrees
                .FirstOrDefaultAsync(sd => sd.StudentId == studentId && sd.SubjectId == subjectId && sd.ClassId == classId && sd.TeacherId == teacherId);

            if (studentDegree == null)
            {
                return NotFound();
            }

            return View(studentDegree);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentDegree studentDegree)
        {
            if (ModelState.IsValid)
            {
                _context.Update(studentDegree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDegree);
        }

        public async Task<IActionResult> Delete(string studentId, int subjectId, int classId, string teacherId)
        {
            var studentDegree = await _context.StudentDegrees
                .FirstOrDefaultAsync(sd => sd.StudentId == studentId && sd.SubjectId == subjectId && sd.ClassId == classId && sd.TeacherId == teacherId);

            if (studentDegree == null)
            {
                return NotFound();
            }

            _context.StudentDegrees.Remove(studentDegree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
