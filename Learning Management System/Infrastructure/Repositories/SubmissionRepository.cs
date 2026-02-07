using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class SubmissionRepository:ISubmissionRepository
    {
        App_Context context;

        public SubmissionRepository(App_Context _context)
        {
            context = context;
        }

        public async Task Add(Submission submission)
        {
            context.submissions.Add(submission);
        }

        public void Update(Submission submission)
        {
            context.submissions.Update(submission);
        }

        public async Task <Submission> GetById(long id)
        {
            return context.submissions
                .Include(x=>x.Student )
                .Include(x=>x.quiz )
                .FirstOrDefault(x => x.Id == id);
        }
        public async Task <IEnumerable<Submission>> GetAll()
        {
            return context.submissions
                .Include(x => x.Student)
                .Include(x => x.quiz);
              
        }
        public async Task<Submission> GetByName(string Name)
        {
            return context.submissions
                .Include(x => x.Student)
                .Include(x => x.quiz)
                .FirstOrDefault(x => x.Student.FullName == Name);

        }
        public void Delete(Submission submission)
        {         
                context.submissions.Remove(submission);  
        }
        public async Task Save()
        {
            context.SaveChanges();
        }
    }
}
