using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.DAL.Extend;
using SchoolManagmentSystem.DAL.Models;

namespace SchoolManagmentSystem.PL.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public DbSet<ClassLesson> ClassLessons { get; set; }
        public DbSet<StudentDegree> StudentDegrees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ClassExam> ClassExams { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<StudentPhone> StudentPhones { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
