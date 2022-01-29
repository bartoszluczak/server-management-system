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
import classes from "./DiskPerformanceDiagram.module.css";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const DiskPerformanceDiagram: React.FC<{
  diskData: any;
  dataDivider: number;
  diskDataUnit: string;
  datasetsToPlot: string[];
  datasetsLabels: string[];
  diagramTitle: string;
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
  };

  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [labelData, setLabelData] = useState<string[]>([]);
  const [datasets, setDatasets] = useState<any[]>([]);
  const [dataState, setDataState] = useState<any>(data);

  useEffect(() => {
    const dataToPlotArr = props.datasetsToPlot;

    dataToPlotArr.forEach((item: any) => {
      const redColorAmount = Math.random() * 255;
      const greenColorAmount = Math.random() * 255;
      const blueColorAmount = Math.random() * 255;

      const dataSetsLabel =
        props.datasetsLabels[dataToPlotArr.findIndex((elem) => elem === item)];

      const dataSetIndex: number = datasets.findIndex((dataSetItem: any) => {
        return dataSetItem.label === dataSetsLabel;
      });

      if (dataSetIndex < 0) {
        data.datasets.push({
          label: dataSetsLabel,
          data: [props.diskData[item] / props.dataDivider],
          borderColor: `rgb(${redColorAmount}, ${greenColorAmount}, ${blueColorAmount})`,
          backgroundColor: `rgba(${redColorAmount}, ${greenColorAmount}, ${blueColorAmount}, 0.5)`,
        });
        data.datasets = data.datasets.filter((item: any) => item.label !== "");
        setDatasets(data.datasets.concat([]));
      } else {
        data.datasets = data.datasets.filter((item: any) => item.label !== "");
        const previousData = datasets[dataSetIndex].data;

        if (previousData.length > 5) {
          previousData.shift();
        }

        previousData.push(props.diskData[item] / props.dataDivider);
        const newData: any = datasets;
        newData[dataSetIndex].data = previousData;

        setDatasets(newData.concat([]));
      }
    });

    setLabelData((prevValue) => {
      const labelArray = prevValue;
      if (labelArray.length > 5) {
        labelArray.shift();
      }
      return labelArray.concat(new Date().toLocaleTimeString());
    });
  }, [props.diskData]);

  useEffect(() => {
    data.datasets = datasets;
    data.labels = labelData;
    setDataState(data);
    setIsLoading(false);
  }, [datasets]);

  return (
    <div className={classes.diagramContainer}>
      <h2 className={classes.label}>{props.diagramTitle}</h2>
      {isLoading && <p>Loading</p>}
      {!isLoading && <Line options={options} data={dataState} />}
    </div>
  );
};

export default DiskPerformanceDiagram;
