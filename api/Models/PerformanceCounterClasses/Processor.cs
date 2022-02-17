namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class Processor
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
        public string C1TransitionsPersec { get; set; }
        public string C2TransitionsPersec { get; set; }
        public string C3TransitionsPersec { get; set; }
        public string DPCRate { get; set; }
        public string DPCsQueuedPersec { get; set; }
        public string InterruptsPersec { get; set; }
        public string PercentC1Time { get; set; }
        public string PercentC2Time { get; set; }
        public string PercentC3Time { get; set; }
        public string PercentDPCTime { get; set; }
        public string PercentIdleTime { get; set; }
        public string PercentInterruptTime { get; set; }
        public string PercentPrivilegedTime { get; set; }
        public string PercentProcessorTime { get; set; }
        public string PercentUserTime { get; set; }
        public string PSComputerName { get; set; }
    }
}
