﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagementSystemDAL.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagmentSystemPL.Controllers
{
        [Authorize(Roles = "Admin")]

    public class ManageTeacherAttendanceController : Controller
    {
        private readonly UnitofWork unit;
        private readonly IMapper mapper;

        public ManageTeacherAttendanceController(UnitofWork _unit, IMapper _mapper)
        {
            unit = _unit;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(DateOnly? daydate)
        {

            List<TeacherAttendance> teacherAttendances =await  unit.manageteacherAttendanceRepo.GetTeachersAttendanceByDate(daydate);
            List<TeacherAttendanceVM> listteacherAttendancesVM = mapper.Map<List<TeacherAttendanceVM>>(teacherAttendances);
          if(daydate!=null)
            {
                return PartialView("_TeacherAttendanceTable", listteacherAttendancesVM);
            }
            return View(listteacherAttendancesVM);
        }
        [HttpGet]
        public async Task<IActionResult> SubmitAttendance()
        {
            List<Teacher> listteachers = await unit.TeacherRepo.GetAllAsync();
            List<TeacherAttendanceVM> TeachersAttendanceList = mapper.Map<List<TeacherAttendanceVM>>(listteachers);
            return View(TeachersAttendanceList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async  Task<IActionResult> SubmitAttendance(List<TeacherAttendanceVM> teacherAttendances)
        {
            if(ModelState.IsValid)
            {
                List<TeacherAttendance> addedTeacherattendancelist = mapper.Map<List<TeacherAttendance>>(teacherAttendances);
                try
                {
                    await unit.manageteacherAttendanceRepo.AddAttendanceOfAllTeachersAysnc(addedTeacherattendancelist);


                    await unit.save();


                    return RedirectToAction("Index");
                }
                catch
                {
                    return BadRequest();

                }


            }


            return BadRequest();
        }

    }
}
