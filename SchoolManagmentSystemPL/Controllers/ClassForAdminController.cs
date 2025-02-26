using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

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
            List<Class> Classes =await unit.ClassRepo.GetAllAsync();
            List<ClassVM> ClassesVM = mapper.Map<List<ClassVM>>(Classes);
            return View( ClassesVM);
        }

    }
}
