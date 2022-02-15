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
    public class StorageDetailsUpdate : IJob
    {
        private IConfiguration _configuration;
        private readonly IConnectionMultiplexer _redis;
        private List<string> serverNames;
        private List<StorageDetails> storageDetailsList;
        
        public StorageDetailsUpdate(IConfiguration iconfig, IConnectionMultiplexer redis)
        {
            _configuration = iconfig;
            _redis = redis;
            serverNames = _configuration.GetSection("ServerNames").Get<string[]>().ToList();
            storageDetailsList = new List<StorageDetails>();
        } 
        //static readonly ConnectionMultiplexer 
        public async Task Execute(IJobExecutionContext context)
        {
            var db = _redis.GetDatabase();
            var res = await db.ListGetByIndexAsync("storageData", -1);

            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                StorageDetails storageDetails = new StorageDetails();

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    var size = managementObject["Size"] != null ? managementObject["Size"].ToString() : "0";
                    var freeSpace = managementObject["FreeSpace"] != null ? managementObject["FreeSpace"].ToString() : "0";

                    var diskSize = Math.Round(double.Parse(size) / (1024 * 1024 * 1024), 2);
                    var diskFreespace = Math.Round(double.Parse(freeSpace) / (1024 * 1024 * 1024), 2);

                    if (diskSize > 0)
                    {
                        storageDetailsList.Add(
                        new StorageDetails()
                        {
                            ServerName = scope.Path.Server,
                            DriveName = managementObject["Name"].ToString(),
                            DriveLabel = managementObject["VolumeName"].ToString(),
                            DiskSize = diskSize,
                            DiskFreeSpace = diskFreespace,
                            DiskUsedSpace = Math.Round(diskSize - diskFreespace, 2),
                            FreeSpacePercentage = Math.Round(diskFreespace / diskSize * 100, 2)

                        });
                    }
                }

            }
                    

            var time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var obj = new RedisDataModel
            {
                TimeStamp = time,
                KeyName = "storageData",
                Data = storageDetailsList
            };

            var jsonObj = JsonSerializer.Serialize(obj);

            if (!res.IsNullOrEmpty)
            {
                var resDeserialized = (res != 0) ? JsonSerializer.Deserialize<RedisDataModel>(res) : null;

                var tempData = JsonSerializer.Serialize(storageDetailsList);
                var tempRes = resDeserialized.Data.ToString();

                if (obj.Data != null && resDeserialized.Data != null && tempData != tempRes && jsonObj != null)
                {
                   await db.ListRightPushAsync("storageData", jsonObj);
                }
            }
            else
            {
                await db.ListRightPushAsync("storageData", jsonObj);
            }
        }
    }
}
