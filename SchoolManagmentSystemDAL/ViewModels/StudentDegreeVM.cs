using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class StudentDegreeVM
    {


        public List<Student> Students { get; set; } = new List<Student>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Class> Classs { get; set; } = new List<Class>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public string StudentId { get; set; }  
        public int SubjectId { get; set; }     
        public int ClassId { get; set; }      
        public string TeacherId { get; set; }  

        public double Degree { get; set; }
        public StatusDegree Status { get; set; }


    }
}
