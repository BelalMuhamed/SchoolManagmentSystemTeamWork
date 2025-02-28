using SchoolManagmentSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class QuestionVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Question body is required.")]
        [StringLength(500, ErrorMessage = "Question body must be at most 500 characters.")]
        public string Body { get; set; } = null!;

        [Required(ErrorMessage = "Exam ID is required.")]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Correct Answer ID is required.")]
        public int CorrectAnswerId { get; set; }

        [Required(ErrorMessage = "Answers list cannot be empty.")]
        [MinLength(2, ErrorMessage = "At least two answers are required.")]
        [MaxLength(6, ErrorMessage = "At most six answers are allowed.")]
        public List<AnswerVM> Answers { get; set; } = new();
    }

}
