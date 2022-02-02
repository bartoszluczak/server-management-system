using Quartz;
using StackExchange.Redis;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ServerManagementSystem.Jobs
{
    public class SimpleJob : IJob
    {
        static readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost:6379, password=default");
        public async Task Execute(IJobExecutionContext context)
        {


            var db = _redis.GetDatabase();

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
  
            db.ListLeftPush("test", time.ToString());

            var msg = $"Test job ${DateTime.Now.ToString()}";
            Console.Out.WriteLine(msg);
        }
    }
}
