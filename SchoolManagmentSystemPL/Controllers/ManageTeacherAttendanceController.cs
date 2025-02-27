using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;
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
        public async Task<IActionResult> Index(DateTime? daydate)
        {

            List<TeacherAttendance> teacherAttendances =await  unit.manageteacherAttendanceRepo.GetTeachersAttendanceByDate(daydate);
            List<TeacherAttendanceVM> listteacherAttendancesVM = mapper.Map<List<TeacherAttendanceVM>>(teacherAttendances);
          if(daydate!=null)
            {
                return PartialView("_TeacherAttendanceTable", listteacherAttendancesVM);
            }
            return View(listteacherAttendancesVM);
        }
    }
}
