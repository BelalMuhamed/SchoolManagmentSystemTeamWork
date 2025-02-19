using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoolManagmentSystem.DAL.Models
{
    [Table("Questions")]
    public class Question : BaseModel
    {
        [Required]
        [StringLength(1000)]
        public string Body { get; set; } = null!;

        [Required]
        public int ExamId { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; } = null!;

        public int CorrectAnswerId { get; set; }

        [ForeignKey("CorrectAnswerId")]
        public virtual Answer? CorrectAnswer { get; set; }

        public virtual List<Answer> Answers { get; } = new List<Answer>();
    }

}
