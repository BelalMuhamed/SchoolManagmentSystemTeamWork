using SchoolManagmentSystem.DAL.Models;

namespace SchoolManagmentSystemDAL.ViewModels
{
    public class StudentAttendanceVM
    {

        public string StudentId { get; set; }
        public string? StudentName { get; set; }
        public AttendanceStatus Status { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

    }

}
