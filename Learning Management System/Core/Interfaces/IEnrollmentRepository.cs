using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task Add(Enrollment enrollment);
        public void Update(Enrollment enrollment);
        Task <Enrollment> GetById(long id);
        Task <Enrollment> GetByStudentId(long studentId);
        public void Delete (Enrollment enrollment);
        Task <IEnumerable<Enrollment>> GetAll();
        Task Save();
    }
}
