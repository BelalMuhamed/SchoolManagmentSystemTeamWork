using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("Classes")]
    public class Class : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        public string ManagerId { get; set; } = null!;

        [ForeignKey("ManagerId")]
        public virtual ApplicationUser User { get; set; }
    }
}
