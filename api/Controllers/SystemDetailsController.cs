﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServerManagementSystem.Models;
using ServerManagementSystem.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace ServerManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemDetailsController : ControllerBase
    {
        private static IConfiguration _config;
        private readonly RedisService _redisServie;

        private readonly ManagementService _managementService;
        public SystemDetailsController(ManagementService managementService, IConfiguration config, RedisService redisService)
        {
            _managementService = managementService;
            _config = config;
            _redisServie = redisService;
        }

        [HttpGet("isactive")]
        public IActionResult GetIsActive()
        {
            string data = _managementService.IsActive();

            if (data == null | data == "Server is inactive")
            {
                return BadRequest("Server is not runnig!");
            }

            return Ok("Server is active!");
        }

        [HttpGet("bios")]
        public List<BiosDetails> GetBiosDetails()
        {
            List<BiosDetails> data = _managementService.FetchBiosDetails();
            return data;
        }

        [HttpGet("processor")]
        public List<ProcessorDetails> GetProcessorDetails()
        {
            List<ProcessorDetails> data = _managementService.FetchProcessorDetails();
            return data;
        }

        [HttpGet("computersystem")]
        public List<ComputerSystemDetails> GetComputerSystemDetails()
        {
            List<ComputerSystemDetails> data = _managementService.FetchComputerSystemDetails();
            return data;
        }

        [HttpGet("updates")]
        public List<UpdatesDetails> GetUpdatesDetails()
        {
            List<UpdatesDetails> data = _managementService.FetchUpdatesDetails();
            return data;
        }

        [HttpGet("storage")]
        public List<StorageDetails> GetStorageDetails()
        {
            List<StorageDetails> data = _managementService.FetchStorageData();
            return data;
        }


        [HttpGet("motherboardtemps")]
        public List<MotherBoardTempsDetails> GetTemperaturesDetails()
        {
            List<MotherBoardTempsDetails> data = _managementService.FetchMotherboardTempsData();
            return data;
        }

        [HttpGet("casefans")]
        public List<FansDetails> GetFansDetails()
        {
            List<FansDetails> data = _managementService.FetchFansDetails();
            return data;
        }

        [HttpGet("memory")]
        public List<MemoryDetails> GetMemoryDetails()
        {
            List<MemoryDetails> data = _managementService.FetchMemoryDetails();
            return data;
        }

        /// Redis return methods

        [HttpGet("redis/bios")]
        public IActionResult  GetBiosRedis()
        {
            var data = _redisServie.FetchData("biosData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/memory")]
        public IActionResult  GetMemoryRedis()
        {
            var data = _redisServie.FetchData("memoryData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/processor")]
        public IActionResult GetProcessorRedis()
        {
            var data = _redisServie.FetchData("processorData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/computersystem")]
        public IActionResult GetComputerSystemRedis()
        {
            var data = _redisServie.FetchData("computerSystemData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/updates")]
        public IActionResult GetUpdatesRedis()
        {
            var data = _redisServie.FetchData("updatesData", -1);
            //var data = _redisServie.FetchList("updatesData", 0, -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/storage")]
        public IActionResult GetStorageRedis()
        {
            var data = _redisServie.FetchData("storageData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/motherboardtemps")]
        public IActionResult GetMotherboardTempsRedis()
        {
            var data = _redisServie.FetchData("motherboardtempsData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
        
        [HttpGet("redis/casefans")]
        public IActionResult GetCaseFansRedis()
        {
            var data = _redisServie.FetchData("casefansData", -1);
            return Ok(new RedisDataModel { TimeStamp = data.TimeStamp, KeyName = data.KeyName, Data = data.Data });
        }
    }
}
