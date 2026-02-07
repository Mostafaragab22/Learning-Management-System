using Microsoft.AspNetCore.Mvc;

namespace Learning_Management_System.Core.Entities
{
    public class Quiz
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long LessonId { get; set; }
        public string LessonName { get; set; }
        public Lessons Lesson { get; set; }

        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public Course Course { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Question> questions { get; set; }
    }
}
