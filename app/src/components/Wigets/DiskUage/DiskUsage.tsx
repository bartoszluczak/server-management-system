import React, { useEffect, useState } from "react";
import classes from "./DiskUsage.module.css";
import WidgetContainer from "../../UI/WidgetContainer";

import axios from "axios";
import { DiskDetails } from "../../../models/diskDetails";
import DisksDetailsDoughDiagram from "./DisksDetailsDoughDiagram";
import Switch from "../../UI/Switch";
import { FcDoughnutChart, FcLineChart } from "react-icons/fc";
import { useTypedSelector } from "../../../store";
import DiskDetailsLineDiagram from "./DiskDetailsLineDiagram";

const DiskUsage: React.FC = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [installedDisksList, setInstalledDisksList] = useState<DiskDetails[]>(
    []
  );

  const currentDiskDiagramType = useTypedSelector(
    (state) => state.diskDiagramState
  );

  useEffect(() => {
    axios.get<DiskDetails[]>("/systemdetails/storage").then((res) => {
      const tempArray: DiskDetails[] = [];
      res.data.map((diskData) => tempArray.push(diskData));
      setInstalledDisksList(tempArray);
      setIsLoading(false);
    });
  }, []);

  return (
    <WidgetContainer>
      <div className={classes.widgetHeader}>
        <h3>Disk Usage</h3>
        <Switch leftIcon={<FcDoughnutChart />} rightIcon={<FcLineChart />} />
      </div>
      {isLoading && "Loading"}
      {!isLoading &&
        currentDiskDiagramType === "dough" &&
        installedDisksList.map((disk) => (
          <DisksDetailsDoughDiagram key={disk.driveName} diskData={disk} />
        ))}
      {!isLoading && currentDiskDiagramType === "line" && (
        <DiskDetailsLineDiagram />
      )}
    </WidgetContainer>
  );
};

export default DiskUsage;
