using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Models
{
    public class StorageDetails
    {
        public string ServerName { get; set; }
        public string DriveName { get; set; }
        public string DriveLabel { get; set; }
        public double DiskSize { get; set; }
        public double DiskUsedSpace { get; set; }
        public double DiskFreeSpace { get; set; }
        public double FreeSpacePercentage { get; set; }
    }
}
