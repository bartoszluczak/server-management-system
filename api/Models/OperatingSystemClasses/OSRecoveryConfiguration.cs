namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class OSRecoveryConfiguration
    {
        public string Caption { get; set; }
        public string Description {get; set;}
        public string SettingID {get; set;}
        public string AutoReboot {get; set;}
        public string DebugFilePath {get; set;}
        public string DebugInfoType {get; set;}
        public string ExpandedDebugFilePath {get; set;}
        public string ExpandedMiniDumpDirectory {get; set;}
        public string KernelDumpOnly {get; set;}
        public string MiniDumpDirectory {get; set;}
        public string Name {get; set;}
        public string OverwriteExistingDebugFile {get; set;}
        public string SendAdminAlert {get; set;}
        public string WriteDebugInfo {get; set;}
        public string WriteToSystemLog {get; set;}
    }
}
