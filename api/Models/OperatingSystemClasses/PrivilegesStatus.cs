namespace ServerManagementSystem.Models.OperatingSystemClasses
{
    public class PrivilegesStatus
    {
        public string Description { get; set; }
        public string Operation {get; set;}
        public string ParameterInfo {get; set;}
        public string ProviderName {get; set;}
        public string StatusCode {get; set;}
        public string PrivilegesNotHeld {get; set;}
        public string PrivilegesRequired {get; set;}
    }
}
