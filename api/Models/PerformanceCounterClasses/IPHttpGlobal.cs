namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class IPHttpGlobal
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
        public string DropsNeighborresolutiontimeouts { get; set; }
        public string ErrorsAuthenticationErrors { get; set; }
        public string ErrorsReceiveerrorsontheserver { get; set; }
        public string ErrorsTransmiterrorsontheserver { get; set; }
        public string InTotalbytesreceived { get; set; }
        public string InTotalpacketsreceived { get; set; }
        public string OutTotalbytesforwarded { get; set; }
        public string OutTotalbytessent { get; set; }
        public string OutTotalpacketssent { get; set; }
        public string SessionsTotalsessions { get; set; }
        public string PSComputerName { get; set; }
    }
}
