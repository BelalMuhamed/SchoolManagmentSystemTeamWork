using Microsoft.AspNetCore.Identity;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using SchoolManagmentSystemBLL.Repos;
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
        StudentRepo studentRepo;
        ClassRepo classRepo;
        
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
        public ClassRepo ClassRepo
        {
            get
            {
                if (classRepo == null)
                    classRepo = new ClassRepo(context);
                return classRepo;
            }
        }
        //public AttendanceRepo TechAttendance
        //{
        //    get
        //    {
        //        if (techattendance == null)
        //            techattendance = new AttendanceRepo(context);
        //        return techattendance;
        //    }
        //}
        public async  Task<int> save()
        {
            return  await context.SaveChangesAsync();
        }
    }
}
