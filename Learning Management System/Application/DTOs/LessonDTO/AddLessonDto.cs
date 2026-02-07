namespace Learning_Management_System.Application.DTOs.LessonDTO
{
    public class AddLessonDto
    {
        public string Title { get; set; }
        public string ContentUrl { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
