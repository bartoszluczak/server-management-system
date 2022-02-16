namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class LogonSession
    {
        public string Caption { get; set; }
        public string Description {get; set;}
        public string InstallDate {get; set;}
        public string Name {get; set;}
        public string Status {get; set;}
        public string StartTime {get; set;}
        public string AuthenticationPackage {get; set;}
        public string LogonId {get; set;}
        public string LogonType {get; set;}
    }
}
