namespace ServerManagementSystem.Models
{
    public class StoragePerformanceDetails
    {
        public string Name { get; set; }
        public string AvgDiskBytesPerRead { get; set; }
        public string AvgDiskBytesPerTransfer { get; set; }
        public string AvgDiskBytesPerWrite { get; set; }
        public string AvgDiskQueueLength { get; set; }
        public string AvgDiskReadQueueLength { get; set; }
        public string AvgDisksecPerRead { get; set; }
        public string AvgDisksecPerTransfer { get; set; }
        public string AvgDisksecPerWrite { get; set; }
        public string AvgDiskWriteQueueLength { get; set; }
        public string CurrentDiskQueueLength { get; set; }
        public string DiskBytesPersec { get; set; }
        public string DiskReadBytesPersec { get; set; }
        public string DiskReadsPersec { get; set; }
        public string DiskTransfersPersec { get; set; }
        public string DiskWriteBytesPersec { get; set; }
        public string DiskWritesPersec { get; set; }
        public string FreeMegabytes { get; set; }
        public string PercentDiskReadTime { get; set; }
        public string PercentDiskTime { get; set; }
        public string PercentDiskWriteTime { get; set; }
        public string PercentFreeSpace { get; set; }
        public string PercentIdleTime { get; set; }
        public string SplitIOPerSec { get; set; }

    }
}
