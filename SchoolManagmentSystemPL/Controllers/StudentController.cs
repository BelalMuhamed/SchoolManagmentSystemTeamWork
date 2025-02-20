using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.GenericRepo;
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
        public async Task<IActionResult> Index()
        {

            List<Student> Students= await unit.StudentRepo.GetAll();
            List<StudentVM> StudentsVm = mapper.Map<List<StudentVM>>(Students);
           
            return  View(StudentsVm);
        }
        public IActionResult Search(string searchTerm)
        {
            var students = unit.StudentRepo.SearchByNameOrClass(searchTerm);
            
            return PartialView("_CustomerList", students);
        }
    }
}
