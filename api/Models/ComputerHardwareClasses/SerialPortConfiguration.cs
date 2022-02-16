namespace ServerManagementSystem.Models.ComputerHardwareClasses
{
    public class SerialPortConfiguration
    {
        public string Caption { get; set; }
        public string Description {get; set;}
        public string SettingID {get; set;}
        public string AbortReadWriteOnError {get; set;}
        public string BaudRate {get; set;}
        public string BinaryModeEnabled {get; set;}
        public string BitsPerByte {get; set;}
        public string ContinueXMitOnXOff {get; set;}
        public string CTSOutflowControl {get; set;}
        public string DiscardNULLBytes {get; set;}
        public string DSROutflowControl {get; set;}
        public string DSRSensitivity {get; set;}
        public string DTRFlowControlType {get; set;}
        public string EOFCharacter {get; set;}
        public string ErrorReplaceCharacter {get; set;}
        public string ErrorReplacementEnabled {get; set;}
        public string EventCharacter {get; set;}
        public string IsBusy {get; set;}
        public string Name {get; set;}
        public string Parity {get; set;}
        public string ParityCheckEnabled {get; set;}
        public string RTSFlowControlType {get; set;}
        public string StopBits {get; set;}
        public string XOffCharacter {get; set;}
        public string XOffXMitThreshold {get; set;}
        public string XOnCharacter {get; set;}
        public string XOnXMitThreshold {get; set;}
        public string XOnXOffInFlowControl {get; set;}
        public string XOnXOffOutFlowControl {get; set;}
    }
}
