using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Application.Services;

namespace Learning_Management_System.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IJwtService, JwtService>();
            
            services.AddScoped<IEmailService, SendGridEmailService>();

            return services;
        }
    }
}
