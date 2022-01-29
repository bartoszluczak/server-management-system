import React, { useEffect, useState } from "react";
import classes from "./DiskDetailsLineDiagram.module.css";
import FreeSpaceLineDiagram from "./DiagramTypes/FreeSpaceLineDiagram";
import DiskPerformanceDiagram from "./DiagramTypes/DiskPerformanceDiagram";
import axios from "axios";
import { AvgDiskBytesDetails } from "../../../models/diskDetails";

const DiskDetailsLineDiagram: React.FC = () => {
  const [AvgDiskBytesData, setAvgDiskBytesData] = useState<any>([]);
  const [filteredAvgBytesData, setFilteredAvgDiskData] = useState<any>([]);

  const getData: any = async (
    urlAddress: string,
    refreshRate: number,
    setDataFunction: Function
  ) => {
    console.log("get data");
    const interval = setInterval(async () => {
      await axios.get<AvgDiskBytesDetails[]>(`${urlAddress}`).then((res) => {
        setDataFunction(res.data);
      });
    }, refreshRate);
    return interval;
  };

  useEffect(() => {
    const avgDiskBytesInter = getData(
      "/SystemPerformance/storage",
      5000,
      setAvgDiskBytesData
    );

    return () => {
      clearInterval(avgDiskBytesInter);
    };
  }, []);

  useEffect(() => {
    const filteredData = AvgDiskBytesData.filter(
      (item: AvgDiskBytesDetails) =>
        !item.name.toLowerCase().includes("total") &&
        !item.name.toLowerCase().includes("harddisk")
    );

    setFilteredAvgDiskData(filteredData);
  }, [AvgDiskBytesData]);

  return (
    <div className={classes.diskWidget}>
      <FreeSpaceLineDiagram />
      <div className={classes.diagramGroupContainer}>
        {filteredAvgBytesData.map((dataItem: any) => {
          return (
            <DiskPerformanceDiagram
              key={dataItem.name}
              diskData={dataItem}
              diskDataUnit="kB"
              dataDivider={1024}
              datasetsToPlot={[
                "avgDiskBytesPerRead",
                "avgDiskBytesPerTransfer",
                "avgDiskBytesPerWrite",
              ]}
              datasetsLabels={[`kB/read`, `kB/transfer`, `kB/write`]}
              diagramTitle={`Disk ${dataItem.name.replace(
                ":",
                ""
              )} average size of operations
              in kB`}
            />
          );
        })}
      </div>

      <div className={classes.diagramGroupContainer}>
        {filteredAvgBytesData.map((dataItem: any) => {
          return (
            <DiskPerformanceDiagram
              key={dataItem.name}
              diskData={dataItem}
              diskDataUnit="No"
              dataDivider={1}
              datasetsToPlot={[
                "avgDiskQueueLength",
                "avgDiskReadQueueLength",
                "avgDiskWriteQueueLength",
              ]}
              datasetsLabels={[
                `Queue Length`,
                `Read Queue Length`,
                `Write Queue Length`,
              ]}
              diagramTitle={`Disk ${dataItem.name.replace(
                ":",
                ""
              )} average queues length`}
            />
          );
        })}
      </div>
      <div className={classes.diagramGroupContainer}>
        {filteredAvgBytesData.map((dataItem: any) => {
          return (
            <DiskPerformanceDiagram
              key={dataItem.name}
              diskData={dataItem}
              diskDataUnit="s"
              dataDivider={1}
              datasetsToPlot={["currentDiskQueueLength"]}
              datasetsLabels={[`Queue Length`]}
              diagramTitle={`Disk ${dataItem.name.replace(
                ":",
                ""
              )} current queue length`}
            />
          );
        })}
      </div>
      <div className={classes.diagramGroupContainer}>
        {filteredAvgBytesData.map((dataItem: any) => {
          return (
            <DiskPerformanceDiagram
              key={dataItem.name}
              diskData={dataItem}
              diskDataUnit="s"
              dataDivider={1}
              datasetsToPlot={[
                "avgDisksecPerRead",
                "avgDisksecPerTransfer",
                "avgDisksecPerWrite",
              ]}
              datasetsLabels={[`sec/read`, `sec/transfer`, `sec/write`]}
              diagramTitle={`Disk ${dataItem.name.replace(
                ":",
                ""
              )} average time in seconds of operation`}
            />
          );
        })}
      </div>
      <div className={classes.diagramGroupContainer}>
        {filteredAvgBytesData.map((dataItem: any) => {
          return (
            <DiskPerformanceDiagram
              key={dataItem.name}
              diskData={dataItem}
              diskDataUnit="s"
              dataDivider={1024}
              datasetsToPlot={[
                "diskBytesPersec",
                "diskReadBytesPersec",
                "diskWriteBytesPersec",
              ]}
              datasetsLabels={[
                `kB/sec transfer`,
                `kB/sec read`,
                `kB/sec write`,
              ]}
              diagramTitle={`Disk ${dataItem.name.replace(
                ":",
                ""
              )} kB transferred in sec`}
            />
          );
        })}
      </div>
      <div className={classes.diagramGroupContainer}>
        {filteredAvgBytesData.map((dataItem: any) => {
          return (
            <DiskPerformanceDiagram
              key={dataItem.name}
              diskData={dataItem}
              diskDataUnit="s"
              dataDivider={1024}
              datasetsToPlot={[
                "diskReadsPersec",
                "diskTransfersPersec",
                "diskWritesPersec",
              ]}
              datasetsLabels={[`reads/sec`, `transfer/sec`, `write/sec`]}
              diagramTitle={`Disk ${dataItem.name.replace(
                ":",
                ""
              )} number of operations per sec`}
            />
          );
        })}
      </div>
    </div>
  );
};

export default DiskDetailsLineDiagram;
