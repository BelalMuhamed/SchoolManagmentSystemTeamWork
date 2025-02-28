using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using SchoolManagmentSystemBLL.Repos;
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
        
        StudentRepo studentRepo;
        SubjectRepo subjectRepo;

         GenericRepo<Class>classRepo;   
     TeacherRepo teacherRepo;
        
       
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

       
        public async  Task<int> save()
        {
            return  await context.SaveChangesAsync();
        }
    }
}
