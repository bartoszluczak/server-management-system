namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class EventTracing
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
        public string TotalMemoryUsageNonPagedPool { get; set; }
        public string TotalMemoryUsagePagedPool { get; set; }
        public string TotalNumberofActiveSessions { get; set; }
        public string TotalNumberofDistinctDisabledProviders { get; set; }
        public string TotalNumberofDistinctEnabledProviders { get; set; }
        public string TotalNumberofDistinctPreEnabledProviders { get; set; }
        public string PSComputerName { get; set; }
    }
}
