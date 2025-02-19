using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("StudentPhones")]
    [PrimaryKey(nameof(StudentId),nameof(Phones))]
    public class StudentPhone
    {
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }
        [Required]
        [StringLength(20)]
        public string Phones { get; set; } = null!;
    }

}
