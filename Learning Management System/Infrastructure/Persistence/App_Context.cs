using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Infrastructure.Persistence
{
    public class App_Context : IdentityDbContext<User, Role, long>
    {

        public DbSet<Course> courses { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Lessons> lessons { get; set; }
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<Question> qustions { get; set; }
        public DbSet<Submission> submissions { get; set; }

        public App_Context(DbContextOptions<App_Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
          base.OnModelCreating(builder);
            builder.Entity<Course>()
                .HasOne(ca => ca.category)
                .WithMany(c => c.Courses)
                .HasForeignKey(ca => ca.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(u => u.courses)
                .HasForeignKey(c => c.InstructorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


           
            builder.Entity<Enrollment>()
                .HasOne(ca => ca.Course)
                .WithMany(c => c.enrollments)
                .HasForeignKey(ca => ca.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

           
            builder.Entity<Enrollment>()
                .HasOne(ca => ca.Student)
                .WithMany (c => c.enrollments)
                .HasForeignKey (ca => ca.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

           
            builder.Entity<Lessons>()
                .HasOne(ca => ca.Course)
                .WithMany(c => c.lessons)
                .HasForeignKey(ca => ca.CourseId)
                .OnDelete (DeleteBehavior.Restrict);

          
            builder.Entity<Question>()
                .HasOne(ca => ca.quiz)
                .WithMany(c => c.questions)
                .HasForeignKey(ca => ca.QuizId)
                .OnDelete (DeleteBehavior.Restrict);

           



        }

    }
}
