using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("Exams")]
    public class Exam : BaseModel
    {
        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }
        public string TeacherId { get; set; }
        [Required]
        [Range(1, 300)]
        public int Time { get; set; }

        [Required]
        [Range(1, 1000)]
        public int TotalDegree { get; set; }

        [Required]
        [Range(0, 100)]
        public double MinDegree { get; set; }
        public virtual List<Question> Questions { get; } = new List<Question>();
    }

}
