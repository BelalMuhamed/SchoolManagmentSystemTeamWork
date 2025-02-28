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
        public IgenericRepo<Subject> subrepo;
        StudentRepo studentRepo;
        ClassRepo classRepo;
        GenericRepo<Subject> SubRepo;
        TeacherRepo teacherRepo;
        private GenericRepo<Exam> examRepo;
        private GenericRepo<UserExam> userExamRepo;
        private GenericRepo<StudentDegree> studentDegreeRepo;
        private ClassExamRepo classExam;
        private QuestionRepo questionRepo;
        private AnswerRepo answerRepo;
        ManageTeacherAttendanceRepo manageTeacherAttendanceRepo;



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


        public SubjectRepo SubjectRepo
        {
            get
            {
                if (subjectRepo == null)
                    subjectRepo = new SubjectRepo(context);
                return subjectRepo;
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
        public GenericRepo<StudentDegree> StudentDegree
        {
            get
            {
                if (studentDegreeRepo == null)
                    studentDegreeRepo = new GenericRepo<StudentDegree>(context);
                return studentDegreeRepo;
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


        public QuestionRepo QuestionRepo => questionRepo ??= new QuestionRepo(context);
        public AnswerRepo AnswerRepo => answerRepo ??= new AnswerRepo(context);

        public async  Task<int> save()
        {
            return  await context.SaveChangesAsync();
        }
    }
}
