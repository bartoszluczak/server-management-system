namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class ScheduledJob
    {
        public string Caption { get; set; }
        public string Description {get; set;}
        public string InstallDate {get; set;}
        public string Name {get; set;}
        public string Status {get; set;}
        public string ElapsedTime {get; set;}
        public string Notify {get; set;}
        public string Owner {get; set;}
        public string Priority {get; set;}
        public string TimeSubmitted {get; set;}
        public string UntilTime {get; set;}
        public string Command {get; set;}
        public string DaysOfMonth {get; set;}
        public string DaysOfWeek {get; set;}
        public string InteractWithDesktop {get; set;}
        public string JobId {get; set;}
        public string JobStatus {get; set;}
        public string RunRepeatedly {get; set;}
        public string StartTime {get; set;}
    }
}
