using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        App_Context context;

        public UserRepository(App_Context _context)
        {
            context = _context;
        }
        public void Update(User user)
        {
            context.Users.Add(user);
        }
        public void Delete(User user)
        {
            context.Users.Remove(user);
        }
            
             

        public  async Task <User> GetById(long id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }
        public  async Task <User?> GetByIdAsync(long id)
        {
            return await context.Users.FindAsync(id);
        }
        public  async Task <User> GetByName(string Name)
        {
            return context.Users.FirstOrDefault(x => x.FullName == Name);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return context.Users.ToList();
        }

        public async Task Save()
        {
            context.SaveChanges();
        }
    }
}
