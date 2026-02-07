namespace Learning_Management_System.Core.Entities
{
    public class Submission
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public User Student { get; set; }

        public long QuizId { get; set; } 
        public Quiz quiz {  get; set; }
        public double Score { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;


    }
}
