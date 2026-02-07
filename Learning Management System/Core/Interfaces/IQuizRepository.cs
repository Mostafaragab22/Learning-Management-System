using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface IQuizRepository
    {
        Task Add(Quiz quiz);
        public void Update(Quiz quiz);
        public void Delete(Quiz quiz);
        Task <Quiz> GetById(long id);
        Task <Quiz> GetByName(string Name);
        Task <IEnumerable<Quiz>> GetAll();
        Task Save();
    }
}
