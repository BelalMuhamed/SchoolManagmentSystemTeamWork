using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using SchoolManagmentSystemDAL.ViewModels;

//[Authorize]
[Authorize(Roles = "Teacher, Admin")]
public class StudentAttendanceController : Controller
{
    private readonly UnitofWork _unitOfWork;

    public StudentAttendanceController(UnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<IActionResult> Index()
    {
        var attendanceList = _unitOfWork.StudentAttendanceRepo.GetAll().Result.Select(x => new StudentAttendanceVM
        {
            Date = x.Date,
            StudentId = x.StudentId,
            Status = x.Status,
            StudentName = x.student?.User?.UserName

        }).ToList();




        return View(attendanceList);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {

        var students = await _unitOfWork.StudentRepo.GetAll();
        if (!students.Any())
        {
            return View();
        }
        ViewBag.Students = students.Select(s => new SelectListItem
        {
            Value = s.UserId,
            Text = s.User != null ? s.User.UserName : "No Name" // Handling null User
        }).ToList();

        return View("Create");
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentAttendanceVM model)
    {


        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var students = await _unitOfWork.StudentRepo.GetAll();



        var studentName = _unitOfWork.StudentAttendanceRepo.GetAll().Result.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
        if (studentName != null)
        {


            ModelState.AddModelError("", "Student Already Added !.");

            ViewBag.Students = students.Select(s => new SelectListItem
            {
                Value = s.UserId,
                Text = s.User != null ? s.User.UserName : "No Name" // Handling null User
            }).ToList();
            return View();

        }

        var Std = new StudentAttendance()
        {
            StudentId = model.StudentId,
            Status = model.Status,
            Date = model.Date,

        };
        await _unitOfWork.StudentAttendanceRepo.Add(Std);
        await _unitOfWork.save();
        if (!students.Any())
        {
            return View(model);
        }
        ViewBag.Students = students.Select(s => new SelectListItem
        {
            Value = s.UserId,
            Text = s.User != null ? s.User.UserName : "No Name"
        }).ToList();
        return RedirectToAction(nameof(Index));

    }


    public async Task<IActionResult> Edit(string id)
    {
        var attendance = await _unitOfWork.StudentAttendanceRepo.GetByStudentIds(id);
        if (attendance == null)
        {
            return NotFound();
        }

        var students = await _unitOfWork.StudentRepo.GetAll();
        ViewBag.Students = students.Select(s => new SelectListItem
        {
            Value = s.UserId,
            Text = s.User != null ? s.User.UserName : "No Name"
        }).ToList();

        var model = new StudentAttendanceVM
        {
            StudentId = attendance.StudentId,
            Status = attendance.Status,
            Date = attendance.Date
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(StudentAttendanceVM model, string id)
    {
        if (!ModelState.IsValid)
        {
            var students = await _unitOfWork.StudentRepo.GetAll();
            ViewBag.Students = students.Select(s => new SelectListItem
            {
                Value = s.UserId,
                Text = s.User != null ? s.User.UserName : "No Name"
            }).ToList();

            return View(model);
        }

        var attendance = await _unitOfWork.StudentAttendanceRepo.GetByStudentIds(id);
        if (attendance == null)
        {
            return NotFound();
        }


        attendance.StudentId = model.StudentId;
        attendance.Status = model.Status;
        attendance.Date = model.Date;

        _unitOfWork.StudentAttendanceRepo.Update(attendance);
        await _unitOfWork.save();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Remove(string id)
    {
        var student = await _unitOfWork.StudentAttendanceRepo.GetByStudentIds(id);
        if (student == null)
        {
            var attendanceList = _unitOfWork.StudentAttendanceRepo.GetAll().Result.Select(x => new StudentAttendanceVM
            {
                Date = x.Date,
                StudentId = x.StudentId,
                Status = x.Status,
                StudentName = x.student?.User?.UserName

            }).ToList();
            return View("index",attendanceList);
        }

        _unitOfWork.StudentAttendanceRepo.DeleteAsync(student);
        await _unitOfWork.save();

        return RedirectToAction("Index");
    }
}


