namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class RemoteAccesPort
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
        public string AlignmentErrors { get; set; }
        public string BufferOverrunErrors { get; set; }
        public string BytesReceived { get; set; }
        public string BytesReceivedPerSec { get; set; }
        public string BytesTransmitted { get; set; }
        public string BytesTransmittedPerSec { get; set; }
        public string CRCErrors { get; set; }
        public string FramesReceived { get; set; }
        public string FramesReceivedPerSec { get; set; }
        public string FramesTransmitted { get; set; }
        public string FramesTransmittedPerSec { get; set; }
        public string PercentCompressionIn { get; set; }
        public string PercentCompressionOut { get; set; }
        public string SerialOverrunErrors { get; set; }
        public string TimeoutErrors { get; set; }
        public string TotalErrors { get; set; }
        public string TotalErrorsPerSec { get; set; }
        public string PSComputerName { get; set; }
    }
}
