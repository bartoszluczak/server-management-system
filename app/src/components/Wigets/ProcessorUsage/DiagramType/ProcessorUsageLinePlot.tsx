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

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const ProcessorUsageLinePlot: React.FC<{ plotData: any }> = (props) => {
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

  const [dataState, setDataState] = useState<any>(data);

  useEffect(() => {
    props.plotData.forEach((item: any) => {
      console.log(item);
    });
  }, [props.plotData]);
  return <p>Plot</p>;
};

export default ProcessorUsageLinePlot;
