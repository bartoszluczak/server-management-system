﻿namespace ServerManagementSystem.Models.PerformanceCounterClasses
{
    public class TerminalService
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
        public string ActiveSessions { get; set; }
        public string InactiveSessions { get; set; }
        public string TotalSessions { get; set; }
        public string PSComputerName { get; set; }
    }
}