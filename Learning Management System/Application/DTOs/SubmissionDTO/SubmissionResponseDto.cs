using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.DTOs.SubmissionDTO
{
    public class SubmissionResponseDto
    {
        public int Id { get; set; }
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public string QuizTitle { get; set; }
        public long QuizId { get; set; }
        public double Score { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

    }
}
