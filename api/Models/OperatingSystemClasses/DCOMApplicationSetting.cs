namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class DCOMApplicationSetting
    {
        public string Caption { get; set; }
        public string Description {get; set;}
        public string SettingID {get; set;}
        public string AppID {get; set;}
        public string AuthenticationLevel {get; set;}
        public string CustomSurrogate {get; set;}
        public string EnableAtStorageActivation {get; set;}
        public string LocalService {get; set;}
        public string RemoteServerName {get; set;}
        public string RunAsUser {get; set;}
        public string ServiceParameters {get; set;}
        public string UseSurrogate {get; set;}
    }
}
