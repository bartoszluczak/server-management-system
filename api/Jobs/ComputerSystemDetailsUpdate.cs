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
    public class ComputerSystemDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private readonly IConnectionMultiplexer _redis;
        private List<string> serverNames;
        private PropertyInfo[] ComputerSystemDetailsProperties;
        private List<ComputerSystemDetails> computerSystemDetailsList;
        
        public ComputerSystemDetailsUpdate(IConfiguration iconfig, IConnectionMultiplexer redis)
        {
            _configuration = iconfig;
            _redis = redis;
            serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
            computerSystemDetailsList = new List<ComputerSystemDetails>();
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {
            var db = _redis.GetDatabase();
            var res = await db.ListGetByIndexAsync("computerSystemData", -1);

            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                ComputerSystemDetails computerSystemDetails = new ComputerSystemDetails();

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    ComputerSystemDetailsProperties = Type.GetType("ServerManagementSystem.Models.ComputerSystemDetails").GetProperties();

                    for (int i = 0; i < ComputerSystemDetailsProperties.Length; i++)
                    {
                        var currentProperty = ComputerSystemDetailsProperties[i].Name.ToString();
                        var currentValue = managementObject[currentProperty] != null ? managementObject[currentProperty].ToString() : "undefined";
                        computerSystemDetails.GetType().GetProperty(currentProperty).SetValue(computerSystemDetails, currentValue, null);
                    }
                }
                computerSystemDetailsList.Add(computerSystemDetails);

            }
                    

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel<ComputerSystemDetails>
            {
                TimeStamp = time,
                KeyName = "computerSystemData",
                Data = computerSystemDetailsList
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            if (!res.IsNullOrEmpty)
            {
                var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel<ComputerSystemDetails>>(res) : null;

                var tempData = JsonSerializer.Serialize(computerSystemDetailsList);
                var tempRes = resDeserialized.Data.ToString();

                if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                {
                   await db.ListRightPushAsync("computerSystemData", jsonObj);
                }
            }
            else
            {
               await db.ListRightPushAsync("computerSystemData", jsonObj);
            }
        }
    }
}
