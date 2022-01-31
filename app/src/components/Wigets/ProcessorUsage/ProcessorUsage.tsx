import WidgetContainer from "../../UI/WidgetContainer";
import classes from "./ProcessorUsage.module.css";
import React, { useEffect, useState } from "react";
import ProcessorUsageDiagramsGroup from "./ProcessorUsageDiagramsGroup";
import axios from "axios";

const ProcessorUsage: React.FC = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [processorData, setProcessorData] = useState([]);

  const [percentProcessorTime, setPercentProcessorTime] = useState<any[]>([]);
  const [cTransitionsPersec, setCTransitionsPersec] = useState<any[]>([]);
  const [dpcRate, setDpcRate] = useState<any[]>([]);
  const [dpCsQueuedPersec, setDpCsQueuedPersec] = useState<any[]>([]);
  const [interruptsPersec, setInterruptsPersec] = useState<any[]>([]);
  const [percentCTime, setPercentCTime] = useState<any[]>([]);

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

    const cTransitionsPersecArr: any[] = [];
    processorData.forEach((dataItem: any) => {
      cTransitionsPersecArr.push({
        name: dataItem.name,
        data: {
          c1TransitionsPersec: dataItem.c1TransitionsPersec,
          c2TransitionsPersec: dataItem.c2TransitionsPersec,
          c3TransitionsPersec: dataItem.c3TransitionsPersec,
        },
      });
      setCTransitionsPersec(cTransitionsPersecArr);
    });

    const dpcRateArr: any[] = [];
    processorData.forEach((dataItem: any) => {
      dpcRateArr.push({
        name: dataItem.name,
        data: {
          dpcRate: dataItem.dpcRate,
        },
      });
      setDpcRate(dpcRateArr);
    });

    const dpCsQueuedPersecArr: any[] = [];
    processorData.forEach((dataItem: any) => {
      dpCsQueuedPersecArr.push({
        name: dataItem.name,
        data: {
          dpCsQueuedPersec: dataItem.dpCsQueuedPersec,
        },
      });
      setDpCsQueuedPersec(dpCsQueuedPersecArr);
    });

    const interruptsPersecArr: any[] = [];
    processorData.forEach((dataItem: any) => {
      interruptsPersecArr.push({
        name: dataItem.name,
        data: {
          interruptsPersec: dataItem.interruptsPersec,
        },
      });
      setInterruptsPersec(interruptsPersecArr);
    });

    const percentCTimeArr: any[] = [];
    processorData.forEach((dataItem: any) => {
      percentCTimeArr.push({
        name: dataItem.name,
        data: {
          percentC1Time: dataItem.percentC1Time,
          percentC2Time: dataItem.percentC2Time,
          percentC3Time: dataItem.percentC3Time,
        },
      });
      setPercentCTime(percentCTimeArr);
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
          totalDataPlotTitle="Total % processor time usage"
          singleCoreDataPlotTitle="Single core % time usage"
          seriesLabelTotal="% Processor usage"
          singleCoreLabel="% Core usage for Core"
        />
      </div>
      <div className={classes.processorWidget}>
        <ProcessorUsageDiagramsGroup
          diagramsData={cTransitionsPersec}
          totalDataPlotTitle="Total C Transitions/sec"
          singleCoreDataPlotTitle="Single core C Transitions/sec"
          seriesLabelTotal="Processor C# Transitions/sec"
          singleCoreLabel="C# Transitions/sec for Core"
        />
      </div>
      <div className={classes.processorWidget}>
        <ProcessorUsageDiagramsGroup
          diagramsData={dpcRate}
          totalDataPlotTitle="Total DPC Rate"
          singleCoreDataPlotTitle="Single core DPC Rate"
          seriesLabelTotal="Processor DPC Rate"
          singleCoreLabel="DPC Rate for Core"
        />
      </div>
      <div className={classes.processorWidget}>
        <ProcessorUsageDiagramsGroup
          diagramsData={dpCsQueuedPersec}
          totalDataPlotTitle="Total DPC Queued/sec"
          singleCoreDataPlotTitle="Single core DPC Queued/sec"
          seriesLabelTotal="Processor DPC Queued/sec"
          singleCoreLabel="DPC Queued/sec for Core"
        />
      </div>
      <div className={classes.processorWidget}>
        <ProcessorUsageDiagramsGroup
          diagramsData={interruptsPersec}
          totalDataPlotTitle="Total interrupts/sec"
          singleCoreDataPlotTitle="Single core interrupts/sec"
          seriesLabelTotal="Processor interrupts/sec"
          singleCoreLabel="Interrupts/sec for Core"
        />
      </div>
      <div className={classes.processorWidget}>
        <ProcessorUsageDiagramsGroup
          diagramsData={percentCTime}
          totalDataPlotTitle="Total % C Time"
          singleCoreDataPlotTitle="Single core % C Time"
          seriesLabelTotal="Processor % C# Time"
          singleCoreLabel="% C# Time for Core"
        />
      </div>
    </WidgetContainer>
  );
};

export default ProcessorUsage;
