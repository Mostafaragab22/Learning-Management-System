using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Application.DTOs.EnrollmentDTO
{
    public class EnrollmentResponseDto
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public string StudentName { get; set; }

        public string CourseName { get; set; }
        public EnrollmentStatus Status { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.Now;
    }
}
