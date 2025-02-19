using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("ClassLessons")]
    public class ClassLesson : BaseModel
    {
        [Required]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; } = null!;

        [Required]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; } = null!;

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; } = null!;
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

    }

}
