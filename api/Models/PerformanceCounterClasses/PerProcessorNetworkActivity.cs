namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class PerProcessorNetworkActivity
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
        public string BuildScatterGatherCyclesPersec { get; set; }
        public string InterruptCyclesPersec { get; set; }
        public string InterruptDPCCyclesPersec { get; set; }
        public string InterruptDPCLatencyCyclesPersec { get; set; }
        public string MiniportReturnPacketCyclesPersec { get; set; }
        public string MiniportRSSIndirectionTableChangeCycles { get; set; }
        public string MiniportSendCyclesPersec { get; set; }
        public string NDISReceiveIndicationCyclesPersec { get; set; }
        public string NDISReturnPacketCyclesPersec { get; set; }
        public string NDISSendCompleteCyclesPersec { get; set; }
        public string NDISSendCyclesPersec { get; set; }
        public string StackReceiveIndicationCyclesPersec { get; set; }
        public string StackSendCompleteCyclesPersec { get; set; }
        public string PSComputerName { get; set; }
    }
}
