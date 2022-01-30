using ServerManagementSystem.Models;
using System.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ServerManagementSystem.Services
{
    public class ManagementService : IManagementService
    {
        private IConfiguration _config;
        private List<string> serverNames;
        private List<StorageDetails> storageDetailsList;
        private List<BiosDetails> biosDetailsList;
        private List<ProcessorDetails> processorDetails;
        private List<ComputerSystemDetails> computerSystemDetails;
        private List<UpdatesDetails> updatesDetails;
        private List<MotherBoardTempsDetails> motherboardTempsDetails;
        private List<FansDetails> fansDetails;
        private List<MemoryDetals> memoryDetals;
        private List<MemoryPerformanceDetails> memoryPerformanceDetails;
        private List<ProcessorPerformanceDetails> processorPerformanceDetails;
        private List<SystemPerformanceDetails> systemPerformanceDetails;
        private List<NetworkPerformanceDetails> networkPerformanceDetails;
        private List<StoragePerformanceDetails> storagePerformanceDetails;
        

        public ManagementService(IConfiguration config)
        {
            _config = config;
            serverNames = _config.GetSection("ServerNames").Get<string[]>().ToList();
            storageDetailsList = new List<StorageDetails>();
            biosDetailsList = new List<BiosDetails>();
            processorDetails = new List<ProcessorDetails>();
            computerSystemDetails = new List<ComputerSystemDetails>();
            updatesDetails = new List<UpdatesDetails>();
            motherboardTempsDetails = new List<MotherBoardTempsDetails>();
            fansDetails = new List<FansDetails>();
            memoryDetals = new List<MemoryDetals>();
            memoryPerformanceDetails = new List<MemoryPerformanceDetails>();
            processorPerformanceDetails = new List<ProcessorPerformanceDetails>();
            systemPerformanceDetails = new List<SystemPerformanceDetails>();
            networkPerformanceDetails = new List<NetworkPerformanceDetails>();
            storagePerformanceDetails = new List<StoragePerformanceDetails>();
        }

        public List<BiosDetails> FetchBiosDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_BIOS");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    biosDetailsList.Add(new BiosDetails()
                    {
                        BiosCharacteristics = managementObject["BiosCharacteristics"] != null ? managementObject["BiosCharacteristics"].ToString() : "undefined",
                        BIOSVersion = managementObject["BIOSVersion"] != null ? managementObject["BIOSVersion"].ToString() : "undefined",
                        BuildNumber = managementObject["BuildNumber"] != null ? managementObject["BuildNumber"].ToString() : "undefined",
                        Caption = managementObject["Caption"] != null ? managementObject["Caption"].ToString() : "undefined",
                        CodeSet = managementObject["CodeSet"] != null ? managementObject["CodeSet"].ToString() : "undefined",
                        CurrentLanguage = managementObject["CurrentLanguage"] != null ? managementObject["CurrentLanguage"].ToString() : "undefined",
                        Description = managementObject["Description"] != null ? managementObject["Description"].ToString() : "undefined",
                        EmbeddedControllerMajorVersion = managementObject["EmbeddedControllerMajorVersion"] != null ? managementObject["EmbeddedControllerMajorVersion"].ToString() : "undefined",
                        EmbeddedControllerMinorVersion = managementObject["EmbeddedControllerMinorVersion"] != null ? managementObject["EmbeddedControllerMinorVersion"].ToString() : "undefined",
                        IdentificationCode = managementObject["IdentificationCode"] != null ? managementObject["IdentificationCode"].ToString() : "undefined",
                        InstallableLanguages = managementObject["InstallableLanguages"] != null ? managementObject["InstallableLanguages"].ToString() : "undefined",
                        InstallDate = managementObject["InstallDate"] != null ? managementObject["InstallDate"].ToString() : "undefined",
                        LanguageEdition = managementObject["LanguageEdition"] != null ? managementObject["LanguageEdition"].ToString() : "undefined",
                        ListOfLanguages = managementObject["ListOfLanguages"] != null ? managementObject["ListOfLanguages"].ToString() : "undefined",
                        Manufacturer = managementObject["Manufacturer"] != null ? managementObject["Manufacturer"].ToString() : "undefined",
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        OtherTargetOS = managementObject["OtherTargetOS"] != null ? managementObject["OtherTargetOS"].ToString() : "undefined",
                        PrimaryBIOS = managementObject["PrimaryBIOS"] != null ? managementObject["PrimaryBIOS"].ToString() : "undefined",
                        ReleaseDate = managementObject["ReleaseDate"] != null ? managementObject["ReleaseDate"].ToString() : "undefined",
                        SerialNumber = managementObject["SerialNumber"] != null ? managementObject["SerialNumber"].ToString() : "undefined",
                        SMBIOSBIOSVersion = managementObject["SMBIOSBIOSVersion"] != null ? managementObject["SMBIOSBIOSVersion"].ToString() : "undefined",
                        SMBIOSMajorVersion = managementObject["SMBIOSMajorVersion"] != null ? managementObject["SMBIOSMajorVersion"].ToString() : "undefined",
                        SMBIOSMinorVersion = managementObject["SMBIOSMinorVersion"] != null ? managementObject["SMBIOSMinorVersion"].ToString() : "undefined",
                        SMBIOSPresent = managementObject["SMBIOSPresent"] != null ? managementObject["SMBIOSPresent"].ToString() : "undefined",
                        SoftwareElementID = managementObject["SoftwareElementID"] != null ? managementObject["SoftwareElementID"].ToString() : "undefined",
                        SoftwareElementState = managementObject["SoftwareElementState"] != null ? managementObject["SoftwareElementState"].ToString() : "undefined",
                        Status = managementObject["Status"] != null ? managementObject["Status"].ToString() : "undefined",
                        SystemBiosMajorVersion = managementObject["SystemBiosMajorVersion"] != null ? managementObject["SystemBiosMajorVersion"].ToString() : "undefined",
                        SystemBiosMinorVersion = managementObject["SystemBiosMinorVersion"] != null ? managementObject["SystemBiosMinorVersion"].ToString() : "undefined",
                        TargetOperatingSystem = managementObject["TargetOperatingSystem"] != null ? managementObject["TargetOperatingSystem"].ToString() : "undefined",
                        Version = managementObject["Version"] != null ? managementObject["Version"].ToString() : "undefined",

                    }); ;
                }
            }

            return biosDetailsList;
        }

        public List<ProcessorDetails> FetchProcessorDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);


                foreach (ManagementObject managementObject in searcher.Get())
                {

                    processorDetails.Add(new ProcessorDetails()
                    {
                        AddressWidth = managementObject["AddressWidth"] != null ? managementObject["AddressWidth"].ToString() : "undefined",
                        Architecture = managementObject["Architecture"] != null ? managementObject["Architecture"].ToString() : "undefined",
                        AssetTag = managementObject["AssetTag"] != null ? managementObject["AssetTag"].ToString() : "undefined",
                        Availability = managementObject["Availability"] != null ? managementObject["Availability"].ToString() : "undefined",
                        Caption = managementObject["Caption"] != null ? managementObject["Caption"].ToString() : "undefined",
                        Characteristics = managementObject["Characteristics"] != null ? managementObject["Characteristics"].ToString() : "undefined",
                        ConfigManagerErrorCode = managementObject["ConfigManagerErrorCode"] != null ? managementObject["ConfigManagerErrorCode"].ToString() : "undefined",
                        ConfigManagerUserConfig = managementObject["ConfigManagerUserConfig"] != null ? managementObject["ConfigManagerUserConfig"].ToString() : "undefined",
                        CpuStatus = managementObject["CpuStatus"] != null ? managementObject["CpuStatus"].ToString() : "undefined",
                        CreationClassName = managementObject["CreationClassName"] != null ? managementObject["CreationClassName"].ToString() : "undefined",
                        CurrentClockSpeed = managementObject["CurrentClockSpeed"] != null ? managementObject["CurrentClockSpeed"].ToString() : "undefined",
                        CurrentVoltage = managementObject["CurrentVoltage"] != null ? managementObject["CurrentVoltage"].ToString() : "undefined",
                        DataWidth = managementObject["DataWidth"] != null ? managementObject["DataWidth"].ToString() : "undefined",
                        Description = managementObject["Description"] != null ? managementObject["Description"].ToString() : "undefined",
                        DeviceID = managementObject["DeviceID"] != null ? managementObject["DeviceID"].ToString() : "undefined",
                        ErrorCleared = managementObject["ErrorCleared"] != null ? managementObject["ErrorCleared"].ToString() : "undefined",
                        ErrorDescription = managementObject["ErrorDescription"] != null ? managementObject["ErrorDescription"].ToString() : "undefined",
                        ExtClock = managementObject["ExtClock"] != null ? managementObject["ExtClock"].ToString() : "undefined",
                        Family = managementObject["Family"] != null ? managementObject["Family"].ToString() : "undefined",
                        InstallDate = managementObject["InstallDate"] != null ? managementObject["InstallDate"].ToString() : "undefined",
                        L2CacheSize = managementObject["L2CacheSize"] != null ? managementObject["L2CacheSize"].ToString() : "undefined",
                        L2CacheSpeed = managementObject["L2CacheSpeed"] != null ? managementObject["L2CacheSpeed"].ToString() : "undefined",
                        L3CacheSize = managementObject["L3CacheSize"] != null ? managementObject["L3CacheSize"].ToString() : "undefined",
                        L3CacheSpeed = managementObject["L3CacheSpeed"] != null ? managementObject["L3CacheSpeed"].ToString() : "undefined",
                        LastErrorCode = managementObject["LastErrorCode"] != null ? managementObject["LastErrorCode"].ToString() : "undefined",
                        Level = managementObject["Level"] != null ? managementObject["Level"].ToString() : "undefined",
                        LoadPercentage = managementObject["LoadPercentage"] != null ? managementObject["LoadPercentage"].ToString() : "undefined",
                        Manufacturer = managementObject["Manufacturer"] != null ? managementObject["Manufacturer"].ToString() : "undefined",
                        MaxClockSpeed = managementObject["MaxClockSpeed"] != null ? managementObject["MaxClockSpeed"].ToString() : "undefined",
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        NumberOfCores = managementObject["NumberOfCores"] != null ? managementObject["NumberOfCores"].ToString() : "undefined",
                        NumberOfEnabledCore = managementObject["NumberOfEnabledCore"] != null ? managementObject["NumberOfEnabledCore"].ToString() : "undefined",
                        NumberOfLogicalProcessors = managementObject["NumberOfLogicalProcessors"] != null ? managementObject["NumberOfLogicalProcessors"].ToString() : "undefined",
                        OtherFamilyDescription = managementObject["OtherFamilyDescription"] != null ? managementObject["OtherFamilyDescription"].ToString() : "undefined",
                        PartNumber = managementObject["PartNumber"] != null ? managementObject["PartNumber"].ToString() : "undefined",
                        PNPDeviceID = managementObject["PNPDeviceID"] != null ? managementObject["PNPDeviceID"].ToString() : "undefined",
                        PowerManagementCapabilities = managementObject["PowerManagementCapabilities"] != null ? managementObject["PowerManagementCapabilities"].ToString() : "undefined",
                        PowerManagementSupported = managementObject["PowerManagementSupported"] != null ? managementObject["PowerManagementSupported"].ToString() : "undefined",
                        ProcessorId = managementObject["ProcessorId"] != null ? managementObject["ProcessorId"].ToString() : "undefined",
                        ProcessorType = managementObject["ProcessorType"] != null ? managementObject["ProcessorType"].ToString() : "undefined",
                        Revision = managementObject["Revision"] != null ? managementObject["Revision"].ToString() : "undefined",
                        Role = managementObject["Role"] != null ? managementObject["Role"].ToString() : "undefined",
                        SecondLevelAddressTranslationExtensions = managementObject["SecondLevelAddressTranslationExtensions"] != null ? managementObject["SecondLevelAddressTranslationExtensions"].ToString() : "undefined",
                        SerialNumber = managementObject["SerialNumber"] != null ? managementObject["SerialNumber"].ToString() : "undefined",
                        SocketDesignation = managementObject["SocketDesignation"] != null ? managementObject["SocketDesignation"].ToString() : "undefined",
                        Status = managementObject["Status"] != null ? managementObject["Status"].ToString() : "undefined",
                        StatusInfo = managementObject["StatusInfo"] != null ? managementObject["StatusInfo"].ToString() : "undefined",
                        Stepping = managementObject["Stepping"] != null ? managementObject["Stepping"].ToString() : "undefined",
                        SystemCreationClassName = managementObject["SystemCreationClassName"] != null ? managementObject["SystemCreationClassName"].ToString() : "undefined",
                        SystemName = managementObject["SystemName"] != null ? managementObject["SystemName"].ToString() : "undefined",
                        ThreadCount = managementObject["ThreadCount"] != null ? managementObject["ThreadCount"].ToString() : "undefined",
                        UniqueId = managementObject["UniqueId"] != null ? managementObject["UniqueId"].ToString() : "undefined",
                        UpgradeMethod = managementObject["UpgradeMethod"] != null ? managementObject["UpgradeMethod"].ToString() : "undefined",
                        Version = managementObject["Version"] != null ? managementObject["Version"].ToString() : "undefined",
                        VirtualizationFirmwareEnabled = managementObject["VirtualizationFirmwareEnabled"] != null ? managementObject["VirtualizationFirmwareEnabled"].ToString() : "undefined",
                        VMMonitorModeExtensions = managementObject["VMMonitorModeExtensions"] != null ? managementObject["VMMonitorModeExtensions"].ToString() : "undefined",
                        VoltageCaps = managementObject["VoltageCaps"] != null ? managementObject["VoltageCaps"].ToString() : "undefined",
                    });

                }

            }
            return processorDetails;
        }

        public List<ComputerSystemDetails> FetchComputerSystemDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
        
                    var size = managementObject["TotalPhysicalMemory"].ToString();
                    var totalMemory = Math.Round(double.Parse(size) / (1024 * 1024 * 1024), 2).ToString();

                    var adminPasswordStatus = managementObject["AdminPasswordStatus"] != null ? managementObject["AdminPasswordStatus"].ToString() : "undefined";
                    var automaticManagedPagefile = managementObject["AutomaticManagedPagefile"] != null ? managementObject["AutomaticManagedPagefile"].ToString() : "undefined";
                    var automaticResetBootOption = managementObject["AutomaticResetBootOption"] != null ? managementObject["AutomaticResetBootOption"].ToString() : "undefined";
                    var automaticResetCapability = managementObject["AutomaticResetCapability"] != null ? managementObject["AutomaticResetCapability"].ToString() : "undefined";
                    var bootOptionOnLimit = managementObject["BootOptionOnLimit"] != null ? managementObject["BootOptionOnLimit"].ToString() : "undefined";
                    var bootOptionOnWatchDog = managementObject["BootOptionOnWatchDog"] != null ? managementObject["BootOptionOnWatchDog"].ToString() : "undefined";
                    var bootROMSupported = managementObject["BootROMSupported"] != null ? managementObject["BootROMSupported"].ToString() : "undefined";
                    var bootupState = managementObject["BootupState"] != null ? managementObject["BootupState"].ToString() : "undefined";
                    var bootStatus = managementObject["BootStatus"] != null ? managementObject["BootStatus"].ToString() : "undefined";
                    var caption = managementObject["Caption"] != null ? managementObject["Caption"].ToString() : "undefined";
                    var chassisBootupState = managementObject["ChassisBootupState"] != null ? managementObject["ChassisBootupState"].ToString() : "undefined";
                    var chassisSKUNumber = managementObject["ChassisSKUNumber"] != null ? managementObject["ChassisSKUNumber"].ToString() : "undefined";
                    var creationClassName = managementObject["CreationClassName"] != null ? managementObject["CreationClassName"].ToString() : "undefined";
                    var currentTimeZone = managementObject["CurrentTimeZone"] != null ? managementObject["CurrentTimeZone"].ToString() : "undefined";
                    var daylightInEffect = managementObject["DaylightInEffect"] != null ? managementObject["DaylightInEffect"].ToString() : "undefined";
                    var description = managementObject["Description"] != null ? managementObject["Description"].ToString() : "undefined";
                    var dnsHostName = managementObject["DNSHostName"] != null ? managementObject["DNSHostName"].ToString() : "undefined";
                    var domain = managementObject["Domain"] != null ? managementObject["Domain"].ToString() : "undefined";
                    var domainRole = managementObject["DomainRole"] != null ? managementObject["DomainRole"].ToString() : "undefined";
                    var enableDaylightSavingsTime = managementObject["EnableDaylightSavingsTime"] != null ? managementObject["EnableDaylightSavingsTime"].ToString() : "undefined";
                    var FrontPanelResetStatus = managementObject["EnableDaylightSavingsTime"] != null ? managementObject["EnableDaylightSavingsTime"].ToString() : "undefined";
                    var hypervisorPresent = managementObject["HypervisorPresent"] != null ? managementObject["HypervisorPresent"].ToString() : "undefined";
                    var infraredSupported = managementObject["InfraredSupported"] != null ? managementObject["InfraredSupported"].ToString() : "undefined";
                    var initialLoadInfo = managementObject["InitialLoadInfo"] != null ? managementObject["InitialLoadInfo"].ToString() : "undefined";
                    var installDate = managementObject["InstallDate"] != null ? managementObject["InstallDate"].ToString() : "undefined";
                    var keyboardPasswordStatus = managementObject["KeyboardPasswordStatus"] != null ? managementObject["KeyboardPasswordStatus"].ToString() : "undefined";
                    var lastLoadInfo = managementObject["LastLoadInfo"] != null ? managementObject["LastLoadInfo"].ToString() : "undefined";
                    var manufacturer = managementObject["Manufacturer"] != null ? managementObject["Manufacturer"].ToString() : "undefined";
                    var model = managementObject["Manufacturer"] != null ? managementObject["Manufacturer"].ToString() : "undefined";
                    var name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined";
                    var nameFormat = managementObject["NameFormat"] != null ? managementObject["NameFormat"].ToString() : "undefined";
                    var networkServerModeEnabled = managementObject["NetworkServerModeEnabled"] != null ? managementObject["NetworkServerModeEnabled"].ToString() : "undefined";
                    var numberOfLogicalProcessors = managementObject["NumberOfLogicalProcessors"] != null ? managementObject["NumberOfLogicalProcessors"].ToString() : "undefined";
                    var numberOfProcessors = managementObject["NumberOfProcessors"] != null ? managementObject["NumberOfProcessors"].ToString() : "undefined";
                    var OEMLogoBitmap = managementObject["OEMLogoBitmap"] != null ? managementObject["OEMLogoBitmap"].ToString() : "undefined";
                    var OEMStringArray = managementObject["OEMStringArray"] != null ? managementObject["OEMStringArray"].ToString() : "undefined";
                    var partOfDomain = managementObject["PartOfDomain"] != null ? managementObject["PartOfDomain"].ToString() : "undefined";
                    var pauseAfterReset = managementObject["PauseAfterReset"] != null ? managementObject["PauseAfterReset"].ToString() : "undefined";
                    var pcSystemType = managementObject["PCSystemType"] != null ? managementObject["PCSystemType"].ToString() : "undefined";
                    var pcSystemTypeEx = managementObject["PCSystemTypeEx"] != null ? managementObject["PCSystemTypeEx"].ToString() : "undefined";
                    var powerManagementCapabilities = managementObject["PowerManagementCapabilities"] != null ? managementObject["PowerManagementCapabilities"].ToString() : "undefined";
                    var powerManagementSupported = managementObject["PowerManagementSupported"] != null ? managementObject["PowerManagementSupported"].ToString() : "undefined";
                    var powerOnPasswordStatus = managementObject["PowerOnPasswordStatus"] != null ? managementObject["PowerOnPasswordStatus"].ToString() : "undefined";
                    var powerState = managementObject["PowerState"] != null ? managementObject["PowerState"].ToString() : "undefined";
                    var powerSupplyState = managementObject["PowerSupplyState"] != null ? managementObject["PowerSupplyState"].ToString() : "undefined";
                    var primaryOwnerContact = managementObject["PrimaryOwnerContact"] != null ? managementObject["PrimaryOwnerContact"].ToString() : "undefined";
                    var primaryOwnerName = managementObject["PrimaryOwnerName"] != null ? managementObject["PrimaryOwnerName"].ToString() : "undefined";
                    var resetCapability = managementObject["ResetCapability"] != null ? managementObject["ResetCapability"].ToString() : "undefined";
                    var resetCount = managementObject["ResetCount"] != null ? managementObject["ResetCount"].ToString() : "undefined";
                    var resetLimit = managementObject["ResetLimit"] != null ? managementObject["ResetLimit"].ToString() : "undefined";
                    var roles = managementObject["Roles"] != null ? managementObject["Roles"].ToString() : "undefined";
                    var status = managementObject["Status"] != null ? managementObject["Status"].ToString() : "undefined";
                    var supportContactDescription = managementObject["SupportContactDescription"] != null ? managementObject["SupportContactDescription"].ToString() : "undefined";
                    var systemFamily = managementObject["SystemFamily"] != null ? managementObject["SystemFamily"].ToString() : "undefined";
                    var systemSKUNumber = managementObject["SystemSKUNumber"] != null ? managementObject["SystemSKUNumber"].ToString() : "undefined";
                    var systemStartupDelay = managementObject["SystemStartupDelay"] != null ? managementObject["SystemStartupDelay"].ToString() : "undefined";
                    var systemStartupOptions = managementObject["SystemStartupOptions"] != null ? managementObject["SystemStartupOptions"].ToString() : "undefined";
                    var systemStartupSetting = managementObject["SystemStartupSetting"] != null ? managementObject["SystemStartupSetting"].ToString() : "undefined";
                    var systemType = managementObject["SystemType"] != null ? managementObject["SystemType"].ToString() : "undefined";
                    var thermalState = managementObject["ThermalState"] != null ? managementObject["ThermalState"].ToString() : "undefined";
                    var totalPhysicalMemory = totalMemory != null ? totalMemory : "undefined";
                    var userName = managementObject["UserName"] != null ? managementObject["UserName"].ToString() : "undefined";
                    var wakeUpType = managementObject["WakeUpType"] != null ? managementObject["WakeUpType"].ToString() : "undefined";
                    var workgroup = managementObject["Workgroup"] != null ? managementObject["Workgroup"].ToString() : "undefined";

                    computerSystemDetails.Add(new ComputerSystemDetails()
                    {
                        AdminPasswordStatus = adminPasswordStatus,
                        AutomaticManagedPagefile = automaticManagedPagefile,
                        AutomaticResetBootOption = automaticResetBootOption,
                        AutomaticResetCapability = automaticResetCapability,
                        //BootOptionOnLimit = bootOptionOnLimit,
                        BootOptionOnWatchDog = bootOptionOnWatchDog,
                        BootROMSupported= bootROMSupported,
                        BootupState = bootupState,
                        BootStatus =bootStatus,
                        Caption =caption,
                        ChassisBootupState=chassisBootupState,
                        ChassisSKUNumber=chassisSKUNumber,
                        CreationClassName=creationClassName,
                        CurrentTimeZone=currentTimeZone,
                        DaylightInEffect=daylightInEffect,
                        Description=description,
                        DNSHostName=dnsHostName,
                        Domain=domain,
                        DomainRole=domainRole,
                        EnableDaylightSavingsTime=enableDaylightSavingsTime,
                        FrontPanelResetStatus=FrontPanelResetStatus,
                        HypervisorPresent=hypervisorPresent,
                        InfraredSupported=infraredSupported,
                        InitialLoadInfo=initialLoadInfo,
                        InstallDate=installDate,
                        KeyboardPasswordStatus=keyboardPasswordStatus,
                        LastLoadInfo=lastLoadInfo,
                        Manufacturer=manufacturer,
                        Model=model,
                        Name=name,
                        NameFormat=nameFormat,
                        NetworkServerModeEnabled=networkServerModeEnabled,
                        NumberOfLogicalProcessors=numberOfLogicalProcessors,
                        NumberOfProcessors=numberOfProcessors,
                        OEMLogoBitmap=OEMLogoBitmap,
                        OEMStringArray=OEMStringArray,
                        PartOfDomain=partOfDomain,
                        PauseAfterReset=pauseAfterReset,
                        PCSystemType=pcSystemType,
                        PCSystemTypeEx=pcSystemTypeEx,
                        PowerManagementCapabilities=powerManagementCapabilities,
                        PowerManagementSupported=powerManagementSupported,
                        PowerOnPasswordStatus=powerOnPasswordStatus,
                        PowerState=powerState,
                        PowerSupplyState=powerSupplyState,
                        PrimaryOwnerContact=primaryOwnerContact,
                        PrimaryOwnerName=primaryOwnerName,
                        ResetCapability=resetCapability,
                        ResetCount=resetCount,
                        ResetLimit=resetLimit,
                        Roles=roles,
                        Status=status,
                        SupportContactDescription=supportContactDescription,
                        SystemFamily=systemFamily,
                        SystemSKUNumber=systemSKUNumber,
                        SystemStartupDelay=systemStartupDelay,
                        SystemStartupOptions=systemStartupOptions,
                        SystemStartupSetting=systemStartupSetting,
                        SystemType=systemType,
                        ThermalState=thermalState,
                        TotalPhysicalMemory=totalPhysicalMemory,
                        UserName=userName,
                        WakeUpType=wakeUpType,
                        Workgroup=workgroup
                    });

                }
            }
            return computerSystemDetails;
        }

        public List<UpdatesDetails> FetchUpdatesDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_QuickFixEngineering");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    var caption = managementObject["Caption"] != null ? managementObject["Caption"].ToString() : "undefinded";
                    var installDate = managementObject["InstallDate"] != null ? managementObject["InstallDate"].ToString() : "undefinded";
                    var name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefinded";
                    var status = managementObject["Status"] != null ? managementObject["Status"].ToString() : "undefinded";
                    var csName = managementObject["CSName"] != null ? managementObject["CSName"].ToString() : "undefinded";
                    var fixComments = managementObject["FixComments"] != null ? managementObject["FixComments"].ToString() : "undefinded";
                    var desciption = managementObject["Description"] != null ? managementObject["Description"].ToString() : "undefinded";
                    var hotFixID = managementObject["HotFixID"] != null ? managementObject["HotFixID"].ToString() : "undefinded";
                    var instaledBy = managementObject["InstalledBy"] != null ? managementObject["InstalledBy"].ToString() : "undefinded";
                    var instaledOn = managementObject["InstalledOn"] != null ? managementObject["InstalledOn"].ToString() : "undefinded";
                    var servicePackInEffect = managementObject["ServicePackInEffect"] != null ? managementObject["ServicePackInEffect"].ToString() : "undefinded";


                    updatesDetails.Add(new UpdatesDetails()
                    {
                        Caption = caption,
                        InstallDate = installDate,
                        Name = name,
                        Status = status,
                        CSName = csName,
                        FixComments =fixComments,
                        Description = desciption,
                        HotFixID = hotFixID,
                        InstaledBy = instaledBy,
                        InstaledOn = instaledOn,
                        ServicePackInEffect = servicePackInEffect
                    });
                }
            }
            return updatesDetails;
        }

        public List<StorageDetails> FetchStorageData()
        {

            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    var size = managementObject["Size"] != null ? managementObject["Size"].ToString() : "0";
                    var freeSpace = managementObject["FreeSpace"] != null ? managementObject["FreeSpace"].ToString() : "0";

                    var diskSize = Math.Round(double.Parse(size) / (1024 * 1024 * 1024), 2);
                    var diskFreespace = Math.Round(double.Parse(freeSpace) / (1024 * 1024 * 1024), 2);

                    if (diskSize > 0)
                    {
                        storageDetailsList.Add(
                        new StorageDetails()
                        {
                            ServerName = scope.Path.Server,
                            DriveName = managementObject["Name"].ToString(),
                            DriveLabel = managementObject["VolumeName"].ToString(),
                            DiskSize = diskSize,
                            DiskFreeSpace = diskFreespace,
                            DiskUsedSpace = Math.Round(diskSize - diskFreespace, 2),
                            FreeSpacePercentage = Math.Round(diskFreespace / diskSize * 100, 2)
                        });
                    }
                    
                }


            }

            return storageDetailsList;
        }

        public List<MotherBoardTempsDetails> FetchMotherboardTempsData()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Counters_ThermalZoneInformation");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    var instanceName = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined";
                    var temperature = managementObject["Temperature"] != null ? managementObject["Temperature"].ToString() : "undefined";
                    temperature = temperature != "undefined" ? (Convert.ToDouble(temperature)/10).ToString() : "undefiend";

                    motherboardTempsDetails.Add(new MotherBoardTempsDetails()
                    {
                        Temperature = temperature,
                        Name = instanceName
                    });

                }
            }
            return motherboardTempsDetails;
        }
        public List<FansDetails> FetchFansDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Fan");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    fansDetails.Add(new FansDetails()
                    {
                        ActiveCooling = managementObject["ActiveCooling"] != null ? managementObject["ActiveCooling"].ToString() : "undefined",
                        Availability = managementObject["Availability"] != null ? managementObject["Availability"].ToString() : "undefined",
                        Caption = managementObject["Caption"] != null ? managementObject["Caption"].ToString() : "undefined",
                        ConfigManagerErrorCode = managementObject["ConfigManagerErrorCode"] != null ? managementObject["ConfigManagerErrorCode"].ToString() : "undefined",
                        ConfigManagerUserConfig = managementObject["ConfigManagerUserConfig"] != null ? managementObject["ConfigManagerUserConfig"].ToString() : "undefined",
                        CreationClassName = managementObject["CreationClassName"] != null ? managementObject["CreationClassName"].ToString() : "undefined",
                        Description = managementObject["Description"] != null ? managementObject["Description"].ToString() : "undefined",
                        DesiredSpeed = managementObject["DesiredSpeed"] != null ? managementObject["DesiredSpeed"].ToString() : "undefined",
                        DeviceID = managementObject["DeviceID"] != null ? managementObject["DeviceID"].ToString() : "undefined",
                        ErrorCleared = managementObject["ErrorCleared"] != null ? managementObject["ErrorCleared"].ToString() : "undefined",
                        ErrorDescription = managementObject["ErrorDescription"] != null ? managementObject["ErrorDescription"].ToString() : "undefined",
                        InstallDate = managementObject["InstallDate"] != null ? managementObject["InstallDate"].ToString() : "undefined",
                        LastErrorCode = managementObject["LastErrorCode"] != null ? managementObject["LastErrorCode"].ToString() : "undefined",
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        PNPDeviceID = managementObject["PNPDeviceID"] != null ? managementObject["PNPDeviceID"].ToString() : "undefined",
                        PowerManagementCapabilities = managementObject["PowerManagementCapabilities"] != null ? managementObject["PowerManagementCapabilities"].ToString() : "undefined",
                        PowerManagementSupported = managementObject["PowerManagementSupported"] != null ? managementObject["PowerManagementSupported"].ToString() : "undefined",
                        Status = managementObject["Status"] != null ? managementObject["Status"].ToString() : "undefined",
                        StatusInfo = managementObject["StatusInfo"] != null ? managementObject["StatusInfo"].ToString() : "undefined",
                        SystemCreationClassName = managementObject["SystemCreationClassName"] != null ? managementObject["SystemCreationClassName"].ToString() : "undefined",
                        SystemName = managementObject["SystemName"] != null ? managementObject["SystemName"].ToString() : "undefined",
                        VariableSpeed = managementObject["VariableSpeed"] != null ? managementObject["VariableSpeed"].ToString() : "undefined"
                    });

                }


            }
            return fansDetails;

        }

        public List<MemoryDetals> FetchMemoryDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    var size = managementObject["Capacity"].ToString();
                    var capacity = Math.Round(double.Parse(size) / (1024 * 1024 * 1024), 2).ToString();
                    memoryDetals.Add(new MemoryDetals()
                    {
                        Caption = managementObject["Caption"] != null ? managementObject["Caption"].ToString() : "undefined",
                        Description = managementObject["Description"] != null ? managementObject["Description"].ToString() : "undefined",
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        Manufacturer = managementObject["Manufacturer"] != null ? managementObject["Manufacturer"].ToString() : "undefined",
                        PartNumber = managementObject["PartNumber"] != null ? managementObject["PartNumber"].ToString() : "undefined",
                        SerialNumber = managementObject["SerialNumber"] != null ? managementObject["SerialNumber"].ToString() : "undefined",
                        Tag = managementObject["Tag"] != null ? managementObject["Tag"].ToString() : "undefined",
                        FormFactor = managementObject["FormFactor"] != null ? managementObject["FormFactor"].ToString() : "undefined",
                        BankLabel = managementObject["BankLabel"] != null ? managementObject["BankLabel"].ToString() : "undefined",
                        Capacity = capacity != null ? capacity : "undefined",
                        DataWidth = managementObject["DataWidth"] != null ? managementObject["DataWidth"].ToString() : "undefined",
                        InterleavePosition = managementObject["InterleavePosition"] != null ? managementObject["InterleavePosition"].ToString() : "undefined",
                        MemoryType = managementObject["MemoryType"] != null ? managementObject["MemoryType"].ToString() : "undefined",
                        Speed = managementObject["Speed"] != null ? managementObject["Speed"].ToString() : "undefined",
                        TotalWidth = managementObject["TotalWidth"] != null ? managementObject["TotalWidth"].ToString() : "undefined",
                        Attributes = managementObject["Attributes"] != null ? managementObject["Attributes"].ToString() : "undefined",
                        DeviceLocator = managementObject["DeviceLocator"] != null ? managementObject["DeviceLocator"].ToString() : "undefined",
                        InterleaveDataDepth = managementObject["InterleaveDataDepth"] != null ? managementObject["InterleaveDataDepth"].ToString() : "undefined",
                        SMBIOSMemoryType = managementObject["SMBIOSMemoryType"] != null ? managementObject["SMBIOSMemoryType"].ToString() : "undefined",
                        TypeDetail = managementObject["TypeDetail"] != null ? managementObject["TypeDetail"].ToString() : "undefined",
                    });
                }
            }
            return memoryDetals;
        }

        public List<MemoryPerformanceDetails> FetachMemoryPerformanceDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Memory");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    memoryPerformanceDetails.Add(new MemoryPerformanceDetails()
                    {
                        AvailableBytes = managementObject["AvailableBytes"] != null ? managementObject["AvailableBytes"].ToString() : "undefined",
                        AvailableKBytes = managementObject["AvailableKBytes"] != null ? managementObject["AvailableKBytes"].ToString() : "undefined",
                        AvailableMBytes = managementObject["AvailableMBytes"] != null ? managementObject["AvailableMBytes"].ToString() : "undefined",
                        CacheBytes = managementObject["CacheBytes"] != null ? managementObject["CacheBytes"].ToString() : "undefined",
                        CacheBytesPeak = managementObject["CacheBytesPeak"] != null ? managementObject["CacheBytesPeak"].ToString() : "undefined",
                        CacheFaultsPersec = managementObject["CacheFaultsPersec"] != null ? managementObject["CacheFaultsPersec"].ToString() : "undefined",
                        CommitLimit = managementObject["CommitLimit"] != null ? managementObject["CommitLimit"].ToString() : "undefined",
                        CommittedBytes = managementObject["CommittedBytes"] != null ? managementObject["CommittedBytes"].ToString() : "undefined",
                        DemandZeroFaultsPersec = managementObject["DemandZeroFaultsPersec"] != null ? managementObject["DemandZeroFaultsPersec"].ToString() : "undefined",
                        FreeAndZeroPageListBytes = managementObject["FreeAndZeroPageListBytes"] != null ? managementObject["FreeAndZeroPageListBytes"].ToString() : "undefined",
                        FreeSystemPageTableEntries = managementObject["FreeSystemPageTableEntries"] != null ? managementObject["FreeSystemPageTableEntries"].ToString() : "undefined",
                        LongTermAverageStandbyCacheLifetimes = managementObject["LongTermAverageStandbyCacheLifetimes"] != null ? managementObject["LongTermAverageStandbyCacheLifetimes"].ToString() : "undefined",
                        ModifiedPageListBytes = managementObject["ModifiedPageListBytes"] != null ? managementObject["ModifiedPageListBytes"].ToString() : "undefined",
                        PageFaultsPersec = managementObject["PageFaultsPersec"] != null ? managementObject["PageFaultsPersec"].ToString() : "undefined",
                        PageReadsPersec = managementObject["PageReadsPersec"] != null ? managementObject["PageReadsPersec"].ToString() : "undefined",
                        PagesInputPersec = managementObject["PagesInputPersec"] != null ? managementObject["PagesInputPersec"].ToString() : "undefined",
                        PagesOutputPersec = managementObject["PagesOutputPersec"] != null ? managementObject["PagesOutputPersec"].ToString() : "undefined",
                        PagesPersec = managementObject["PagesPersec"] != null ? managementObject["PagesPersec"].ToString() : "undefined",
                        PageWritesPersec = managementObject["PageWritesPersec"] != null ? managementObject["PageWritesPersec"].ToString() : "undefined",
                        PercentCommittedBytesInUse = managementObject["PercentCommittedBytesInUse"] != null ? managementObject["PercentCommittedBytesInUse"].ToString() : "undefined",
                        PoolNonpagedAllocs = managementObject["PoolNonpagedAllocs"] != null ? managementObject["PoolNonpagedAllocs"].ToString() : "undefined",
                        PoolNonpagedBytes = managementObject["PoolNonpagedBytes"] != null ? managementObject["PoolNonpagedBytes"].ToString() : "undefined",
                        PoolPagedAllocs = managementObject["PoolPagedAllocs"] != null ? managementObject["PoolPagedAllocs"].ToString() : "undefined",
                        PoolPagedBytes = managementObject["PoolPagedBytes"] != null ? managementObject["PoolPagedBytes"].ToString() : "undefined",
                        PoolPagedResidentBytes = managementObject["PoolPagedResidentBytes"] != null ? managementObject["PoolPagedResidentBytes"].ToString() : "undefined",
                        StandbyCacheCoreBytes = managementObject["StandbyCacheCoreBytes"] != null ? managementObject["StandbyCacheCoreBytes"].ToString() : "undefined",

                        StandbyCacheNormalPriorityBytes = managementObject["StandbyCacheNormalPriorityBytes"] != null ? managementObject["StandbyCacheNormalPriorityBytes"].ToString() : "undefined",
                        StandbyCacheReserveBytes = managementObject["StandbyCacheReserveBytes"] != null ? managementObject["StandbyCacheReserveBytes"].ToString() : "undefined",
                        SystemCacheResidentBytes = managementObject["SystemCacheResidentBytes"] != null ? managementObject["SystemCacheResidentBytes"].ToString() : "undefined",
                        SystemCodeResidentBytes = managementObject["SystemCodeResidentBytes"] != null ? managementObject["SystemCodeResidentBytes"].ToString() : "undefined",
                        SystemCodeTotalBytes = managementObject["SystemCodeTotalBytes"] != null ? managementObject["SystemCodeTotalBytes"].ToString() : "undefined",
                        SystemDriverResidentBytes = managementObject["SystemDriverResidentBytes"] != null ? managementObject["SystemDriverResidentBytes"].ToString() : "undefined",
                        SystemDriverTotalBytes = managementObject["SystemDriverTotalBytes"] != null ? managementObject["SystemDriverTotalBytes"].ToString() : "undefined",
                        TransitionFaultsPersec = managementObject["TransitionFaultsPersec"] != null ? managementObject["TransitionFaultsPersec"].ToString() : "undefined",
                        TransitionPagesRePurposedPersec = managementObject["TransitionPagesRePurposedPersec"] != null ? managementObject["TransitionPagesRePurposedPersec"].ToString() : "undefined",
                        WriteCopiesPersec = managementObject["WriteCopiesPersec"] != null ? managementObject["WriteCopiesPersec"].ToString() : "undefined",
                    });

                }
            }
            return memoryPerformanceDetails;
        }

        public List<ProcessorPerformanceDetails> FetachProcessorPerformanceDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    processorPerformanceDetails.Add(new ProcessorPerformanceDetails()
                    {
                        C1TransitionsPersec = managementObject["C1TransitionsPersec"] != null ? managementObject["C1TransitionsPersec"].ToString() : "undefined",
                        C2TransitionsPersec = managementObject["C2TransitionsPersec"] != null ? managementObject["C2TransitionsPersec"].ToString() : "undefined",
                        C3TransitionsPersec = managementObject["C3TransitionsPersec"] != null ? managementObject["C3TransitionsPersec"].ToString() : "undefined",
                        DPCRate = managementObject["DPCRate"] != null ? managementObject["DPCRate"].ToString() : "undefined",
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        DPCsQueuedPersec = managementObject["DPCsQueuedPersec"] != null ? managementObject["DPCsQueuedPersec"].ToString() : "undefined",
                        InterruptsPersec = managementObject["InterruptsPersec"] != null ? managementObject["InterruptsPersec"].ToString() : "undefined",
                        PercentC1Time = managementObject["PercentC1Time"] != null ? managementObject["PercentC1Time"].ToString() : "undefined",
                        PercentC2Time = managementObject["PercentC2Time"] != null ? managementObject["PercentC2Time"].ToString() : "undefined",
                        PercentC3Time = managementObject["PercentC3Time"] != null ? managementObject["PercentC3Time"].ToString() : "undefined",
                        PercentDPCTime = managementObject["PercentDPCTime"] != null ? managementObject["PercentDPCTime"].ToString() : "undefined",
                        PercentIdleTime = managementObject["PercentIdleTime"] != null ? managementObject["PercentIdleTime"].ToString() : "undefined",
                        PercentInterruptTime = managementObject["PercentInterruptTime"] != null ? managementObject["PercentInterruptTime"].ToString() : "undefined",
                        PercentPrivilegedTime = managementObject["PercentPrivilegedTime"] != null ? managementObject["PercentPrivilegedTime"].ToString() : "undefined",
                        PercentProcessorTime = managementObject["PercentProcessorTime"] != null ? managementObject["PercentProcessorTime"].ToString() : "undefined",
                        PercentUserTime = managementObject["PercentUserTime"] != null ? managementObject["PercentUserTime"].ToString() : "undefined"
                    });

                }
            }
            return processorPerformanceDetails;
        }

        public List<SystemPerformanceDetails> FetchSystemPerformanceDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_System");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    systemPerformanceDetails.Add(new SystemPerformanceDetails()
                    {
                        AlignmentFixupsPersec = managementObject["AlignmentFixupsPersec"] != null ? managementObject["AlignmentFixupsPersec"].ToString() : "undefined",
                        ContextSwitchesPersec = managementObject["ContextSwitchesPersec"] != null ? managementObject["ContextSwitchesPersec"].ToString() : "undefined",
                        ExceptionDispatchesPersec = managementObject["ExceptionDispatchesPersec"] != null ? managementObject["ExceptionDispatchesPersec"].ToString() : "undefined",
                        FileControlBytesPersec = managementObject["FileControlBytesPersec"] != null ? managementObject["FileControlBytesPersec"].ToString() : "undefined",
                        FileControlOperationsPersec = managementObject["FileControlOperationsPersec"] != null ? managementObject["FileControlOperationsPersec"].ToString() : "undefined",
                        FileDataOperationsPersec = managementObject["FileDataOperationsPersec"] != null ? managementObject["FileDataOperationsPersec"].ToString() : "undefined",
                        FileReadBytesPersec = managementObject["FileReadBytesPersec"] != null ? managementObject["FileReadBytesPersec"].ToString() : "undefined",
                        FileReadOperationsPersec = managementObject["FileReadOperationsPersec"] != null ? managementObject["FileReadOperationsPersec"].ToString() : "undefined",
                        FileWriteBytesPersec = managementObject["FileWriteBytesPersec"] != null ? managementObject["FileWriteBytesPersec"].ToString() : "undefined",
                        FileWriteOperationsPersec = managementObject["FileWriteOperationsPersec"] != null ? managementObject["FileWriteOperationsPersec"].ToString() : "undefined",
                        FloatingEmulationsPersec = managementObject["FloatingEmulationsPersec"] != null ? managementObject["FloatingEmulationsPersec"].ToString() : "undefined",
                        PercentRegistryQuotaInUse = managementObject["PercentRegistryQuotaInUse"] != null ? managementObject["PercentRegistryQuotaInUse"].ToString() : "undefined",
                        Processes = managementObject["Processes"] != null ? managementObject["Processes"].ToString() : "undefined",
                        ProcessorQueueLength = managementObject["ProcessorQueueLength"] != null ? managementObject["ProcessorQueueLength"].ToString() : "undefined",
                        SystemCallsPersec = managementObject["SystemCallsPersec"] != null ? managementObject["SystemCallsPersec"].ToString() : "undefined",
                        SystemUpTime = managementObject["SystemUpTime"] != null ? managementObject["SystemUpTime"].ToString() : "undefined",
                        Threads = managementObject["Threads"] != null ? managementObject["Threads"].ToString() : "undefined",
                    });
                }

            }
            return systemPerformanceDetails;
        }
        public List<NetworkPerformanceDetails> FetchNetworkPerformanceDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    networkPerformanceDetails.Add(new NetworkPerformanceDetails()
                    {
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        BytesReceivedPersec = managementObject["BytesReceivedPersec"] != null ? managementObject["BytesReceivedPersec"].ToString() : "undefined",
                        BytesSentPersec = managementObject["BytesSentPersec"] != null ? managementObject["BytesSentPersec"].ToString() : "undefined",
                        BytesTotalPersec = managementObject["BytesTotalPersec"] != null ? managementObject["BytesTotalPersec"].ToString() : "undefined",
                        CurrentBandwidth = managementObject["CurrentBandwidth"] != null ? managementObject["CurrentBandwidth"].ToString() : "undefined",
                        OffloadedConnections = managementObject["OffloadedConnections"] != null ? managementObject["OffloadedConnections"].ToString() : "undefined",
                        OutputQueueLength = managementObject["OutputQueueLength"] != null ? managementObject["OutputQueueLength"].ToString() : "undefined",
                        PacketsOutboundDiscarded = managementObject["PacketsOutboundDiscarded"] != null ? managementObject["PacketsOutboundDiscarded"].ToString() : "undefined",
                        PacketsOutboundErrors = managementObject["PacketsOutboundErrors"] != null ? managementObject["PacketsOutboundErrors"].ToString() : "undefined",
                        PacketsPersec = managementObject["PacketsPersec"] != null ? managementObject["PacketsPersec"].ToString() : "undefined",
                        PacketsReceivedDiscarded = managementObject["PacketsReceivedDiscarded"] != null ? managementObject["PacketsReceivedDiscarded"].ToString() : "undefined",
                        PacketsReceivedErrors = managementObject["PacketsReceivedErrors"] != null ? managementObject["PacketsReceivedErrors"].ToString() : "undefined",
                        PacketsReceivedNonUnicastPersec = managementObject["PacketsReceivedNonUnicastPersec"] != null ? managementObject["PacketsReceivedNonUnicastPersec"].ToString() : "undefined",
                        PacketsReceivedPersec = managementObject["PacketsReceivedPersec"] != null ? managementObject["PacketsReceivedPersec"].ToString() : "undefined",
                        PacketsReceivedUnicastPersec = managementObject["PacketsReceivedUnicastPersec"] != null ? managementObject["PacketsReceivedUnicastPersec"].ToString() : "undefined",
                        PacketsReceivedUnknown = managementObject["PacketsReceivedUnknown"] != null ? managementObject["PacketsReceivedUnknown"].ToString() : "undefined",
                        PacketsSentNonUnicastPersec = managementObject["PacketsSentNonUnicastPersec"] != null ? managementObject["PacketsSentNonUnicastPersec"].ToString() : "undefined",
                        PacketsSentPersec = managementObject["PacketsSentPersec"] != null ? managementObject["PacketsSentPersec"].ToString() : "undefined",
                        PacketsSentUnicastPersec = managementObject["PacketsSentUnicastPersec"] != null ? managementObject["PacketsSentUnicastPersec"].ToString() : "undefined",
                        TCPActiveRSCConnections = managementObject["TCPActiveRSCConnections"] != null ? managementObject["TCPActiveRSCConnections"].ToString() : "undefined",
                        TCPRSCAveragePacketSize = managementObject["TCPRSCAveragePacketSize"] != null ? managementObject["TCPRSCAveragePacketSize"].ToString() : "undefined",
                        TCPRSCCoalescedPacketsPersec = managementObject["TCPRSCCoalescedPacketsPersec"] != null ? managementObject["TCPRSCCoalescedPacketsPersec"].ToString() : "undefined",
                        TCPRSCExceptionsPersec = managementObject["TCPRSCExceptionsPersec"] != null ? managementObject["TCPRSCExceptionsPersec"].ToString() : "undefined",
                    });

                }
            }
            return networkPerformanceDetails;
        }

        public List<StoragePerformanceDetails> FetchStoragePerformanceDetails()
        {
            foreach (string servername in serverNames)
            {
                // Set up scope for remote server
                // scope = new ManagementScope($"\\\\{servername}\\root\\CIMV2", connection);

                // Set up scope for local machine - develop
                ManagementScope scope = new ManagementScope("root\\cimv2");

                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfDisk_LogicalDisk");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject managementObject in searcher.Get())
                {
                    storagePerformanceDetails.Add(new StoragePerformanceDetails()
                    {
                        Name = managementObject["Name"] != null ? managementObject["Name"].ToString() : "undefined",
                        AvgDiskBytesPerRead  = managementObject["AvgDiskBytesPerRead"] != null ? managementObject["AvgDiskBytesPerRead"].ToString() : "undefined",
                        AvgDiskBytesPerTransfer  = managementObject["AvgDiskBytesPerTransfer"] != null ? managementObject["AvgDiskBytesPerTransfer"].ToString() : "undefined",
                        AvgDiskBytesPerWrite  = managementObject["AvgDiskBytesPerWrite"] != null ? managementObject["AvgDiskBytesPerWrite"].ToString() : "undefined",
                        AvgDiskQueueLength  = managementObject["AvgDiskQueueLength"] != null ? managementObject["AvgDiskQueueLength"].ToString() : "undefined",
                        AvgDiskReadQueueLength  = managementObject["AvgDiskReadQueueLength"] != null ? managementObject["AvgDiskReadQueueLength"].ToString() : "undefined",
                        AvgDisksecPerRead  = managementObject["AvgDisksecPerRead"] != null ? managementObject["AvgDisksecPerRead"].ToString() : "undefined",
                        AvgDisksecPerTransfer  = managementObject["AvgDisksecPerTransfer"] != null ? managementObject["AvgDisksecPerTransfer"].ToString() : "undefined",
                        AvgDisksecPerWrite  = managementObject["AvgDisksecPerWrite"] != null ? managementObject["AvgDisksecPerWrite"].ToString() : "undefined",
                        AvgDiskWriteQueueLength  = managementObject["AvgDiskWriteQueueLength"] != null ? managementObject["AvgDiskWriteQueueLength"].ToString() : "undefined",
                        CurrentDiskQueueLength  = managementObject["CurrentDiskQueueLength"] != null ? managementObject["CurrentDiskQueueLength"].ToString() : "undefined",
                        DiskBytesPersec  = managementObject["DiskBytesPersec"] != null ? managementObject["DiskBytesPersec"].ToString() : "undefined",
                        DiskReadBytesPersec  = managementObject["DiskReadBytesPersec"] != null ? managementObject["DiskReadBytesPersec"].ToString() : "undefined",
                        DiskReadsPersec  = managementObject["DiskReadsPersec"] != null ? managementObject["DiskReadsPersec"].ToString() : "undefined",
                        DiskTransfersPersec  = managementObject["DiskTransfersPersec"] != null ? managementObject["DiskTransfersPersec"].ToString() : "undefined",
                        DiskWriteBytesPersec  = managementObject["DiskWriteBytesPersec"] != null ? managementObject["DiskWriteBytesPersec"].ToString() : "undefined",
                        DiskWritesPersec  = managementObject["DiskWritesPersec"] != null ? managementObject["DiskWritesPersec"].ToString() : "undefined",
                        FreeMegabytes  = managementObject["FreeMegabytes"] != null ? managementObject["FreeMegabytes"].ToString() : "undefined",
                        PercentDiskReadTime  = managementObject["PercentDiskReadTime"] != null ? managementObject["PercentDiskReadTime"].ToString() : "undefined",
                        PercentDiskTime  = managementObject["PercentDiskTime"] != null ? managementObject["PercentDiskTime"].ToString() : "undefined",
                        PercentDiskWriteTime  = managementObject["PercentDiskWriteTime"] != null ? managementObject["PercentDiskWriteTime"].ToString() : "undefined",
                        PercentFreeSpace  = managementObject["PercentFreeSpace"] != null ? managementObject["PercentFreeSpace"].ToString() : "undefined",
                        PercentIdleTime  = managementObject["PercentIdleTime"] != null ? managementObject["PercentIdleTime"].ToString() : "undefined",
                        SplitIOPerSec  = managementObject["SplitIOPerSec"] != null ? managementObject["SplitIOPerSec"].ToString() : "undefined",
    });
                }
            }
            return storagePerformanceDetails;
        }
    }
}
