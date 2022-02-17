namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class EventTracingSession
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
        public string BufferMemoryUsageNonPagedPool { get; set; }
        public string BufferMemoryUsagePagedPool { get; set; }
        public string EventsLoggedpersec { get; set; }
        public string EventsLost { get; set; }
        public string NumberofRealTimeConsumers { get; set; }
        public string PSComputerName { get; set; }
    }
}
