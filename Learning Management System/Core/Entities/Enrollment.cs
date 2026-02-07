using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Core.Entities
{
    public class Enrollment
    {
        public long Id { get; set; }

        public long StudentId { get; set; }
        public User Student {  get; set; }


        public long CourseId { get; set; }
        public Course Course { get; set; }
        public EnrollmentStatus Status { get; set; }= EnrollmentStatus.Pending;

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
