namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class ProcessorInfo
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
        public string AverageIdleTime { get; set; }
        public string AverageIdleTime_Base { get; set; }
        public string C1TransitionsPersec { get; set; }
        public string C2TransitionsPersec { get; set; }
        public string C3TransitionsPersec { get; set; }
        public string ClockInterruptsPersec { get; set; }
        public string DPCRate { get; set; }
        public string DPCsQueuedPersec { get; set; }
        public string IdleBreakEventsPersec { get; set; }
        public string InterruptsPersec { get; set; }
        public string ParkingStatus { get; set; }
        public string PercentC1Time { get; set; }
        public string PercentC2Time { get; set; }
        public string PercentC3Time { get; set; }
        public string PercentDPCTime { get; set; }
        public string PercentIdleTime { get; set; }
        public string PercentInterruptTime { get; set; }
        public string PercentofMaximumFrequency { get; set; }
        public string PercentPerformanceLimit { get; set; }
        public string PercentPriorityTime { get; set; }
        public string PercentPrivilegedTime { get; set; }
        public string PercentPrivilegedUtility { get; set; }
        public string PercentPrivilegedUtility_Base { get; set; }
        public string PercentProcessorPerformance { get; set; }
        public string PercentProcessorPerformance_Base { get; set; }
        public string PercentProcessorTime { get; set; }
        public string PercentProcessorUtility { get; set; }
        public string PercentProcessorUtility_Base { get; set; }
        public string PercentUserTime { get; set; }
        public string PerformanceLimitFlags { get; set; }
        public string ProcessorFrequency { get; set; }
        public string ProcessorStateFlags { get; set; }
        public string PSComputerName { get; set; }
    }
}
