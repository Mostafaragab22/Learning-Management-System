namespace Learning_Management_System.Application.DTOs.CourseDTO
{
    public class UpdateCourseDto
    {
        
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public int? InstructorId { get; set; }
        public string? InstructorName { get; set; }
        public long? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public decimal? Price { get; set; }
    }
}
