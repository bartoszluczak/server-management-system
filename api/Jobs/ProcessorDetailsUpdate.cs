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
    public class ProcessorDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private readonly RedisService _redisServie;
        private List<string> serverNames;
        private PropertyInfo[] ProcessorDetailsProperties;
        private List<ProcessorDetails> processorDetailsList;

        private readonly ManagementService _managementService;

        public ProcessorDetailsUpdate(IConfiguration iconfig, RedisService redisService, ManagementService managementService)
        {
            _configuration = iconfig;
            _redisServie = redisService;
            serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
            processorDetailsList = new List<ProcessorDetails>();
            _managementService = managementService;
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {
            var db = _redisServie.Connect().GetDatabase();
            var res = db.ListGetByIndex("processorData", -1);

            processorDetailsList = _managementService.FetchProcessorDetails();

            //foreach (string servername in serverNames)
            //{
            //    // Set up scope for remote server
            //    // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

            //    // Set up scope for local machine - develop
            //    ManagementScope scope = new ManagementScope("root\\cimv2");

            //    scope.Connect();

            //    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");

            //    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            //    ProcessorDetails processorDetails = new ProcessorDetails();

            //    foreach (ManagementObject managementObject in searcher.Get())
            //    {
            //        ProcessorDetailsProperties = Type.GetType("ServerManagementSystem.Models.ProcessorDetails").GetProperties();

            //        for (int i = 0; i < ProcessorDetailsProperties.Length; i++)
            //        {
            //            var currentProperty = ProcessorDetailsProperties[i].Name.ToString();
            //            var currentValue = managementObject[currentProperty] != null ? managementObject[currentProperty].ToString() : "undefined";
            //            processorDetails.GetType().GetProperty(currentProperty).SetValue(processorDetails, currentValue, null);
            //        }
            //    }
            //    processorDetailsList.Add(processorDetails);

            //}


            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel
            {
                TimeStamp = time,
                KeyName = "processorData",
                Data = processorDetailsList
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            if (!res.IsNullOrEmpty)
            {
                var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel>(res) : null;

                var tempData = JsonSerializer.Serialize(processorDetailsList);
                var tempRes = resDeserialized.Data.ToString();

                if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                {
                    db.ListRightPush("processorData", jsonObj);
                }
            }
            else
            {
                db.ListRightPush("processorData", jsonObj);
            }
        
            _redisServie.Disconnect();
        }
    }
}
