using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.Mapping;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

namespace SchoolManagmentSystemPL.Controllers
{
    public class StudentController : Controller
    {
        private readonly UnitofWork unit;
        private readonly IMapper mapper;

        public StudentController(UnitofWork _unit,IMapper _mapper)
        {
            unit = _unit;
            mapper = _mapper;
        }
        public IActionResult Index()
        {

            List<Student> Students=unit.StudentRepo.GetAll();
            List<StudentVM> StudentsVm = mapper.Map<List<StudentVM>>(Students);
           
            return View(StudentsVm);
        }
    }
}
