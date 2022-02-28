using Microsoft.Extensions.Configuration;
using ServerManagementSystem.Models;
using StackExchange.Redis;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerManagementSystem.Services
{
    public class RedisService
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<T> FetchData<T>(string dataFieldName, int index)
        {
            var db = _redis.GetDatabase();
            var res = await db.ListGetByIndexAsync(dataFieldName, index);
            var data = JsonSerializer.Deserialize<T>(res);
            return data;
        }

        public async Task<T> FetchList<T>(string dataFieldName, int startIndex, int endIndex)
        {
            var db = _redis.GetDatabase();
            var res = await db.ListRangeAsync(dataFieldName, startIndex, endIndex);
            var resString = res.ToString();
            var data = JsonSerializer.Deserialize<T>(resString);
            return data;
        }
            

    }
}
