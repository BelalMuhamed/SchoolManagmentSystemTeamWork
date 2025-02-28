using SchoolManagmentSystem.DAL.Extend;
using SchoolManagementSystemDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("Subjects")]
    public class Subject : BaseModel
    {
        //[Required]      
        //public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 1000)]
        public int TotalDegree { get; set; }

        [Required]
        [Range(0, 100)]
        public double MinDegree { get; set; }
        public virtual List<Teacher> Teachers { get; } = new List<Teacher>();
        public virtual List<ClassAndSubjects> classsubjesct { get; } = new List<ClassAndSubjects>();

    }

}
