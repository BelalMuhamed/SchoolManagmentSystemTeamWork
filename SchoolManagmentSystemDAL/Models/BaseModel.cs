﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystem.DAL.Models

{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
