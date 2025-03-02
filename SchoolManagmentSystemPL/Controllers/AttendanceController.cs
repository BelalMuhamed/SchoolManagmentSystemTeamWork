using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystem.DAL.Models;

namespace SchoolManagmentSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            var attendances = await _context.StudentAttendances
                .Include(a => a.student)
                .ThenInclude(s => s.User) 
                .ToListAsync();
            return View(attendances);
        }

        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.Include(s => s.User).ToList();
            return View();
        }

        [HttpPost]
      
        public async Task<IActionResult> Create(StudentAttendance attendance)
        {
            if (ModelState.IsValid)
            {
                attendance.Date = DateTime.Now;
                _context.StudentAttendances.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Students = _context.Students.Include(s => s.User).ToList();
            return View(attendance);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var attendance = await _context.StudentAttendances.FindAsync(id);
            if (attendance == null) return NotFound();

            ViewBag.Students = _context.Students.Include(s => s.User).ToList();
            return View(attendance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentAttendance attendance)
        {
            if (id != attendance.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Students = _context.Students.Include(s => s.User).ToList();
            return View(attendance);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var attendance = await _context.StudentAttendances
                .Include(a => a.student)
                .ThenInclude(s => s.User)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (attendance == null) return NotFound();

            return View(attendance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.StudentAttendances.FindAsync(id);
            if (attendance == null) return NotFound();

            _context.StudentAttendances.Remove(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
