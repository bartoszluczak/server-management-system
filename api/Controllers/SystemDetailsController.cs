using Microsoft.AspNetCore.Mvc;
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

        private readonly ManagementService _managementService;
        public SystemDetailsController(ManagementService managementService, IConfiguration config)
        {
            _managementService = managementService;
            _config = config;
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
        public List<MemoryDetals> GetMemoryDetails()
        {
            List<MemoryDetals> data = _managementService.FetchMemoryDetails();
            return data;
        }

        [HttpGet("bios-redis")]
        public string  GetBiosRedis()
        {
            string data = _managementService.FetchBiosDetailsRedis();
            //var jsonObj = JsonSerializer.Deserialize(data);
            Console.WriteLine(data);
            return data;
        }
    }
}
