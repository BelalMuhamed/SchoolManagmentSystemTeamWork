using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemDAL.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExamVM
    {
        public int? Id { get; set; }

        public string? TeacherId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }

        [Required(ErrorMessage = "Time is required.")]
        [Range(1, 300, ErrorMessage = "Time must be between 1 and 300 minutes.")]
        public int? Time { get; set; }

        [Required(ErrorMessage = "Total Degree is required.")]
        [Range(1, 1000, ErrorMessage = "Total Degree must be between 1 and 1000.")]
        public int? TotalDegree { get; set; }

        [Required(ErrorMessage = "Minimum Degree is required.")]
        [Range(0, 1000, ErrorMessage = "Minimum Degree must be between 0 and 1000.")]
        public double? MinDegree { get; set; }

        [Required(ErrorMessage = "Number of Questions is required.")]
        [Range(1, 500, ErrorMessage = "Number of Questions must be between 1 and 500.")]
        public int? NumberOfQuestions { get; set; }
    }



}
