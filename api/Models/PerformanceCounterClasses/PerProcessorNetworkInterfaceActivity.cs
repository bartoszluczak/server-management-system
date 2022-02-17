namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class PerProcessorNetworkInterfaceActivity
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
        public string BuildScatterGatherListCallsPersec { get; set; }
        public string DPCsDeferredPersec { get; set; }
        public string DPCsQueuedonOtherCPUsPersec { get; set; }
        public string DPCsQueuedPersec { get; set; }
        public string InterruptsPersec { get; set; }
        public string LowResourceReceivedPacketsPersec { get; set; }
        public string LowResourceReceiveIndicationsPersec { get; set; }
        public string PacketsCoalescedPersec { get; set; }
        public string ReceivedPacketsPersec { get; set; }
        public string ReceiveIndicationsPersec { get; set; }
        public string ReturnedPacketsPersec { get; set; }
        public string ReturnPacketCallsPersec { get; set; }
        public string RSSIndirectionTableChangeCallsPersec { get; set; }
        public string SendCompleteCallsPersec { get; set; }
        public string SendRequestCallsPersec { get; set; }
        public string SentCompletePacketsPersec { get; set; }
        public string SentPacketsPersec { get; set; }
        public string TcpOffloadReceivebytesPersec { get; set; }
        public string TcpOffloadReceiveIndicationsPersec { get; set; }
        public string TcpOffloadSendbytesPersec { get; set; }
        public string TcpOffloadSendRequestCallsPersec { get; set; }
        public string PSComputerName { get; set; }
    }
}
