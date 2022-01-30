import React from "react";
import classes from "./Main.module.css";
import CurrentTime from "../Wigets/CurrentTime";
import DiskUsage from "../Wigets/DiskUage/DiskUsage";
import SystemInfo from "../Wigets/SystemInfo/SystemInfo";
import ProcessorUsage from "../Wigets/ProcessorUsage/ProcessorUsage";

const Main: React.FC = () => {
  return (
    <div className={classes.main}>
      <div className={classes.mainHeader}>
        <h1>Dashboard</h1>
      </div>
      <div className={classes.widgetsContainer}>
        <CurrentTime />
        <DiskUsage />
        <ProcessorUsage />
        <SystemInfo />
      </div>
    </div>
  );
};

export default Main;
