import React, { useEffect, useState } from "react";
import classes from "./DiskDetailsLineDiagram.module.css";
import FreeSpaceLineDiagram from "./DiagramTypes/FreeSpaceLineDiagram";
import AvgDiskBytesDiagram from "./DiagramTypes/AvgDiskBytesDiagram";
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
      {filteredAvgBytesData.map((dataItem: any) => {
        return (
          <AvgDiskBytesDiagram
            key={dataItem.name}
            avgDiskBytesData={dataItem}
            dataDivider={1024}
          />
        );
      })}
    </div>
  );
};

export default DiskDetailsLineDiagram;
