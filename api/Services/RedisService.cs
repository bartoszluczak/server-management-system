using Microsoft.Extensions.Configuration;
using ServerManagementSystem.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace ServerManagementSystem.Services
{
    public class RedisService
    {
        private readonly IConfiguration _config;
        private ConnectionMultiplexer _redis;

        public RedisService(IConfiguration config)
        {
            _config = config;
        }

        public ConnectionMultiplexer Connect()
        {
            var connectionURL = _config.GetValue<string>("RedisDB:connectionURL");
            var connectionPort = _config.GetValue<string>("RedisDB:connectionPort");
            var dbPassword = _config.GetValue<string>("RedisDB:dbPassword");
            _redis = ConnectionMultiplexer.Connect($"{connectionURL}:{connectionPort}, password={dbPassword}");
            return _redis;
        }

        public void Disconnect()
        {
            _redis.Close();
        }

        public RedisDataModel FetchData(string dataFieldName, int index)
        {
            Connect();
            var db = _redis.GetDatabase();
            var res = db.ListGetByIndex(dataFieldName, index);

            //if (res.IsNullOrEmpty)
            //{
                
            //}

            var data = JsonSerializer.Deserialize<RedisDataModel>(res);
            Disconnect();
            return data;
        }
            

    }
}
