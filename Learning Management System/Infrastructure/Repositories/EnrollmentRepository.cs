using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        App_Context context;

        public EnrollmentRepository(App_Context _context)
        {
            context = _context;
        }

        public async Task Add(Enrollment enrollment)
        {
            context.enrollments.Add(enrollment);
        }

        public void Update(Enrollment enrollment)
        {
            context.enrollments.Update(enrollment);
        }
        public async Task<Enrollment> GetById(long id)
        {
            return context.enrollments.Include(x => x.Course)
                .Include(x => x.Student)
                .FirstOrDefault(x => x.Id == id);
        }
        public async Task<Enrollment> GetByStudentId(long studentId)
        {
            return context.enrollments.Include(x => x.Course)
                .Include(x => x.Student)
                .FirstOrDefault(x => x.Student.Id == studentId);
        }

        public void Delete(Enrollment enrollment)
        {
                context.enrollments.Remove(enrollment);
        }
        public async Task Save()
        {
            context.SaveChanges();
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return context.enrollments.Include(x => x.Course)
                .Include(x => x.Student);
        }
    }
}
