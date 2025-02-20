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
         GenericRepo<Student> studentRepo;

        public UnitofWork(ApplicationDbContext context)
        {
            this.context = context;
            
        }
        public GenericRepo<Student> StudentRepo
        {
            get
            {
                if (studentRepo == null)
                    studentRepo = new GenericRepo<Student>(context);
                return studentRepo;
            }
        }
        public void save()
        {
            context.SaveChanges();
        }
    }
}
