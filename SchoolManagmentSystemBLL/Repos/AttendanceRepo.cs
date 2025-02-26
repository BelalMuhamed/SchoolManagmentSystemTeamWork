using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Repos
{
    public class AttendanceRepo :GenericRepo<AttendanceRepo>
    {
        public AttendanceRepo(ApplicationDbContext context) : base(context)
        {

        }
       

    }
}
