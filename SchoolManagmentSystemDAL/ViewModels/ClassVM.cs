using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemDAL.ViewModels
{
  public  class ClassVM
    {

        public int ClassId { get; set; }

        public string ClassName { get; set; }


        public string? ManagerId { get; set; }
        public string  ManagerName { get; set; }






        public  List<Subject>? Subjects { get; set; } = new List<Subject>();
        public  List<Teacher>? Managers { get; set; } = new List<Teacher>();




    }
}
