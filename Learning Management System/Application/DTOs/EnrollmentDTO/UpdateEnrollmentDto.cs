using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Application.DTOs.EnrollmentDTO
{
    public class UpdateEnrollmentDto
    {
        public long? CourseId { get; set; }
        public EnrollmentStatus? Status { get; set; }

    }
}
