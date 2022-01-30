import React, { useEffect, useState } from "react";
import classes from "./ProcessorUsageDiagramsGroup.module.css";
import ProcessorUsageLinePlot from "./DiagramType/ProcessorUsageLinePlot";

const ProcessorUsageDiagramsGroup: React.FC<{
  diagramsData: any;
  totalDataPlotTitle: string;
  singleCoreDataPlotTitle: string;
}> = (props) => {
  const [plotData, setPlotData] = useState<any[]>([]);
  const [totalPlotData, setTotalPlotData] = useState<any[]>([]);
  const [singleCorePlotData, setSingleCorePlotData] = useState<any[]>([]);

  useEffect(() => {
    setPlotData((prevValue: any) => {
      return [...prevValue, ...props.diagramsData];
    });
  }, [props.diagramsData]);

  useEffect(() => {
    const filterdTotalData: any[] = plotData.filter(
      (dataItem) => dataItem.name === "_Total"
    );
    setTotalPlotData(filterdTotalData);

    const filterdSingleCoreData: any[] = plotData.filter(
      (dataItem) => dataItem.name !== "_Total"
    );
    setSingleCorePlotData(filterdSingleCoreData);
  }, [plotData]);

  return (
    <div>
      <h2 className={classes.label}>{props.totalDataPlotTitle}</h2>
      <div>
        <ProcessorUsageLinePlot plotData={totalPlotData} />
      </div>
      <h2 className={classes.label}>{props.singleCoreDataPlotTitle}</h2>
      <div>
        <p>Plot 2</p>
      </div>
    </div>
  );
};

export default ProcessorUsageDiagramsGroup;
