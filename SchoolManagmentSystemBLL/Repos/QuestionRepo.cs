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
    public class QuestionRepo : GenericRepo<Question>
    {
        public QuestionRepo(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Question?> GetByBodyAsync(string Body)
        {
            return await context.Questions
                .FirstOrDefaultAsync(x => x.Body == Body);
        }
    }

}
