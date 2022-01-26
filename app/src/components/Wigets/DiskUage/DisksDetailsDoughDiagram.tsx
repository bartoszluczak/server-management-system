import React from "react";
import diskDetails from "../../../models/diskDetails";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Doughnut } from "react-chartjs-2";
import options from "./chartOptions";
import classes from "./DiskDetailsItem.module.css";

ChartJS.register(ArcElement, Tooltip, Legend);

const DisksDetailsDoughDiagram: React.FC<{ diskData: diskDetails }> = (
  props
) => {
  const data = {
    labels: ["Used", "Free"],
    options: {
      tooltips: {
        enabled: false,
        backgroundColor: "red",
      },
    },
    datasets: [
      {
        data: [0, 0],
        backgroundColor: ["rgba(54,127,172,0.5)", "rgba(167,170,173,0.15)"],
        borderWidth: 0,
      },
    ],
  };

  data.datasets[0].data = [
    Math.floor((props.diskData.diskUsedSpace / props.diskData.diskSize) * 100),
    Math.floor((props.diskData.diskFreeSpace / props.diskData.diskSize) * 100),
  ];

  return (
    <div className={classes.diskWidget}>
      <h2 className={classes.label}>
        Drive label: <span>{props.diskData.driveName.slice(0, -1)}</span>
        <span className={classes.legendLine}>
          <span>
            <div
              className={`${classes.colorContainer} ${classes.freeSpaceContainer}`}
            />
            Free space
          </span>
          <span>{props.diskData.diskFreeSpace} GB</span>
        </span>
        <span className={classes.legendLine}>
          <span>
            <div
              className={`${classes.colorContainer} ${classes.occupiedSpaceContainer}`}
            />
            Occupied space
          </span>
          <span>{props.diskData.diskUsedSpace} GB</span>
        </span>
      </h2>
      <Doughnut options={options} data={data} />
    </div>
  );
};

export default DisksDetailsDoughDiagram;
