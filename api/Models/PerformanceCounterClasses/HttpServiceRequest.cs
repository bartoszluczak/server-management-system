namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class HttpServiceRequest
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
        public string ArrivalRate { get; set; }
        public string CacheHitRate { get; set; }
        public string CurrentQueueSize { get; set; }
        public string MaxQueueItemAge { get; set; }
        public string RejectedRequests { get; set; }
        public string RejectionRate { get; set; }
        public string PSComputerName { get; set; }
    }
}
