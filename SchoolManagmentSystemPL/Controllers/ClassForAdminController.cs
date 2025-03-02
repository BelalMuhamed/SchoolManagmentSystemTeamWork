using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagementSystemDAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Threading.Tasks;
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
            List<Class> Classes = await unit.ClassRepo.GetAllAsync();
            List<ClassVM> ClassesVM=new List<ClassVM>();
            if (Classes != null)
            {
                ClassesVM = mapper.Map<List<ClassVM>>(Classes);

            }
            return View(ClassesVM);
        }               


        public async Task<IActionResult> Add()
        {
            ClassVM Class = new ClassVM();
            Class.Subjects = await unit.SubjectRepo.GetAll();
            Class.Managers = await unit.TeacherRepo.GetAll();
            return View(Class);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ClassVM addedclasss)
        {
            if(ModelState.IsValid)
            {
               
                Class Addedclass = new Class()
                {
                    Name = addedclasss.ClassName,
                    ManagerId = addedclasss.ManagerId,
                   

                };
                try
                {
                    await unit.ClassRepo.Add(Addedclass);
                    int flag = await unit.save();
                    if(flag>0)
                    {
                        List<ClassAndSubjects> classSubjects = addedclasss.SelectedSubjectIds
                        .Select(subjectId => new ClassAndSubjects
                        {
                            classId = Addedclass.Id,  
                            SubjectId = subjectId       
                        }).ToList();

                     await unit.ClassAndSubjectRepo.AddRange(classSubjects);
                       await  unit.save();
                        return RedirectToAction("Index", "ClassForAdmin");
                    }
                }
                 catch
                {
                    return BadRequest();
                }
                
            }
            addedclasss.Subjects = await unit.SubjectRepo.GetAll();
            addedclasss.Managers = await unit.TeacherRepo.GetAll();

            return View("Add",addedclasss);
        }



        

        public async Task<IActionResult> AssignSubjectsToStudents(int ClassId)
        {
            var subjects = await unit.SubjectRepo.GetSubjectsByClassId(ClassId);

            var assigned = new AssignSubbjectWithTeachersToStudentVM()
            {
                ClassId = ClassId,
                Subjects = new List<SubjectWithTeachers>()
            };

            foreach (var subject in subjects)
            {
                var teachers = await unit.TeacherRepo.GetTeachersBySubjectId(subject.Id); 

                assigned.Subjects.Add(new SubjectWithTeachers
                {
                    SubjectId = subject.Id,
                    SubjectName = subject.Name,
                    Teachers = teachers, 
                    SelectedTeacherId = null
                });
            }

            return View("AssignTeachersToSubjects", assigned);
        }


        [HttpPost]
        public async Task<IActionResult> AssignSubjectsToStudents(AssignSubbjectWithTeachersToStudentVM model)
        {
            
            Class assignedClass = await unit.ClassRepo.GetById(model.ClassId);
            if (assignedClass == null)
            {
                return NotFound();
            }

            
            List<Student> assignedStudents = await unit.StudentRepo.GetByClassID(model.ClassId);
            if (assignedStudents == null)
            {
                return NotFound();
            }

            var studentDegrees = new List<StudentDegree>();

            foreach (var subject in model.Subjects)
            {
                string? assignedTeacherId = subject.SelectedTeacherId; 
                if(assignedTeacherId==null)
                {
                    return View("AssignTeachersToSubjects", model);
                }
              
                
                
                foreach (Student student in assignedStudents)
                {
                    studentDegrees.Add(new StudentDegree
                    {
                        StudentId = student.UserId,
                        SubjectId = subject.SubjectId,
                        ClassId = model.ClassId,
                        TeacherId =assignedTeacherId, 
                        Degree = 0 
                    });
                }
            }
            try
            {
                await unit.StudentDegree.AddRange(studentDegrees);


                await unit.save();

                return RedirectToAction("Index");
            }
           catch
            {
                return View("AssignTeachersToSubjects", model);

            }

        }




    }
}
