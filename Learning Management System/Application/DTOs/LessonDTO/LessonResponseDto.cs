namespace Learning_Management_System.Application.DTOs.LessonDTO
{
    public class LessonResponseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ContentUrl { get; set; }
        public long? CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
