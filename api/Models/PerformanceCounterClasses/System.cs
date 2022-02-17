namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class System
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
        public string AlignmentFixupsPersec { get; set; }
        public string ContextSwitchesPersec { get; set; }
        public string ExceptionDispatchesPersec { get; set; }
        public string FileControlBytesPersec { get; set; }
        public string FileControlOperationsPersec { get; set; }
        public string FileDataOperationsPersec { get; set; }
        public string FileReadBytesPersec { get; set; }
        public string FileReadOperationsPersec { get; set; }
        public string FileWriteBytesPersec { get; set; }
        public string FileWriteOperationsPersec { get; set; }
        public string FloatingEmulationsPersec { get; set; }
        public string PercentRegistryQuotaInUse { get; set; }
        public string PercentRegistryQuotaInUse_Base { get; set; }
        public string Processes { get; set; }
        public string ProcessorQueueLength { get; set; }
        public string SystemCallsPersec { get; set; }
        public string SystemUpTime { get; set; }
        public string Threads { get; set; }
        public string PSComputerName { get; set; }
    }
}
