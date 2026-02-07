using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Application.Services;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using Learning_Management_System.Infrastructure.Repositories;

namespace Learning_Management_System.API.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Services.AddScoped<ICourseRepository, CourseRepository>();
            Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            Services.AddScoped<ILessonRepository, LessonRepository>();
            Services.AddScoped<IQuizRepository, QuizRepository>();
            Services.AddScoped<IQuestionRepository, QuestionRepository>();
            Services.AddScoped<ISubmissionRepository, SubmissionRepository>();

            Services.AddScoped<IEmailService, SendGridEmailService>();
            Services.AddScoped<ICacheService, RedisCacheService>();

            return Services;
        }
    }
}
