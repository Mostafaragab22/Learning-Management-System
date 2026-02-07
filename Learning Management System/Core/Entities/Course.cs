using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Core.Entities
{
    public class Course
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get;set; }
       
        public string InstructorName { get; set; }
        public long? InstructorId { get; set; }
        public User? Instructor { get; set; }


        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category category { get; set; }

        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Enrollment> enrollments { get; set; }
        public ICollection<Lessons> lessons { get; set; }
        public ICollection<Quiz> quizzes { get; set; }


    }
}
