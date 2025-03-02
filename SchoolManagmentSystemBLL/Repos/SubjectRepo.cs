 
﻿using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemDAL.Migrations;
using SchoolManagementSystemDAL.ViewModels;
using SchoolManagmentSystem.DAL.Models;
 
﻿using SchoolManagmentSystem.DAL.Models;
 
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Repos
{
    public class SubjectRepo : GenericRepo<Subject>
    {

        public SubjectRepo(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<List<Subject>> GetListByIDs(List<int> subjectsids)
        {
            return await context.Subjects
                          .Where(s => subjectsids.Contains(s.Id))
                          .ToListAsync();
        }
        public async Task<List<Subject>> GetSubjectsByClassId(int Classid)
        {
            return await context.classesAndSubjects.Where(s => s.classId == Classid).Select(s => s.Subject).ToListAsync();
        }
    }
}
