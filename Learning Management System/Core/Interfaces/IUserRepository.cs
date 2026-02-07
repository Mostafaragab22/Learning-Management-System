using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface IUserRepository
    {
        public void Update(User user);
        public void Delete(User user);
        Task <User> GetById(long id );
        Task<User?> GetByIdAsync(long id);
        Task <User> GetByName(string Name );
        Task <IEnumerable<User>> GetUsers();
        Task Save();

    }
}
