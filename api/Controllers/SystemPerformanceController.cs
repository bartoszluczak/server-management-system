using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServerManagementSystem.Models;
using ServerManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemPerformanceController : ControllerBase
    {
        private static IConfiguration _config;

        private readonly ManagementService _managementService;
        public SystemPerformanceController(ManagementService managementService, IConfiguration config)
        {
            _managementService = managementService;
            _config = config;
        }

        [HttpGet("memory")]
        public List<MemoryPerformanceDetails> GetMemoryDetails()
        {
            List<MemoryPerformanceDetails> data = _managementService.FetachMemoryPerformanceDetails();
            return data;
        }

        [HttpGet("processor")]
        public List<ProcessorPerformanceDetails> GetProcessorDetails()
        {
            List<ProcessorPerformanceDetails> data = _managementService.FetachProcessorPerformanceDetails();
            return data;
        }

        [HttpGet("system")]
        public List<SystemPerformanceDetails> GetSystemDetails()
        {
            List<SystemPerformanceDetails> data = _managementService.FetchSystemPerformanceDetails();
            return data;
        }

        [HttpGet("network")]
        public List<NetworkPerformanceDetails> GetNetworkDetails()
        {
            List<NetworkPerformanceDetails> data = _managementService.FetchNetworkPerformanceDetails();
            return data;
        }
        [HttpGet("storage")]
        public List<StoragePerformanceDetails> GetStorageDetails()
        {
            List<StoragePerformanceDetails> data = _managementService.FetchStoragePerformanceDetails();
            return data;
        }
    }
}
