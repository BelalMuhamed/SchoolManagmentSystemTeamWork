﻿using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public string UserId { get; set; } 

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        
      
        [Required]
        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }
    }

}
