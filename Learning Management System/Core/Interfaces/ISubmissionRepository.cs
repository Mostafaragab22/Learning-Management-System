using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface ISubmissionRepository
    {
        Task Add(Submission submission);
        public void Update(Submission submission);
        public void Delete(Submission submission);
        Task <Submission> GetById(long id);
        Task <Submission> GetByName(string Name);
        Task <IEnumerable<Submission>> GetAll();
        Task Save();
    }
}
