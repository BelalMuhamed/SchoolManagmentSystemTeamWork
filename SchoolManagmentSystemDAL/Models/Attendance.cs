using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.DAL.Models
{

    [Table("Attendances")]
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

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
