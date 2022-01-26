using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Models
{
    public class NetworkPerformanceDetails
    {
        public string Name { get; set; }
        public string BytesReceivedPersec { get; set; }
        public string BytesSentPersec { get; set; }
        public string BytesTotalPersec { get; set; }
        public string CurrentBandwidth { get; set; }
        public string OffloadedConnections { get; set; }
        public string OutputQueueLength { get; set; }
        public string PacketsOutboundDiscarded { get; set; }
        public string PacketsOutboundErrors { get; set; }
        public string PacketsPersec { get; set; }
        public string PacketsReceivedDiscarded { get; set; }
        public string PacketsReceivedErrors { get; set; }
        public string PacketsReceivedNonUnicastPersec { get; set; }
        public string PacketsReceivedPersec { get; set; }
        public string PacketsReceivedUnicastPersec { get; set; }
        public string PacketsReceivedUnknown { get; set; }
        public string PacketsSentNonUnicastPersec { get; set; }
        public string PacketsSentPersec { get; set; }
        public string PacketsSentUnicastPersec { get; set; }
        public string TCPActiveRSCConnections { get; set; }
        public string TCPRSCAveragePacketSize { get; set; }
        public string TCPRSCCoalescedPacketsPersec { get; set; }
        public string TCPRSCExceptionsPersec { get; set; }

    }
}
