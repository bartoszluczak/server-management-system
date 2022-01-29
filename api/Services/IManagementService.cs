using ServerManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Services
{
    public interface IManagementService
    {
        public List<BiosDetails> FetchBiosDetails();
        public List<ProcessorDetails> FetchProcessorDetails();
        public List<StorageDetails> FetchStorageData();
        public List<MotherBoardTempsDetails> FetchMotherboardTempsData();
        public List<MemoryPerformanceDetails> FetachMemoryPerformanceDetails();
        public List<ProcessorPerformanceDetails> FetachProcessorPerformanceDetails();
        public List<SystemPerformanceDetails> FetchSystemPerformanceDetails();
        public List<NetworkPerformanceDetails> FetchNetworkPerformanceDetails();
        public List<StoragePerformanceDetails> FetchStoragePerformanceDetails();
    }
}
