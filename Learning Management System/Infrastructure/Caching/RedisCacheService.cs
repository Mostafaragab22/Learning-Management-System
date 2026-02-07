using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Learning_Management_System.Infrastructure.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly StackExchange.Redis.IDatabase _db; 

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        
        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var json = JsonConvert.SerializeObject(value);
            await _db.StringSetAsync(key, json, (Expiration)expiration);
        }

        
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _db.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;
            return JsonConvert.DeserializeObject<T>(value);
        }
        public async Task RemoveAsync(string key)
        {
            await _db.KeyDeleteAsync(key);
        }
    }
}
