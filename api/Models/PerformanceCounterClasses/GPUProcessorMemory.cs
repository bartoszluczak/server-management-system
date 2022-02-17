namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class GPUProcessorMemory
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
        public string DedicatedUsage { get; set; }
        public string LocalUsage { get; set; }
        public string NonLocalUsage { get; set; }
        public string SharedUsage { get; set; }
        public string TotalCommitted { get; set; }
        public string PSComputerName { get; set; }
    }
}
