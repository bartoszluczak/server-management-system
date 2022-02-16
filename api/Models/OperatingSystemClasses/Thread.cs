namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class Thread
    {
        public string Caption { get; set; }
        public string CreationClassName {get; set;}
        public string CSCreationClassName {get; set;}
        public string CSName {get; set;}
        public string Description {get; set;}
        public string ElapsedTime {get; set;}
        public string ExecutionState {get; set;}
        public string Handle {get; set;}
        public string InstallDate {get; set;}
        public string KernelModeTime {get; set;}
        public string Name {get; set;}
        public string OSCreationClassName {get; set;}
        public string OSName {get; set;}
        public string Priority {get; set;}
        public string PriorityBase {get; set;}
        public string ProcessCreationClassName {get; set;}
        public string ProcessHandle {get; set;}
        public string StartAddress {get; set;}
        public string Status {get; set;}
        public string ThreadState {get; set;}
        public string ThreadWaitReason {get; set;}
        public string UserModeTime {get; set;}
    }
}
