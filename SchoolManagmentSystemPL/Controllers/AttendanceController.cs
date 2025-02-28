﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagementSystemDAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            var attendances = await _context.StudentAttendances.Include(a => a.StudentId).ToListAsync();
            return View(attendances);
        }        
        public IActionResult Create()
        {
            ViewBag.Users = _context.Users.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentAttendance attendance)
        {
            if (ModelState.IsValid)
            {
                attendance.Date = DateTime.Now;
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }
    }
}
