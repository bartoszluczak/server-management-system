namespace ServerManagementSystem.Models.ComputerHardwareClasses
{
    public class SCSIControllerDevice
    {
        public string NegotiatedDataWidth { get; set; }
        public string NegotiatedSpeed {get; set;}
        public string AccessState {get; set;}
        public string NumberOfHardResets {get; set;}
        public string NumberOfSoftResets {get; set;}
    }
}
