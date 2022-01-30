import WidgetContainer from "../../UI/WidgetContainer";
import classes from "./ProcessorUsage.module.css";
import React, { useEffect, useState } from "react";
import ProcessorUsageDiagramsGroup from "./ProcessorUsageDiagramsGroup";
import axios from "axios";

const ProcessorUsage: React.FC = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [processorData, setProcessorData] = useState([]);

  const [percentProcessorTime, setPercentProcessorTime] = useState<any[]>([]);

  const getData = () => {
    axios.get("/systemPerformance/processor").then((res) => {
      setProcessorData(res.data);
    });
  };

  useEffect(() => {
    const interval = setInterval(() => {
      getData();
    }, 5000);

    return () => {
      clearInterval(interval);
    };
  });

  useEffect(() => {
    const percentProcessorTimeArr: any[] = [];
    processorData.forEach((dataItem: any) => {
      percentProcessorTimeArr.push({
        name: dataItem.name,
        data: { percentProcessorTime: dataItem.percentProcessorTime },
      });
      setPercentProcessorTime(percentProcessorTimeArr);
    });
  }, [processorData]);

  return (
    <WidgetContainer>
      <div className={classes.widgetHeader}>
        <h3>Processor Usage</h3>
      </div>
      <div className={classes.processorWidget}>
        <ProcessorUsageDiagramsGroup
          diagramsData={percentProcessorTime}
          totalDataPlotTitle="Total percent processor time usage"
          singleCoreDataPlotTitle="Single core percent time usage"
        />
      </div>
    </WidgetContainer>
  );
};

export default ProcessorUsage;
