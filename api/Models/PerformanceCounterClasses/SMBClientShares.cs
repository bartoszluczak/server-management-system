namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class SMBClientShares
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
        public string AvgBytesPerRead { get; set; }
        public string AvgBytesPerRead_Base { get; set; }
        public string AvgBytesPerWrite { get; set; }
        public string AvgBytesPerWrite_Base { get; set; }
        public string AvgDataBytesPerRequest { get; set; }
        public string AvgDataBytesPerRequest_Base { get; set; }
        public string AvgDataQueueLength { get; set; }
        public string AvgReadQueueLength { get; set; }
        public string AvgsecPerDataRequest { get; set; }
        public string AvgsecPerDataRequest_Base { get; set; }
        public string AvgsecPerRead { get; set; }
        public string AvgsecPerRead_Base { get; set; }
        public string AvgsecPerWrite { get; set; }
        public string AvgsecPerWrite_Base { get; set; }
        public string AvgWriteQueueLength { get; set; }
        public string CompressedBytesSentPersec { get; set; }
        public string CompressedRequestsPersec { get; set; }
        public string CompressedResponsesPersec { get; set; }
        public string CreditStallsPersec { get; set; }
        public string CurrentDataQueueLength { get; set; }
        public string DataBytesPersec { get; set; }
        public string DataRequestsPersec { get; set; }
        public string MetadataRequestsPersec { get; set; }
        public string ReadBytesPersec { get; set; }
        public string ReadBytestransmittedviaSMBDirectPersec { get; set; }
        public string ReadRequestsPersec { get; set; }
        public string ReadRequeststransmittedviaSMBDirectPersec { get; set; }
        public string TurboIOReadsPersec { get; set; }
        public string TurboIOWritesPersec { get; set; }
        public string WriteBytesPersec { get; set; }
        public string WriteBytestransmittedviaSMBDirectPersec { get; set; }
        public string WriteRequestsPersec { get; set; }
        public string WriteRequeststransmittedviaSMBDirectPersec { get; set; }
        public string PSComputerName { get; set; }
    }
}
