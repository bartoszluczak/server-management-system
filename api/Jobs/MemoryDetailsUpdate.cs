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
    public class MemoryDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private readonly IConnectionMultiplexer _redis;
        private List<string> serverNames;
        private PropertyInfo[] MemoryDetailsProperties;
        private List<MemoryDetails> memoryDetailsList;
        
        public MemoryDetailsUpdate(IConfiguration iconfig, IConnectionMultiplexer redis)
        {
            _configuration = iconfig;
            _redis = redis;
            serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
            memoryDetailsList = new List<MemoryDetails>();
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {
            var db = _redis.GetDatabase();
            var res = await db.ListGetByIndexAsync("memoryData", -1);

            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                MemoryDetails memoryDetails = new MemoryDetails();

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    MemoryDetailsProperties = Type.GetType("ServerManagementSystem.Models.MemoryDetails").GetProperties();

                    for (int i = 0; i < MemoryDetailsProperties.Length; i++)
                    {
                        var currentProperty = MemoryDetailsProperties[i].Name.ToString();
                        var currentValue = managementObject[currentProperty] != null ? managementObject[currentProperty].ToString() : "undefined";
                        memoryDetails.GetType().GetProperty(currentProperty).SetValue(memoryDetails, currentValue, null);
                    }
                }
                memoryDetailsList.Add(memoryDetails);

            }
                    

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel<MemoryDetails>
            {
                TimeStamp = time,
                KeyName = "memoryData",
                Data = memoryDetailsList
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            if (!res.IsNullOrEmpty)
            {
                var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel<MemoryDetails>>(res) : null;

                var tempData = JsonSerializer.Serialize(memoryDetailsList);
                var tempRes = resDeserialized.Data.ToString();

                if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                {
                   await db.ListRightPushAsync("memoryData", jsonObj);
                }
            }
            else
            {
               await db.ListRightPushAsync("memoryData", jsonObj);
            }
        }
    }
}
