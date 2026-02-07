using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Learning_Management_System.API.Extensions;

public static class RateLimitingExtensions
{
    public static IServiceCollection AddRateLimiting(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddRateLimiter(options =>
        {
            
            options.AddFixedWindowLimiter("Global", opt =>
            {
                opt.PermitLimit = config.GetValue<int>("RateLimiting:Global:PermitLimit");
                opt.Window = TimeSpan.FromSeconds(
                    config.GetValue<int>("RateLimiting:Global:WindowSeconds"));
                opt.QueueLimit = 0;
            });

   
            options.AddFixedWindowLimiter("Login", opt =>
            {
                opt.PermitLimit = config.GetValue<int>("RateLimiting:Login:PermitLimit");
                opt.Window = TimeSpan.FromSeconds(
                    config.GetValue<int>("RateLimiting:Login:WindowSeconds"));
                opt.QueueLimit = 0;
            });
        });

        return services;
    }
}
