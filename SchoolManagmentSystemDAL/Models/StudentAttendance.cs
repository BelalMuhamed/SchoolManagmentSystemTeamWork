using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemDAL.Models
{
    [Table("StudentAttendances")]
    public class StudentAttendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student student { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

    public enum AttendanceStatus
    {
        Present,
        Absent
    }


}

