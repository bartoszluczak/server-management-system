import React, { useEffect, useState } from "react";
import classes from "./ProcessorUsageDiagramsGroup.module.css";
import ProcessorUsageLinePlot from "./DiagramType/ProcessorUsageLinePlot";
import SmallSwitch from "../../UI/SmallSwitch";

const ProcessorUsageDiagramsGroup: React.FC<{
  diagramsData: any;
  totalDataPlotTitle: string;
  singleCoreDataPlotTitle: string;
  seriesLabelTotal: string;
  singleCoreLabel: string;
}> = (props) => {
  const [plotData, setPlotData] = useState<any[]>([]);
  const [totalPlotData, setTotalPlotData] = useState<any[]>([]);
  const [singleCorePlotData, setSingleCorePlotData] = useState<any[]>([]);
  const [numberOfCores, setNumberOfCores] = useState<number>(0);
  const [displayTotalPlot, setDisplayTotalPlot] = useState(true);
  const [displaySinglesPlot, setDisplaySinglesPlot] = useState(true);

  useEffect(() => {
    setPlotData((prevValue: any) => {
      setNumberOfCores(props.diagramsData.length - 1);
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

  const plotsArray: any = [];

  for (let i = 0; i < numberOfCores; i++) {
    const data = singleCorePlotData.filter(
      (dataItem: any) => dataItem.name === i.toString()
    );
    plotsArray.push(
      <ProcessorUsageLinePlot
        key={props.singleCoreLabel + i}
        plotData={data}
        seriesLabel={`${props.singleCoreLabel} ${i}`}
      />
    );
  }

  const switchStateHandler = (switchState: any) => {
    if (switchState.total) {
      switchState.setStatusFunction(switchState.switchState);
      // setDisplayTotalPlot(switchState.switchState);
      setTotalPlotData([]);
      setPlotData([]);
    } else {
      switchState.setStatusFunction(switchState.switchState);
      // setDisplaySinglesPlot(switchState.switchState);
      setSingleCorePlotData([]);
      setPlotData([]);
    }
  };

  return (
    <div>
      <div className={classes.plotHeaderContainer}>
        <h2 className={classes.label}>{props.totalDataPlotTitle}</h2>
        <SmallSwitch
          onSwitch={switchStateHandler}
          initialState={true}
          switchTotal={true}
          setStatusFunction={setDisplayTotalPlot}
          leftText=""
          rightText=""
        />
      </div>

      {displayTotalPlot && (
        <div className={classes.diagramContainer}>
          <ProcessorUsageLinePlot
            plotData={totalPlotData}
            seriesLabel={props.seriesLabelTotal}
          />
        </div>
      )}
      <div className={classes.plotHeaderContainer}>
        <h2 className={classes.label}>{props.singleCoreDataPlotTitle}</h2>
        <SmallSwitch
          onSwitch={switchStateHandler}
          initialState={true}
          switchTotal={false}
          setStatusFunction={setDisplaySinglesPlot}
          leftText=""
          rightText=""
        />
      </div>

      {displaySinglesPlot && (
        <div className={classes.plotsGrid}>{plotsArray}</div>
      )}
    </div>
  );
};

export default ProcessorUsageDiagramsGroup;
