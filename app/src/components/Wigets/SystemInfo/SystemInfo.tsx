import React, { useEffect, useState } from "react";
import WidgetContainer from "../../UI/WidgetContainer";
import classes from "./SystemInfo.module.css";
import SystemInfoItem from "./SystemInfoItem";
import axios from "axios";
import { log } from "util";
import { isAllOf } from "@reduxjs/toolkit";

const SystemInfo: React.FC = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [computerSystemData, setComputerSystemData] = useState({});
  const [procesorData, setProcesorData] = useState({});
  const [biosData, setBiosData] = useState({});
  const [memoryData, setMemoryData] = useState({});

  const systemDataFields = [
    "description",
    "dnsHostName",
    "domain",
    "manufacturer",
    "systemFamily",
    "name",
    "numberOfProcessors",
    "numberOfLogicalProcessors",
    "systemType",
    "totalPhysicalMemory",
    "primaryOwnerName",
  ];

  const procesorDataFields = [
    "caption",
    "currentClockSpeed",
    "currentVoltage",
    "extClock",
    "family",
    "l2CacheSize",
    "l3CacheSize",
    "manufacturer",
    "maxClockSpeed",
    "name",
    "numberOfCores",
    "numberOfEnabledCore",
    "numberOfLogicalProcessors",
    "processorId",
  ];

  const biosDataField = [
    "caption",
    "currentLanguage",
    "embeddedControllerMajorVersion",
    "embeddedControllerMinorVersion",
    "manufacturer",
    "releaseDate",
    "serialNumber",
    "smbiosbiosVersion",
    "smbiosMajorVersion",
    "smbiosMinorVersion",
    "version",
  ];

  const memoryDataField = [
    "caption",
    "tag",
    "bankLabel",
    "capacity",
    "speed",
    "deviceLocator",
  ];

  const getDetailsData = (url: string, setFunction: any) => {
    axios.get<any[]>(`/systemdetails/${url}`).then((res) => {
      setFunction(res.data);
      setIsLoading(false);
    });
  };

  const getRedisData = () => {
    axios.get<any>(`/systemdetails/bios-redis`).then((res: any) => {
      const dataObject: any = {};

      res.data.forEach((item: any) => {
        const tempArr = item.split(":");
        dataObject[`${tempArr[0]}`] = tempArr[1];
      });

      console.log(dataObject);
    });
  };

  useEffect(() => {
    getDetailsData("computersystem", setComputerSystemData);
    getDetailsData("processor", setProcesorData);
    getDetailsData("bios", setBiosData);
    getDetailsData("memory", setMemoryData);
    getRedisData();
  }, []);

  return (
    <WidgetContainer>
      <h3>System info</h3>
      <div className={classes.systemInfoContainer}>
        <h3>Basic info</h3>
        <SystemInfoItem
          systemDetailsData={computerSystemData}
          systemDataFields={systemDataFields}
        />
      </div>
      <div className={classes.systemInfoContainer}>
        <h3>Processor info</h3>
        <SystemInfoItem
          systemDetailsData={procesorData}
          systemDataFields={procesorDataFields}
        />
      </div>
      <div className={classes.systemInfoContainer}>
        <h3>Bios info</h3>
        <SystemInfoItem
          systemDetailsData={biosData}
          systemDataFields={biosDataField}
        />
      </div>
      <div className={classes.systemInfoContainer}>
        <h3>Memory info</h3>
        <SystemInfoItem
          systemDetailsData={memoryData}
          systemDataFields={memoryDataField}
        />
      </div>
    </WidgetContainer>
  );
};

export default SystemInfo;
