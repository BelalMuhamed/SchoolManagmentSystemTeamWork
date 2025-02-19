using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.DAL.Models
{

    [Table("ClassExams")]
    [PrimaryKey(nameof(ClassId), nameof(ExamId))] 
    public class ClassExam
    {
        [Required]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }

        [Required]
        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam? Exam { get; set; }
    }

}
