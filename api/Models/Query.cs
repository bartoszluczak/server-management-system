using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServerManagementSystem.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerManagementSystem.Models
{
    public class Query
    {
        private static IConfiguration _config;
        private readonly RedisService _redisServie;

        private readonly ManagementService _managementService;
        public Query(ManagementService managementService, IConfiguration config, RedisService redisService)
        {
            _managementService = managementService;
            _config = config;
            _redisServie = redisService;
        }

        public async Task<RedisDataModel<BiosDetails>> GetBiosDetails()
        {
            var data = await _redisServie.FetchData<RedisDataModel<BiosDetails>>("BiosDetails", -1);
            var resp = new RedisDataModel<BiosDetails> { 
                TimeStamp = data.TimeStamp,
                KeyName = data.KeyName,
                Data = data.Data
            };
            return resp;
        }
    }
}
