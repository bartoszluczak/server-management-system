namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class Process
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Frequency_Object { get; set; }
        public string Frequency_PerfTime { get; set; }
        public string Frequency_Sys1NS { get; set; }
        public string Timestamp_Object { get; set; }
        public string Timestamp_PerfTime { get; set; }
        public string Timestamp_Sys100NS { get; set; }
        public string CreatingProcessID { get; set; }
        public string ElapsedTime { get; set; }
        public string HandleCount { get; set; }
        public string IDProcess { get; set; }
        public string IODataBytesPersec { get; set; }
        public string IODataOperationsPersec { get; set; }
        public string IOOtherBytesPersec { get; set; }
        public string IOOtherOperationsPersec { get; set; }
        public string IOReadBytesPersec { get; set; }
        public string IOReadOperationsPersec { get; set; }
        public string IOWriteBytesPersec { get; set; }
        public string IOWriteOperationsPersec { get; set; }
        public string PageFaultsPersec { get; set; }
        public string PageFileBytes { get; set; }
        public string PageFileBytesPeak { get; set; }
        public string PercentPrivilegedTime { get; set; }
        public string PercentProcessorTime { get; set; }
        public string PercentUserTime { get; set; }
        public string PoolNonpagedBytes { get; set; }
        public string PoolPagedBytes { get; set; }
        public string PriorityBase { get; set; }
        public string PrivateBytes { get; set; }
        public string ThreadCount { get; set; }
        public string VirtualBytes { get; set; }
        public string VirtualBytesPeak { get; set; }
        public string WorkingSet { get; set; }
        public string WorkingSetPeak { get; set; }
        public string WorkingSetPrivate { get; set; }
        public string PSComputerName { get; set; }
    }
}
