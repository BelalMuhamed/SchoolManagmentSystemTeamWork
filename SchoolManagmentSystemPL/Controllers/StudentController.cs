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
        [HttpGet]
       
        public async Task<IActionResult> Index(string searchitem)
        {
            
            List<Student> Students= await unit.StudentRepo.SearchByName(searchitem);
            List<StudentVM> StudentsVm = mapper.Map<List<StudentVM>>(Students);
           if(!string.IsNullOrEmpty(searchitem))
            {
                return PartialView("_StudentTable", StudentsVm);
            }
            return  View(StudentsVm);
        }
        
    }
}
