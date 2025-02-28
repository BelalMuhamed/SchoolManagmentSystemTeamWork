using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class ExamDetails
    {
        public List<QuestionVM>? Questions { get; set; }
        public string? TeacherName { get; set; }
        public string? SubjectName { get; set; }
        public int? Time { get; set; }
        public int? TotalDegree { get; set; }
        public double? MinDegree { get; set; }
        public int? ExamId { get; set; }
        public string? StudentId { get; set; }
        public int? Degree { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }
        public string? TeacherId { get; set; }
        public int? StatusDegree { get; set; }

    }
}
