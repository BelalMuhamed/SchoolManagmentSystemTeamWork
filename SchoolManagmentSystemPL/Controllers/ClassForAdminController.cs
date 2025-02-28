using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagementSystemDAL.ViewModels;

namespace SchoolManagmentSystemPL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ClassForAdminController : Controller
    {
        private readonly UnitofWork unit;
        private readonly IMapper mapper;

        public ClassForAdminController(UnitofWork _unit, IMapper _mapper)
        {
            unit = _unit;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Class> Classes = await unit.ClassRepo.GetAllAsync();
            List<ClassVM> ClassesVM = mapper.Map<List<ClassVM>>(Classes);
            return View(ClassesVM);
        }
        public async Task<IActionResult> Add()
        {
            ClassVM Class = new ClassVM();
            Class.Subjects = await unit.subrepo.GetAll();
            Class.Managers = await unit.TeacherRepo.GetAll();
            return View();
        }
    }
}
