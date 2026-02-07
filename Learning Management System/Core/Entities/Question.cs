namespace Learning_Management_System.Core.Entities
{
    public class Question
    {
        public long Id { get; set; }
        public String Text { get; set; }
        public long QuizId { get; set; }
        public Quiz quiz { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

    }
}
