namespace Learning_Management_System.Application.DTOs.EnrollmentDTO
{
    public class EnrollCourseDto
    {

        public long StudentId { get; set; }
        public long CourseId { get; set; }

        public DateTime EnrolledAt { get; set; }
    }
}
