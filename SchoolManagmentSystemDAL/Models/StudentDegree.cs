using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.DAL.Models

{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentDegrees")]
    [PrimaryKey(nameof(StudentId), nameof(SubjectId), nameof(ClassId), nameof(TeacherId))]
    public class StudentDegree
    {
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }

        [Required]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }

        [Required]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }

        [Required]
        [Range(0, 100)]
        public double Degree { get; set; }

        [Required]
        public StatusDegree Status { get; set; }
    }

    public enum StatusDegree
    {
        A, B, C, D, F
    }

}
