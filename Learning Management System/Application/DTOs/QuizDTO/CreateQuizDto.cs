using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.DTOs.QuizDTO
{
    public class CreateQuizDto
    {
        
        public string Title { get; set; }
        public long LessonId { get; set; }
        public string LessonName { get; set; }
        public string CourseName { get; set; }
        public long CourseId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
