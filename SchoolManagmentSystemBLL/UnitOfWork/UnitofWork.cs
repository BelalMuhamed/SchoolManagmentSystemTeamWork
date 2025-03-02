using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using SchoolManagmentSystemBLL.IGenericRepos;
using SchoolManagmentSystemBLL.Repos;
using SchoolManagmentSystemBLL.IGenericRepos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.UnitOfWork
{
    public  class UnitofWork
    {
        private readonly ApplicationDbContext context;
        public UserManager<ApplicationUser> user;
        public SignInManager<ApplicationUser> sign;
        private ScheduleRepo _classLessonRepo;
        StudentDegreeRepo stuDegreeRepo;
        StudentRepo studentRepo;
        ClassRepo classRepo;
        SubjectRepo SubRepo;
        TeacherRepo teacherRepo;
        ClassAndSubjectRepo classAndSubRepo;
        private GenericRepo<Exam> examRepo;
        private GenericRepo<UserExam> userExamRepo;
      
        private ClassExamRepo classExam;
        private QuestionRepo questionRepo;
        private AnswerRepo answerRepo;
        ManageTeacherAttendanceRepo manageTeacherAttendanceRepo;
        private StudentAttendanceRepo _studentattendanceRepo;

        


        public UnitofWork(ApplicationDbContext context,UserManager<ApplicationUser> user, SignInManager<ApplicationUser> sign)
        {
            this.context = context;
            this.user = user;
            this.sign = sign;
        }
        public StudentRepo StudentRepo
        {
            get
            {
                if (studentRepo == null)
                    studentRepo = new StudentRepo(context);
                return studentRepo;
            }
        }
     

        public ClassAndSubjectRepo ClassAndSubjectRepo
        {
            get
            {
                if (classAndSubRepo == null)
                    classAndSubRepo = new ClassAndSubjectRepo(context);
                return classAndSubRepo;
            }
        }

        public SubjectRepo SubjectRepo
        {
            get
            {
                if (SubRepo == null)
                    SubRepo = new SubjectRepo(context);
                return SubRepo;
            }
        }

        public ScheduleRepo ClassLessonRepo
        {
            get
            {
                if (_classLessonRepo == null)
                    _classLessonRepo = new ScheduleRepo(context);
                return _classLessonRepo;
            }
        }



        public TeacherRepo TeacherRepo
        {
            get
            {
                if (teacherRepo == null)
                    teacherRepo = new TeacherRepo(context);
                return teacherRepo;
            }
        }

        public ClassRepo ClassRepo {
            get
            {
                if (classRepo == null)
                    classRepo = new ClassRepo(context);
                return (ClassRepo)classRepo;
            }
        }
  
        public ManageTeacherAttendanceRepo manageteacherAttendanceRepo
        {
            get
            {
                if (manageTeacherAttendanceRepo == null)
                    manageTeacherAttendanceRepo = new ManageTeacherAttendanceRepo(context);
                return manageTeacherAttendanceRepo;
            }
        }

        public GenericRepo<Exam> ExamRepo
        {
            get
            {
                if (examRepo == null)
                    examRepo = new GenericRepo<Exam>(context);
                return examRepo;
            }
        }
        public StudentDegreeRepo StudentDegree
        {
            get
            {
                if (stuDegreeRepo == null)
                    stuDegreeRepo = new StudentDegreeRepo(context);
                return stuDegreeRepo;
            }
        }

        public GenericRepo<UserExam> UserExam
        {
            get
            {
                if (userExamRepo == null)
                    userExamRepo = new GenericRepo<UserExam>(context);
                return userExamRepo;
            }
        }

        public ClassExamRepo ClassExamRepo
        {
            get
            {
                if (classExam == null)
                    classExam = new ClassExamRepo(context);
                return classExam;
            }
        }

        public StudentAttendanceRepo StudentAttendanceRepo
        {
            get
            {
                if (_studentattendanceRepo == null)
                    _studentattendanceRepo = new StudentAttendanceRepo(context);
                return _studentattendanceRepo;
            }
        }

        public QuestionRepo QuestionRepo => questionRepo ??= new QuestionRepo(context);
        public AnswerRepo AnswerRepo => answerRepo ??= new AnswerRepo(context);

        public async  Task<int> save()
        {
            return  await context.SaveChangesAsync();
        }
    }
}
