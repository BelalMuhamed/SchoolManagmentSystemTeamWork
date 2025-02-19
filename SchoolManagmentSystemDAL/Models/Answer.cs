using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("Answers")]
    public class Answer : BaseModel
    {
        [Required]
        [StringLength(500)]
        public string Text { get; set; } = null!;

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [NotMapped]
        public virtual Question? Question { get; set; }
    }

}
