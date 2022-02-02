using Microsoft.Extensions.Configuration;
using Quartz;
using ServerManagementSystem.Models;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerManagementSystem.Jobs
{
    public class BiosDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private ConnectionMultiplexer _redis;

        public BiosDetailsUpdate(IConfiguration iconfig)
        {
            _configuration = iconfig;
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {
            var connectionURL = _configuration.GetValue<string>("RedisDB:connectionURL");
            var connectionPort = _configuration.GetValue<string>("RedisDB:connectionPort");
            var dbPassword = _configuration.GetValue<string>("RedisDB:dbPassword");

            _redis = ConnectionMultiplexer.Connect($"{connectionURL}:{connectionPort}, password={dbPassword}");
            var db = _redis.GetDatabase();
            var res = db.ListGetByIndex("bios", 0);

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel
            {
                TimeStamp = time,
                KeyName = "biosData",
                Data = res
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            db.ListLeftPush("biosData", jsonObj);

            Console.WriteLine();
        }
    }
}
