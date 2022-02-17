namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class EventLog
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
        public string Activesubscriptions { get; set; }
        public string ELFRPCcallsPersec { get; set; }
        public string EnabledChannels { get; set; }
        public string EventfilteroperationsPersec { get; set; }
        public string EventsPersec { get; set; }
        public string WEVTRPCcallsPersec { get; set; }
        public string PSComputerName { get; set; }
    }
}
