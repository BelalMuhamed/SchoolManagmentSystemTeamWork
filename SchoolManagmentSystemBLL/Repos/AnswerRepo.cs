using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Models;
using SchoolManagmentSystem.PL.Data;
using SchoolManagmentSystemBLL.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemBLL.Repos
{
    public class AnswerRepo : GenericRepo<Answer>
    {
        public AnswerRepo(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Answer?> GetByTextAsync(string text)
        {
            return await context.Answers
                            .FirstOrDefaultAsync(x => x.Text == text); 

        }
    }
}
