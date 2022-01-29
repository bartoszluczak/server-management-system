export interface DiskDetails {
  diskFreeSpace: number;
  diskSize: number;
  diskUsedSpace: number;
  driveLabel: string;
  driveName: string;
  freeSpacePercentage: number;
  serverName: string;
}

export interface AvgDiskBytesDetails {
  avgDiskBytesPerRead: string;
  avgDiskBytesPerTransfer: string;
  avgDiskBytesPerWrite: string;
  avgDiskQueueLength: string;
  avgDiskReadQueueLength: string;
  avgDiskWriteQueueLength: string;
  avgDisksecPerRead: string;
  avgDisksecPerTransfer: string;
  avgDisksecPerWrite: string;
  currentDiskQueueLength: string;
  diskBytesPersec: string;
  diskReadBytesPersec: string;
  diskReadsPersec: string;
  diskTransfersPersec: string;
  diskWriteBytesPersec: string;
  diskWritesPersec: string;
  freeMegabytes: string;
  name: string;
  percentDiskReadTime: string;
  percentDiskTime: string;
  percentDiskWriteTime: string;
  percentFreeSpace: string;
  percentIdleTime: string;
  splitIOPerSec: string;
}
