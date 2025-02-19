using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Models
{
    [PrimaryKey(nameof(UserId),nameof(ExamId),nameof(ClassId))]
    [Table("UserExams")]
    public class UserExam
    {
        [Column(Order = 1)]
        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual ApplicationUser? ApplicationUser { get; set; }

        [Column(Order = 2)]
        public int ExamId { get; set; } 

        [ForeignKey("ExamId")]
        public virtual Exam? Exam { get; set; } 

        [Required]
        [Column(Order = 3)]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }

        [Required]
        [Range(0, 500)]
        public double Degree { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

}
