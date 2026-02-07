using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.DTOs.CourseDTO
{
    public class CoursesResponseDto
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public long InstructorId { get; set; }
        public string InstructorName { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public List<Lessons> lessons { get; set; }
    }
}
