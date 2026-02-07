using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.DTOs.QuizDTO
{
    public class QuizResponseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long LessonId { get; set; }
        public string LessonName { get; set; }
        public string CourseName { get; set; }
        public long CourseId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Question> questions { get; set; }
    }
}
