using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Models
{
    public class SystemPerformanceDetails
    {
        public string AlignmentFixupsPersec { get; set; }
        public string ContextSwitchesPersec { get; set; }
        public string ExceptionDispatchesPersec { get; set; }
        public string FileControlBytesPersec { get; set; }
        public string FileControlOperationsPersec { get; set; }
        public string FileDataOperationsPersec { get; set; }
        public string FileReadBytesPersec { get; set; }
        public string FileReadOperationsPersec { get; set; }
        public string FileWriteBytesPersec { get; set; }
        public string FileWriteOperationsPersec { get; set; }
        public string FloatingEmulationsPersec { get; set; }
        public string PercentRegistryQuotaInUse { get; set; }
        public string Processes { get; set; }
        public string ProcessorQueueLength { get; set; }
        public string SystemCallsPersec { get; set; }
        public string SystemUpTime { get; set; }
        public string Threads { get; set; }
    }
}
