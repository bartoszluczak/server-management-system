using Microsoft.Extensions.Configuration;
using Quartz;
using ServerManagementSystem.Models;
using ServerManagementSystem.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerManagementSystem.Jobs
{
    public class BiosDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private readonly IConnectionMultiplexer _redis;
        private List<string> serverNames;
        private PropertyInfo[] BiosDetailsProperties;
        private List<BiosDetails> biosDetailsList;

        public BiosDetailsUpdate(IConfiguration iconfig, IConnectionMultiplexer redis)
        {
            _configuration = iconfig;
            serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
            biosDetailsList = new List<BiosDetails>();
            _redis = redis;
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {

            var db = _redis.GetDatabase();
            var res = await db.ListGetByIndexAsync("biosData", -1);

            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BIOS");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                BiosDetails biosDetails = new BiosDetails();

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    BiosDetailsProperties = Type.GetType("ServerManagementSystem.Models.BiosDetails").GetProperties();

                    for (int i = 0; i < BiosDetailsProperties.Length; i++)
                    {
                        var currentProperty = BiosDetailsProperties[i].Name.ToString();
                        var currentValue = managementObject[currentProperty] != null ? managementObject[currentProperty].ToString() : "undefined";
                        biosDetails.GetType().GetProperty(currentProperty).SetValue(biosDetails, currentValue, null);
                    }
                }
                biosDetailsList.Add(biosDetails);

            }
                    

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel
            {
                TimeStamp = time,
                KeyName = "biosData",
                Data = biosDetailsList
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            if (!res.IsNullOrEmpty)
            {
                var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel>(res) : null;

                var tempData = JsonSerializer.Serialize(biosDetailsList);
                var tempRes = resDeserialized.Data.ToString();

                if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                {
                   await db.ListRightPushAsync("biosData", jsonObj);
                }
            }
            else
            {
                await db.ListRightPushAsync("biosData", jsonObj);
            }
        }
    }
}
