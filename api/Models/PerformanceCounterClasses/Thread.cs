namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class Thread
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
        public string ContextSwitchesPersec { get; set; }
        public string ElapsedTime { get; set; }
        public string IDProcess { get; set; }
        public string IDThread { get; set; }
        public string PercentPrivilegedTime { get; set; }
        public string PercentProcessorTime { get; set; }
        public string PercentUserTime { get; set; }
        public string PriorityBase { get; set; }
        public string PriorityCurrent { get; set; }
        public string StartAddress { get; set; }
        public string ThreadState { get; set; }
        public string ThreadWaitReason { get; set; }
        public string PSComputerName { get; set; }
    }
}
