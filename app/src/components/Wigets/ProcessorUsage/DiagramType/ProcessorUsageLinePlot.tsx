import React, { useEffect, useState } from "react";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { Line } from "react-chartjs-2";
import classes from "./ProcessorUsageLinePlot.module.css";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const ProcessorUsageLinePlot: React.FC<{
  plotData: any;
  seriesLabel: string;
}> = (props) => {
  const labels = [new Date().toLocaleString()];

  const data: any = {
    labels,
    datasets: [],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: {
        position: "top" as const,
      },
      title: {
        display: false,
        text: "Chart.js Line Chart",
      },
    },
    scales: {
      y: {
        suggestedMin: 0,
        suggestedMax: 100,
      },
    },
  };

  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [labelData, setLabelData] = useState<string[]>([]);
  const [dataState, setDataState] = useState<any>(data);
  const [datasets, setDatasets] = useState<any[]>([]);

  useEffect(() => {
    setLabelData((prevValue: any) => {
      const labelArray = prevValue;
      if (labelArray.length > 5) {
        labelArray.shift();
      }
      return labelArray.concat(new Date().toLocaleTimeString());
    });

    props.plotData.forEach((item: any) => {
      for (const [dataKey, dataValue] of Object.entries(item.data)) {
        const redColorAmount = Math.random() * 255;
        const greenColorAmount = Math.random() * 255;
        const blueColorAmount = Math.random() * 255;

        let dataSetLabel = props.seriesLabel;

        if (dataSetLabel.includes("#")) {
          const variableId = dataKey.match(/(\d+)/);
          const id = variableId ? variableId[0] : "";
          dataSetLabel = dataSetLabel.replace("#", id);
        }

        const dataSetIndex: number = datasets.findIndex((dataSetItem: any) => {
          return dataSetItem.label === dataSetLabel;
        });

        if (dataSetIndex < 0) {
          data.datasets.push({
            label: dataSetLabel,
            data: [dataValue],
            borderColor: `rgb(${redColorAmount}, ${greenColorAmount}, ${blueColorAmount})`,
            backgroundColor: `rgba(${redColorAmount}, ${greenColorAmount}, ${blueColorAmount}, 0.5)`,
          });
          setDatasets(data.datasets.concat([]));
        } else {
          const previousData = datasets[dataSetIndex].data;

          if (previousData.length > 5) {
            previousData.shift();
          }

          previousData.push(dataValue);
          const newData: any = datasets;
          newData[dataSetIndex].data = previousData;

          setDatasets(newData.concat([]));
        }
      }
    });
  }, [props.plotData]);
  useEffect(() => {
    data.datasets = datasets;
    data.labels = labelData;
    setDataState(data);
    setIsLoading(false);
  }, [datasets]);

  return (
    <div className={classes.singleCorePlotContainer}>
      <Line data={dataState} options={options} />
    </div>
  );
};

export default ProcessorUsageLinePlot;
