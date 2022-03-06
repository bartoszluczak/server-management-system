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
    public class DefaultJob<T>
    { 
        public class Job: IJob
        {

            private IConfiguration _configuration;
            private readonly IConnectionMultiplexer _redis;
            private List<string> serverNames;
            private PropertyInfo[] DetailsProperties;
            private List<T> detailsList;

            public Job(IConfiguration iconfig, IConnectionMultiplexer redis)
            {
                _configuration = iconfig;
                serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
                detailsList = new List<T>();
                _redis = redis;

            }

            //static readonly ConnectionMultiplexer 
            public async Task Execute(IJobExecutionContext context)
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                string _dataName = dataMap.GetString("DataName");
                string _dataToQuery = dataMap.GetString("DataToQuery");
                string _dataModel = dataMap.GetString("DataModel");

                Type type = Type.GetType(_dataModel);    

                var db = _redis.GetDatabase();
                var res = await db.ListGetByIndexAsync(_dataName, -1);

                foreach (string servername in serverNames)
                {
                    // Set up scope for remote server
                    // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                    // Set up scope for local machine - develop
                    ManagementScope scope = new ManagementScope("root\\cimv2");

                    scope.Connect();

                    ObjectQuery query = new ObjectQuery($"SELECT * FROM {_dataToQuery}");

                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                    T details = Activator.CreateInstance<T>();

                    foreach (ManagementObject managementObject in searcher.Get())
                    {
                        DetailsProperties = Type.GetType(_dataModel).GetProperties();

                        for (int i = 0; i < DetailsProperties.Length; i++)
                        {
                            var currentProperty = DetailsProperties[i].Name.ToString();
                            var currentValue = managementObject[currentProperty] != null ? managementObject[currentProperty].ToString() : "undefined";
                            details.GetType().GetProperty(currentProperty).SetValue(details, currentValue, null);
                        }
                    }
                    detailsList.Add(details);

                }


                var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
                var obj = new RedisDataModel<T>
                {
                    TimeStamp = time,
                    KeyName = _dataName,
                    Data = detailsList
                };

                var jsonObj = JsonSerializer.Serialize(obj);

                if (!res.IsNullOrEmpty)
                {
                    var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel<T>>(res) : null;

                    var tempData = JsonSerializer.Serialize(detailsList);
                    var tempRes = JsonSerializer.Serialize(resDeserialized.Data);

                    if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                    {
                        await db.ListRightPushAsync(_dataName, jsonObj);
                    }
                }
                else
                {
                    await db.ListRightPushAsync(_dataName, jsonObj);
                }
            }
        }
    }
    
}
