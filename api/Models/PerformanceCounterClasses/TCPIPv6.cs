namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class TCPIPv6
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
        public string DatagramsForwardedPersec { get; set; }
        public string DatagramsOutboundDiscarded { get; set; }
        public string DatagramsOutboundNoRoute { get; set; }
        public string DatagramsPersec { get; set; }
        public string DatagramsReceivedAddressErrors { get; set; }
        public string DatagramsReceivedDeliveredPersec { get; set; }
        public string DatagramsReceivedDiscarded { get; set; }
        public string DatagramsReceivedHeaderErrors { get; set; }
        public string DatagramsReceivedPersec { get; set; }
        public string DatagramsReceivedUnknownProtocol { get; set; }
        public string DatagramsSentPersec { get; set; }
        public string FragmentationFailures { get; set; }
        public string FragmentedDatagramsPersec { get; set; }
        public string FragmentReassemblyFailures { get; set; }
        public string FragmentsCreatedPersec { get; set; }
        public string FragmentsReassembledPersec { get; set; }
        public string FragmentsReceivedPersec { get; set; }
        public string PSComputerName { get; set; }
    }
}
