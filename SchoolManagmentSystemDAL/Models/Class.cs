﻿using SchoolManagmentSystem.DAL.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystemDAL.ViewModels;

namespace SchoolManagmentSystem.DAL.Models

{
    [Table("Classes")]
    public class Class : BaseModel
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } 

        
        public string? ManagerId { get; set; } 

        [ForeignKey("ManagerId")]
        public virtual Teacher manager { get; set; }
        public virtual List<ClassAndSubjects> classsubjesct { get; } = new List<ClassAndSubjects>();

    }
}
