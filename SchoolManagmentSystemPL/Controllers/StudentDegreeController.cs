using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.Controllers
{
    public class StudentDegreeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentDegreeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display the list of student degrees
        public async Task<IActionResult> Index()
        {
            var studentDegrees = await _context.StudentDegrees
                .Include(sd => sd.Student)
                .Include(sd => sd.Subject)
                .Include(sd => sd.Teacher)
                .Include(sd => sd.Class)
                .ToListAsync();

            return View(studentDegrees);
        }

        // Show the create form
        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(_context.Students, "Id", "Name");
            ViewBag.Subjects = new SelectList(_context.Subjects, "Id", "Name");
            ViewBag.Classes = new SelectList(_context.Classes, "Id", "Name");
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "Name");

            return View();
        }

        // Handle form submission for creating a new student degree
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDegree studentDegree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDegree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDegree);
        }

        // Show the edit form for an existing student degree
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

        // Handle form submission for updating a student degree
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // Delete a student degree record
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
