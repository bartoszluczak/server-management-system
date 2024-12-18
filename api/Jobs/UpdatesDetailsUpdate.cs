﻿using Microsoft.Extensions.Configuration;
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
    public class UpdatesDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private readonly IConnectionMultiplexer _redis;
        private List<string> serverNames;
        private PropertyInfo[] UpdatesDetailsProperties;
        private List<UpdatesDetails> updatesDetailsList;
        
        public UpdatesDetailsUpdate(IConfiguration iconfig, IConnectionMultiplexer redis)
        {
            _configuration = iconfig;
            _redis = redis;
            serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
            updatesDetailsList = new List<UpdatesDetails>();
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {
            var db = _redis.GetDatabase();
            var res = await db.ListGetByIndexAsync("updatesData", -1);

            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_QuickFixEngineering");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                UpdatesDetails updatesDetails = new UpdatesDetails();

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    UpdatesDetailsProperties = Type.GetType("ServerManagementSystem.Models.UpdatesDetails").GetProperties();

                    for (int i = 0; i < UpdatesDetailsProperties.Length; i++)
                    {
                        var currentProperty = UpdatesDetailsProperties[i].Name.ToString();
                        var currentValue = managementObject[currentProperty] != null ? managementObject[currentProperty].ToString() : "undefined";
                        updatesDetails.GetType().GetProperty(currentProperty).SetValue(updatesDetails, currentValue, null);
                    }

                    updatesDetailsList.Add(updatesDetails);
                }
                

            }
                    

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel<UpdatesDetails>
            {
                TimeStamp = time,
                KeyName = "updatesData",
                Data = updatesDetailsList
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            if (!res.IsNullOrEmpty)
            {
                var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel<UpdatesDetails>>(res) : null;

                var tempData = JsonSerializer.Serialize(updatesDetailsList);
                var tempRes = resDeserialized.Data.ToString();

                if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                {
                   await db.ListRightPushAsync("updatesData", jsonObj);
                }
            }
            else
            {
                await db.ListRightPushAsync("updatesData", jsonObj);
            }
        }
    }
}
