namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class SMBServer
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
        public string ReadBytesPersec { get; set; }
        public string ReadRequestsPersec { get; set; }
        public string ReceiveBytesPersec { get; set; }
        public string SendBytesPersec { get; set; }
        public string WriteBytesPersec { get; set; }
        public string WriteRequestsPersec { get; set; }
        public string PSComputerName { get; set; }
    }
}
