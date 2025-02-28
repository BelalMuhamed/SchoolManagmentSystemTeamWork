using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.GenericRepo;
using SchoolManagmentSystemBLL.Mapping;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagementSystemDAL.ViewModels;
using System.Threading.Tasks;

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
            student.Classes = await unit.ClassRepo.GetAll();
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Add(StudentVM studentvm)
        {
            if (ModelState.IsValid)
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
                    int flag = await unit.save();
                    if (flag > 0)
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
            studentvm.Classes = await unit.ClassRepo.GetAll();
            return View("Add", studentvm);
        }
        [HttpGet("Student/Edit/{UserId}")]
        public async Task<IActionResult> Edit(string UserId)
        {

            Student EditStudent = await unit.StudentRepo.GetByIDAsync(UserId);
           
            if (EditStudent != null )
            {
                
                EditStudentVM editStudentVM = mapper.Map<EditStudentVM>(EditStudent);
                editStudentVM.StudentId = UserId;
                editStudentVM.Classes = await unit.ClassRepo.GetAll();
                return View("EditStudent", editStudentVM);
            }
            return NotFound();


        }
        [HttpPost("Student/Edit/{UserId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditStudentVM eDitedStudent,[FromRoute]string UserId)
        {
            if (ModelState.IsValid)
            {
                Student EditedStudent = await unit.StudentRepo.GetByIDAsync(UserId);
               
               
                if (EditedStudent != null && EditedStudent.UserId== UserId)
                {
                    EditedStudent.User.UserName = eDitedStudent.StudentName;
                    EditedStudent.User.Email = eDitedStudent.StudentEmail;
                    EditedStudent.User.PhoneNumber = eDitedStudent.PhoneNumber;
                    EditedStudent.User.Address = eDitedStudent.Address;
                    EditedStudent.User.DateOfBirth = eDitedStudent.DateOfBirth;
                    EditedStudent.User.Gender = eDitedStudent.gender;
                    EditedStudent.User.HireDate = eDitedStudent.HireDate;
                    EditedStudent.ClassId = eDitedStudent.ClassId;
                  //  EditedStudent = mapper.Map<Student>(eDitedStudent);



                }
                unit.StudentRepo.Update(EditedStudent);
                int flag = await unit.save();
                if(flag>0)
                {
                    return RedirectToAction("Index", "Student");
                }
            }
            eDitedStudent.Classes = await unit.ClassRepo.GetAll();
            return View("EditStudent", eDitedStudent);

        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(string UserId)
        {
            Student DeletedStudent = await unit.StudentRepo.GetByIDAsync(UserId);
            if (DeletedStudent == null)
            {
                return Json(new { success = false, message = "Student not found" });
            }

            DeletedStudent.User.IsDeleted = true;
            unit.StudentRepo.Update(DeletedStudent);
            int flag = await unit.save();

            if (flag > 0)
            {

                return Json(new { success = true, message = "Student deleted successfully!" });
                
            }

            return Json(new { success = false, message = "Error: Unable to delete student" });
        }


    }
}
