using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface IQuestionRepository
    {
        Task Add(Question questions);
        public void Update(Question question);
        public void Delete(Question question);
        Task <IEnumerable<Question>> GetQuestions();
        Task Save();
        Task <Question> GetQuestion(long id);
    }
}
