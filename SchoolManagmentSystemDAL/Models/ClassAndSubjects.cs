using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Models

{
    [PrimaryKey(nameof(classId), nameof(SubjectId))]
    public class ClassAndSubjects
    {
        public int classId { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("classId")]
        public virtual Class Class { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

       

    }
}
