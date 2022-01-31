import React, { useEffect, useState } from "react";
import classes from "./DiskDetailsLineDiagram.module.css";
import FreeSpaceLineDiagram from "./DiagramTypes/FreeSpaceLineDiagram";
import DiskPerformanceDiagram from "./DiagramTypes/DiskPerformanceDiagram";
import axios from "axios";
import { AvgDiskBytesDetails } from "../../../models/diskDetails";
import SmallSwitch from "../../UI/SmallSwitch";

const DiskDetailsLineDiagram: React.FC = () => {
  const [AvgDiskBytesData, setAvgDiskBytesData] = useState<any>([]);
  const [filteredAvgBytesData, setFilteredAvgDiskData] = useState<any>([]);

  const [diskTransfersPersec, setDiskTransfersPersec] = useState<boolean>(true);
  const [diskOperationsPersec, setDiskOperationsPersecc] =
    useState<boolean>(true);
  const [averageOperationsTime, setAverageOperationsTime] = useState<any>(true);
  const [diskQueryLength, setDisksQueryLength] = useState<any>(true);
  const [diskAvgQueueLength, setDiskAvgQueueLength] = useState<any>(true);
  const [averageSizeOperations, setAverageSizeOperations] = useState<any>(true);
  const [freeSpace, setFreeSpace] = useState<any>(true);

  const getData: any = async (
    urlAddress: string,
    refreshRate: number,
    setDataFunction: Function
  ) => {
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

  const switchStateHandler = (switchState: any) => {
    switchState.setStatusFunction(switchState.switchState);
  };

  return (
    <div className={classes.diskWidget}>
      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>Disks free space diagram</h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setFreeSpace}
            leftText=""
            rightText=""
          />
        </div>
        {freeSpace && <FreeSpaceLineDiagram />}
      </div>

      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>Disks average queues length</h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setAverageSizeOperations}
            leftText=""
            rightText=""
          />
        </div>

        {averageSizeOperations && (
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
        )}
      </div>

      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>Disks average queues length</h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setDiskAvgQueueLength}
            leftText=""
            rightText=""
          />
        </div>
        {diskAvgQueueLength && (
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
        )}
      </div>

      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>Disks current queues length</h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setDisksQueryLength}
            leftText=""
            rightText=""
          />
        </div>

        {diskQueryLength && (
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
        )}
      </div>
      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>Average disks operations time</h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setAverageOperationsTime}
            leftText=""
            rightText=""
          />
        </div>

        {averageOperationsTime && (
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
        )}
      </div>
      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>Disks transfers in second</h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setDiskTransfersPersec}
            leftText=""
            rightText=""
          />
        </div>

        {diskTransfersPersec && (
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
        )}
      </div>
      <div className={classes.plotOuterDiagramContainer}>
        <div className={classes.plotHeaderContainer}>
          <h2 className={classes.label}>
            Disks numbers of operations in second
          </h2>
          <SmallSwitch
            onSwitch={switchStateHandler}
            initialState={true}
            switchTotal={true}
            setStatusFunction={setDiskOperationsPersecc}
            leftText=""
            rightText=""
          />
        </div>

        {diskOperationsPersec && (
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
        )}
      </div>
    </div>
  );
};

export default DiskDetailsLineDiagram;
