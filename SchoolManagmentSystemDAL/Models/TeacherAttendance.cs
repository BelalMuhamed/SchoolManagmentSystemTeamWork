using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("TeacherAttendances")]
    [PrimaryKey(nameof(TeacherId),nameof(Date))]
    public class TeacherAttendance
    {
       

        [Required]
        public string TeacherId {get; set; }

        [ForeignKey("TeacherId")] 
        public virtual Teacher teacher { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }

        [Required]
        public DateOnly Date { get; set; }

    }

    public enum AttendanceStatus
    {
        Present,
        Absent
    }


}
