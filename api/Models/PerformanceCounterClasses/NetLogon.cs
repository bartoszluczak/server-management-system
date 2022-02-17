namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class NetLogon
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
        public string AverageSemaphoreHoldTime { get; set; }
        public string AverageSemaphoreHoldTime_Base { get; set; }
        public string LastAuthenticationTime { get; set; }
        public string LastAuthenticationTime_Base { get; set; }
        public string SemaphoreAcquires { get; set; }
        public string SemaphoreHolders { get; set; }
        public string SemaphoreTimeouts { get; set; }
        public string SemaphoreWaiters { get; set; }
        public string PSComputerName { get; set; }
    }
}
