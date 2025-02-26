using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using System;
using System.Collections.Generic;
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
        private GenericRepo<Subject> _subjectRepo;
        StudentRepo studentRepo;
        TeacherRepo teacherRepo;

        GenericRepo<Class>classRepo;

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

        public TeacherRepo TeacherRepo
        {
            get
            {
                if (teacherRepo == null)
                    teacherRepo = new TeacherRepo(context);
                return teacherRepo;
            }
        }
        public GenericRepo<Subject> SubjectRepo
        {
            get
            {
                if (_subjectRepo == null)
                    _subjectRepo = new GenericRepo<Subject>(context);
                return _subjectRepo;
            }
        }

        public GenericRepo<Class> ClassRepo
        {
            get
            {
                if (classRepo == null)
                    classRepo = new GenericRepo<Class>(context);
                return classRepo;
            }
        }
        public async  Task<int> save()
        {
            return  await context.SaveChangesAsync();
        }
    }
}
