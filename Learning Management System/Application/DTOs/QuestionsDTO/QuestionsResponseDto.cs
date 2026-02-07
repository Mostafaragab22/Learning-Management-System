namespace Learning_Management_System.Application.DTOs.QuestionsDTO
{
    public class QuestionsResponseDto
    {
        public long Id { get; set; }
        public String Text { get; set; }
        public long QuizId { get; set; }

        public DateTime CreatedAt { get; set; } 
    }
}
