using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.GenericRepo;
using SchoolManagmentSystemBLL.Mapping;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

namespace SchoolManagmentSystemPL.Controllers
{
    [Authorize(Roles = "Admin")]
    
    public class StudentController : Controller
    {
        private readonly UnitofWork unit;
        private readonly IMapper mapper;

        public StudentController(UnitofWork _unit, IMapper _mapper)
        {
            unit = _unit;
            mapper = _mapper;
        }
        [HttpGet]

        public async Task<IActionResult> Index(string searchitem)
        {

            List<Student> Students = await unit.StudentRepo.SearchByName(searchitem);
            List<StudentVM> StudentsVm = mapper.Map<List<StudentVM>>(Students);
            if (!string.IsNullOrEmpty(searchitem))
            {
                return PartialView("_StudentTable", StudentsVm);
            }
            return View(StudentsVm);
        }
        public async Task<IActionResult> Add()
        {
            StudentVM student = new StudentVM();
            student.Classes =await unit.ClassRepo.GetAll();
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentVM studentvm)
        {
           if(ModelState.IsValid)
            {
                ApplicationUser AddedUser = mapper.Map<ApplicationUser>(studentvm);
                AddedUser.PasswordHash = studentvm.Password;
               
                IdentityResult result = await unit.user.CreateAsync(AddedUser, AddedUser.PasswordHash);
                if (result.Succeeded)
                {
                    await unit.user.AddToRoleAsync(AddedUser, "Student");
                   
                    Student AddedS = new Student()
                    {
                        UserId = AddedUser.Id,
                        ClassId = studentvm.ClassId
                    };
                    await unit.StudentRepo.Add(AddedS);
                   int flag= await unit.save();
                    if(flag>0)
                    {
                        return RedirectToAction("Index", "Student");

                    }
                }
                else
                {
                    foreach (var i in result.Errors)
                    {
                        ModelState.AddModelError("", i.Description);
                    }
                }

            }
           studentvm.Classes =  await unit.ClassRepo.GetAll();
            return View("Add", studentvm);
        }
    } 
}
