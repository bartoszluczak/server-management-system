import React, { Fragment, useEffect, useState } from "react";
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
import axios from "axios";
import { DiskDetails } from "../../../../models/diskDetails";
import classes from "./FreeSpaceLineDiagram.module.css";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const labels = [new Date().toLocaleString()];

const data = {
  labels,
  datasets: [
    {
      label: "C",
      data: [0],
      borderColor: "rgb(255, 99, 132)",
      backgroundColor: "rgba(255, 99, 132, 0.5)",
    },
  ],
};

const FreeSpaceLineDiagram: React.FC = () => {
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [labelData, setLabelData] = useState<string[]>([]);
  const [plotData2, setPlotData2] = useState<any>(null);
  const [datasets, setDatasets] = useState<any[]>([]);

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
      tooltip: {
        callbacks: {
          label: function (context: any) {
            const diskDetails = plotData2.find(
              (item: DiskDetails) =>
                context.dataset.label === item.driveName.replace(":", "")
            );
            let label = context.dataset.label || "0";

            if (label) {
              label = `${context.dataset.label}: ${context.parsed.y} GB of ${diskDetails.diskSize} GB`;
            }
            return label;
          },
          afterLabel: function (context: any) {
            const diskDetails = plotData2.find(
              (item: DiskDetails) =>
                context.dataset.label === item.driveName.replace(":", "")
            );
            return `(Free space ${(
              (context.parsed.y / diskDetails.diskSize) *
              100
            ).toFixed(2)}%)`;
          },
        },
      },
    },
  };

  const getData = async () => {
    await axios
      .get<DiskDetails[]>("http://localhost:59422/api/systemdetails/storage")
      .then((res) => {
        setPlotData2(res.data);
        setLabelData((prevValue) => {
          const labelArray = prevValue;
          if (labelArray.length > 5) {
            labelArray.shift();
          }

          return labelArray.concat(new Date().toLocaleTimeString());
        });
      });
  };

  useEffect(() => {
    const inter = setInterval(() => {
      getData();
    }, 5000);

    return () => {
      clearInterval(inter);
    };
  }, []);

  useEffect(() => {
    data.datasets = datasets;
    data.labels = labelData;
    setIsLoading(false);
  }, [labelData, datasets]);

  useEffect(() => {
    plotData2?.forEach((diskData: DiskDetails) => {
      const diskItemIndex: number = datasets.findIndex(
        (dataSetItem) =>
          dataSetItem.label.replace(":", "") ===
          diskData.driveName.replace(":", "")
      );

      if (diskItemIndex < 0) {
        const redColorAmount = Math.random() * 255;
        const greenColorAmount = Math.random() * 255;
        const blueColorAmount = Math.random() * 255;
        setDatasets((prevValue) => [
          ...prevValue,
          {
            label: diskData.driveName.replace(":", ""),
            data: [0],
            borderColor: `rgb(${redColorAmount}, ${greenColorAmount}, ${blueColorAmount})`,
            backgroundColor: `rgba(${redColorAmount}, ${greenColorAmount}, ${blueColorAmount}, 0.5)`,
          },
        ]);
      } else {
        const datasetData: number[] = datasets[diskItemIndex].data;
        if (datasetData.length > 5) {
          datasetData.shift();
        }
        datasetData.push(diskData.diskFreeSpace);
        setDatasets((prevValue: any[]) => {
          const modDatasets = prevValue;
          modDatasets[diskItemIndex].data = datasetData;
          return modDatasets.concat([]);
        });
      }
    });
  }, [plotData2]);

  return (
    <Fragment>
      {isLoading && <p>Loading</p>}
      {!isLoading && <Line options={options} data={data} />}
    </Fragment>
  );
};

export default FreeSpaceLineDiagram;
