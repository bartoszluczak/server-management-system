using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagementSystem.Models
{
    public class MemoryPerformanceDetails
    {
        public string AvailableBytes { get; set; }
        public string AvailableKBytes { get; set; }
        public string AvailableMBytes { get; set; }
        public string CacheBytes { get; set; }
        public string CacheBytesPeak { get; set; }
        public string CacheFaultsPersec { get; set; }
        public string CommitLimit { get; set; }
        public string CommittedBytes { get; set; }
        public string DemandZeroFaultsPersec { get; set; }
        public string FreeAndZeroPageListBytes { get; set; }
        public string FreeSystemPageTableEntries { get; set; }
        public string LongTermAverageStandbyCacheLifetimes { get; set; }
        public string ModifiedPageListBytes { get; set; }
        public string PageFaultsPersec { get; set; }
        public string PageReadsPersec { get; set; }
        public string PagesInputPersec { get; set; }
        public string PagesOutputPersec { get; set; }
        public string PagesPersec { get; set; }
        public string PageWritesPersec { get; set; }
        public string PercentCommittedBytesInUse { get; set; }
        public string PoolNonpagedAllocs { get; set; }
        public string PoolNonpagedBytes { get; set; }
        public string PoolPagedAllocs { get; set; }
        public string PoolPagedBytes { get; set; }
        public string PoolPagedResidentBytes { get; set; }
        public string StandbyCacheCoreBytes { get; set; }
        public string StandbyCacheNormalPriorityBytes { get; set; }
        public string StandbyCacheReserveBytes { get; set; }
        public string SystemCacheResidentBytes { get; set; }
        public string SystemCodeResidentBytes { get; set; }
        public string SystemCodeTotalBytes { get; set; }
        public string SystemDriverResidentBytes { get; set; }
        public string SystemDriverTotalBytes { get; set; }
        public string TransitionFaultsPersec { get; set; }
        public string TransitionPagesRePurposedPersec { get; set; }
        public string WriteCopiesPersec { get; set; }

    }
}
