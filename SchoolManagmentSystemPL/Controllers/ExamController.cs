using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystemBLL.UnitOfWork;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.AspNetCore.Authorization;
using SchoolManagementSystemDAL.ViewModels;

public class ExamController : Controller
{
    private readonly UnitofWork _unitofWork;
    private readonly IMapper _mapper;
    public ExamController(UnitofWork unitofWork, IMapper mapper)
    {
        this._unitofWork = unitofWork;
        _mapper = mapper;
    }

    [Authorize(Roles = "Teacher")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var subjs = await _unitofWork.SubjectRepo.GetAll();
        ViewBag.Subjects = new SelectList(subjs, "Id", "Name"); 
        var classes = await _unitofWork.ClassRepo.GetAll();
        ViewBag.Classes = new SelectList(classes, "Id", "Name");
        return View();
    }

    [Authorize(Roles = "Teacher")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExamVM model)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            model.TeacherId = userId;
            var exam = _mapper.Map<Exam>(model);
            await _unitofWork.ExamRepo.Add(exam);
            await _unitofWork.save();
            ClassExam classExam = new ClassExam
            {
                ClassId = model.ClassId ?? 0,
                SubjectId = model.SubjectId ?? 0,
                ExamId = exam.Id
            };
            await _unitofWork.ClassExamRepo.Add(classExam);
            await _unitofWork.save();
            return RedirectToAction("CreateQuestions", new { examId = exam.Id, count = model.NumberOfQuestions });
        }
        return View(model);

    }

    [Authorize(Roles = "Teacher")]
    [HttpGet]
    public IActionResult CreateQuestions(int examId, int count)
    {
        var questions = new List<QuestionVM>();

        for (int i = 0; i < count; i++)
        {
            questions.Add(new QuestionVM
            {
                ExamId = examId,
                Answers = new List<AnswerVM>(){
                    new AnswerVM{ Text = "" },
                    new AnswerVM{ Text = "" },
                    new AnswerVM{ Text = "" },
                    new AnswerVM{ Text = "" },
                }
            });
        }

        TempData["ExamId"] = examId;
        return View(questions);
    }

    [Authorize(Roles = "Teacher")]
    [HttpPost]
    [ValidateAntiForgeryToken]     
    public async Task<IActionResult> CreateQuestions([FromBody] List<QuestionVM> model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!TempData.ContainsKey("ExamId"))
        {
            ModelState.AddModelError("", "Exam ID is missing.");
            return View(model);
        }

        int examId = (int)TempData.Peek("ExamId");

        var questions = model.Select(q => new Question
        {
            ExamId = examId,
            Body = q.Body,
            CorrectAnswerId = null, 
            Answers = new List<Answer>() 
        }).ToList();

        await _unitofWork.QuestionRepo.AddRange(questions);
        await _unitofWork.save();

        var allAnswers = new List<Answer>();
        foreach (var (q, savedQuestion) in model.Zip(questions))
        {
            var answers = q.Answers.Select(a => new Answer
            {
                QuestionId = savedQuestion.Id,
                Text = a.Text
            }).ToList();

            allAnswers.AddRange(answers);
        }

        await _unitofWork.AnswerRepo.AddRange(allAnswers);
        await _unitofWork.save();

        foreach (var q in model)
        {
            string correctAnswerText = q.Answers[q.CorrectAnswerId].Text;

            var correctAnswer = await _unitofWork.AnswerRepo.GetByTextAsync(correctAnswerText);

            if (correctAnswer != null)
            {
                var savedQuestion = await _unitofWork.QuestionRepo.GetByBodyAsync(q.Body);
                if (savedQuestion != null)
                {
                    savedQuestion.CorrectAnswerId = correctAnswer.Id;
                }
            }
        }


        await _unitofWork.save();

        return RedirectToAction("Index", "Home"); 
    }

    [Authorize(Roles = "Student")]
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var classExam = _unitofWork.ClassExamRepo.Filter(ce => ce.SubjectId == id);

        if (classExam == null)
        {
            return View();
        }
        var examEntity = await _unitofWork.ExamRepo.GetById((int)classExam.ExamId);
        if (examEntity == null)
        {
            return View();
        }

        var examDetails = new ExamDetails
        {
            ExamId = examEntity.Id,
            TeacherId = examEntity.Teacher.UserId,
            StudentId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
            TeacherName = examEntity.Teacher.User.UserName,
            Time = examEntity.Time,
            TotalDegree = examEntity.TotalDegree,
            MinDegree = examEntity.MinDegree,
            Questions = _mapper.Map<List<QuestionVM>>(examEntity.Questions),
            SubjectName = classExam.Subject.Name,
            SubjectId = classExam.SubjectId,
            ClassId = classExam.ClassId
        };

        return View(examDetails);
    }


    [HttpPost]
    public async Task<IActionResult> SubmitExam(ExamDetails examResult)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Details),examResult.ExamId);
        }

        var precent = examResult.TotalDegree > 0
    ? (examResult.Degree / (double)examResult.TotalDegree) * 100
    : 0; 

        examResult.StatusDegree = precent >= 85 ? 0 :
                                  precent >= 75 ? 1 :
                                  precent >= 65 ? 2 :
                                  precent >= 50 ? 3 : 4;

        StudentDegree studentDegree = new StudentDegree
        {
            SubjectId = examResult.SubjectId ?? 0,
            ClassId = examResult.ClassId ?? 0,
            StudentId = examResult.StudentId,
            Degree = examResult.Degree ?? 0,
            Status = (StatusDegree)examResult.StatusDegree,
            TeacherId = examResult.TeacherId,
        };

        UserExam userExam = new UserExam
        {
            ExamId = examResult.ExamId ?? 0,
            UserId = examResult.StudentId,
            Degree = examResult.Degree ?? 0,
            ClassId = examResult.ClassId ?? 0,
            Date = DateTime.Now
        };
        await _unitofWork.StudentDegree.Add(studentDegree);
        await _unitofWork.UserExam.Add(userExam);
        await _unitofWork.save();
        return RedirectToAction("Index", "Home");
    }

}
