import React from "react";
import classes from "./Main.module.css";
import CurrentTime from "../Wigets/CurrentTime";
import DiskUsage from "../Wigets/DiskUage/DiskUsage";

const Main: React.FC = () => {
  return (
    <div className={classes.main}>
      <div className={classes.mainHeader}>
        <h1>Dashboard</h1>
      </div>
      <div className={classes.widgetsContainer}>
        <CurrentTime />
        <DiskUsage />
      </div>
    </div>
  );
};

export default Main;
