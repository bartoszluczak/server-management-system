namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class VolumeChangeEvent
    {
        public string SECURITY_DESCRIPTOR { get; set; }
        public string TIME_CREATED {get; set;}
        public string EventType {get; set;}
        string DriveName {get; set;}
    }
}
