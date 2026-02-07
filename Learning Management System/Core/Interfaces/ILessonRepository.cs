using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface ILessonRepository
    {
        Task Add(Lessons lesson);
        public void Update(Lessons lesson);
        public void Delete(Lessons lessons);
        Task  <Lessons> GetById(long id);
        Task <Lessons> GetByTitle(string Name);
        Task <IEnumerable<Lessons>> Getlessons();
        Task Save();
    }
}
