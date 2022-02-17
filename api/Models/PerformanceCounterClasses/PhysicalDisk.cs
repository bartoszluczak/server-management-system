namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class PhysicalDisk
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Frequency_Object { get; set; }
        public string Frequency_PerfTime { get; set; }
        public string Frequency_Sys100NS { get; set; }
        public string Timestamp_Object { get; set; }
        public string Timestamp_PerfTime { get; set; }
        public string Timestamp_Sys100NS { get; set; }
        public string AvgDiskBytesPerRead { get; set; }
        public string AvgDiskBytesPerRead_Base { get; set; }
        public string AvgDiskBytesPerTransfer { get; set; }
        public string AvgDiskBytesPerTransfer_Base { get; set; }
        public string AvgDiskBytesPerWrite { get; set; }
        public string AvgDiskBytesPerWrite_Base { get; set; }
        public string AvgDiskQueueLength { get; set; }
        public string AvgDiskReadQueueLength { get; set; }
        public string AvgDisksecPerRead { get; set; }
        public string AvgDisksecPerRead_Base { get; set; }
        public string AvgDisksecPerTransfer { get; set; }
        public string AvgDisksecPerTransfer_Base { get; set; }
        public string AvgDisksecPerWrite { get; set; }
        public string AvgDisksecPerWrite_Base { get; set; }
        public string AvgDiskWriteQueueLength { get; set; }
        public string CurrentDiskQueueLength { get; set; }
        public string DiskBytesPersec { get; set; }
        public string DiskReadBytesPersec { get; set; }
        public string DiskReadsPersec { get; set; }
        public string DiskTransfersPersec { get; set; }
        public string DiskWriteBytesPersec { get; set; }
        public string DiskWritesPersec { get; set; }
        public string PercentDiskReadTime { get; set; }
        public string PercentDiskReadTime_Base { get; set; }
        public string PercentDiskTime { get; set; }
        public string PercentDiskTime_Base { get; set; }
        public string PercentDiskWriteTime { get; set; }
        public string PercentDiskWriteTime_Base { get; set; }
        public string PercentIdleTime { get; set; }
        public string PercentIdleTime_Base { get; set; }
        public string SplitIOPerSec { get; set; }
        public string PSComputerName { get; set; }
    }
}
