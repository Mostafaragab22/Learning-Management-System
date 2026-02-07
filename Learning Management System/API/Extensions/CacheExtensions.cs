using Learning_Management_System.Infrastructure.Caching;
using Learning_Management_System.Application.Services;
using StackExchange.Redis;

namespace Learning_Management_System.API.Extensions
{
    public static class CacheExtensions
    {
        public static IServiceCollection AddCaching(
            this IServiceCollection services, IConfiguration config)
        {
 
            var redis = ConnectionMultiplexer.Connect(config["Redis:ConnectionString"]);
            services.AddSingleton<IConnectionMultiplexer>(redis);

           
            services.AddScoped<ICacheService, RedisCacheService>();

            return services;
        }
    }
}