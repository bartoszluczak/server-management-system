namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class IPsecDrivers
    {
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Frequency_Object { get; set; }
        public string Frequency_PerfTime { get; set; }
        public string Frequency_SysNS { get; set; }
        public string Timestamp_Object { get; set; }
        public string Timestamp_PerfTime { get; set; }
        public string Timestamp_Sys1NS { get; set; }
        public string ActiveSecurityAssociations { get; set; }
        public string BytesReceivedinTransportModePersec { get; set; }
        public string BytesReceivedinTunnelModePersec { get; set; }
        public string BytesSentinTransportModePersec { get; set; }
        public string BytesSentinTunnelModePersec { get; set; }
        public string InboundPacketsDroppedPersec { get; set; }
        public string InboundPacketsReceivedPersec { get; set; }
        public string IncorrectSPIPackets { get; set; }
        public string IncorrectSPIPacketsPersec { get; set; }
        public string OffloadedBytesReceivedPersec { get; set; }
        public string OffloadedBytesSentPersec { get; set; }
        public string OffloadedSecurityAssociations { get; set; }
        public string PacketsNotAuthenticated { get; set; }
        public string PacketsNotAuthenticatedPersec { get; set; }
        public string PacketsNotDecrypted { get; set; }
        public string PacketsNotDecryptedPersec { get; set; }
        public string PacketsReceivedOverWrongSA { get; set; }
        public string PacketsReceivedOverWrongSAPersec { get; set; }
        public string PacketsThatFailedESPValidation { get; set; }
        public string PacketsThatFailedESPValidationPersec { get; set; }
        public string PacketsThatFailedReplayDetection { get; set; }
        public string PacketsThatFailedReplayDetectionPersec { get; set; }
        public string PacketsThatFailedUDPESPValidation { get; set; }
        public string PacketsThatFailedUDPESPValidationPersec { get; set; }
        public string PendingSecurityAssociations { get; set; }
        public string PlaintextPacketsReceived { get; set; }
        public string PlaintextPacketsReceivedPersec { get; set; }
        public string SARekeys { get; set; }
        public string SecurityAssociationsAdded { get; set; }
        public string TotalInboundPacketsDropped { get; set; }
        public string TotalInboundPacketsReceived { get; set; }
        public string PSComputerName { get; set; }

    }
}
