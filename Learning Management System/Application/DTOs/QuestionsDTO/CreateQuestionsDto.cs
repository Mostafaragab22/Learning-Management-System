namespace Learning_Management_System.Application.DTOs.QuestionsDTO
{
    public class CreateQuestionsDto
    {
       
        public String Text { get; set; }
        public long QuizId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
