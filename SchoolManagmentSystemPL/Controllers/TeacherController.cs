using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

namespace SchoolManagmentSystemPL.Controllers
{
   
        [Authorize(Roles = "Admin")]

        public class TeacherController : Controller
        {
            private readonly UnitofWork unit;
            private readonly IMapper mapper;

            public TeacherController(UnitofWork _unit, IMapper _mapper)
            {
                unit = _unit;
                mapper = _mapper;
            }
            [HttpGet]
            public async Task<IActionResult> Index(string searchitem)
            {

                List<Teacher> Teachers = await unit.TeacherRepo.SearchByName(searchitem);
                List<TeacherVM> TeachersVm = mapper.Map<List<TeacherVM>>(Teachers);
                if (!string.IsNullOrEmpty(searchitem))
                {
                    return PartialView("_TeacherTable", TeachersVm);
                }
                return View(TeachersVm);
            }

            public async Task<IActionResult> Add()
            {
                TeacherVM teacher = new TeacherVM();
                teacher.Classes = await unit.ClassRepo.GetAll();
                 teacher.Subjects = await unit.SubjectRepo.GetAll();
                return View(teacher);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]

            public async Task<IActionResult> Add(TeacherVM teachervm)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser AddedUser = mapper.Map<ApplicationUser>(teachervm);
                    AddedUser.PasswordHash = teachervm.Password;

                    IdentityResult result = await unit.user.CreateAsync(AddedUser, AddedUser.PasswordHash);
                    if (result.Succeeded)
                    {
                        await unit.user.AddToRoleAsync(AddedUser, "Teacher");

                        Teacher AddedT = new Teacher()
                        {
                            UserId = AddedUser.Id,
                            SubjectId = teachervm.SubjectId

                        };
                        await unit.TeacherRepo.Add(AddedT);
                        int flag = await unit.save();
                        if (flag > 0)
                        {
                            return RedirectToAction("Index", "Teacher");

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
                teachervm.Classes = await unit.ClassRepo.GetAll();
            teachervm.Subjects = await unit.SubjectRepo.GetAll();
            return View("Add", teachervm);
            }

            public async Task<IActionResult> Edit(string UserId)
            {

                Teacher EditTeacher = await unit.TeacherRepo.GetByIDAsync(UserId);

                if (EditTeacher != null)
                {

                    EditTeacherVM editTeacherVM = mapper.Map<EditTeacherVM>(EditTeacher);
                editTeacherVM.Subjects = await unit.SubjectRepo.GetAll();
                return View("EditTeacher", editTeacherVM);
                }
                return RedirectToAction("Index", "Teacher");

            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(EditTeacherVM editedTeacher)
            {
                if (ModelState.IsValid)
                {
                    Teacher EditedTeacher = await unit.TeacherRepo.GetByIDAsync(editedTeacher.TeacherId);
                    if (EditedTeacher != null)
                    {
                        EditedTeacher.User.UserName = editedTeacher.TeacherName;
                        EditedTeacher.User.Email = editedTeacher.TeacherEmail;
                        EditedTeacher.User.PhoneNumber = editedTeacher.PhoneNumber;
                        EditedTeacher.User.Address = editedTeacher.Address;
                       EditedTeacher.User.DateOfBirth = editedTeacher.DateOfBirth;
                    
                        EditedTeacher.User.Gender = editedTeacher.gender;
                        EditedTeacher.User.HireDate = editedTeacher.HireDate;
                              EditedTeacher.SubjectId = editedTeacher.SubjectId;

                }
                    unit.TeacherRepo.Update(EditedTeacher);
                    int flag = await unit.save();
                    if (flag > 0)
                    {
                        return RedirectToAction("Index", "Teacher");
                    }
                }
              
                return View("EditTeacher", editedTeacher);

            }

            [HttpDelete]
            public async Task<IActionResult> Delete(string UserId)
            {
                Teacher DeletedTeacher = await unit.TeacherRepo.GetByIDAsync(UserId);
                if (DeletedTeacher == null)
                {
                    return Json(new { success = false, message = "Teacher not found" });
                }

                DeletedTeacher.User.IsDeleted = true;
                unit.TeacherRepo.Update(DeletedTeacher);
                int flag = await unit.save();

                if (flag > 0)
                {

                    return Json(new { success = true, message = "Teacher deleted successfully!" });

                }

                return Json(new { success = false, message = "Error: Unable to delete teacher" });
            }
        }

    }

