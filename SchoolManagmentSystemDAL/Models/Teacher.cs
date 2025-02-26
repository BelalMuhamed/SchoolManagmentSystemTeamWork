using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagmentSystemDAL.Models;

namespace SchoolManagmentSystem.DAL.Models 
{ 

    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public string UserId { get; set; } 

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }


        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; }
     

    }
}
