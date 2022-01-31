import React, { useState } from "react";
import classes from "./SmallSwitch.module.css";

const SmallSwitch: React.FC<any> = (props) => {
  const [switchState, setSwitchState] = useState(props.initialState);

  const switchStateHandler = () => {
    props.onSwitch({
      switchState: !switchState,
      total: props.switchTotal,
      setStatusFunction: props.setStatusFunction,
    });
    setSwitchState((prevState: any) => !prevState);
  };
  return (
    <div
      className={`${classes.switchContainer} ${
        switchState ? classes.switchContainerActive : ""
      }`}
      onClick={switchStateHandler}
    >
      <div
        className={`${classes.currentState} ${switchState ? classes.left : ""}`}
      />
      <h3 className={classes.icon}>{props.leftText}</h3>
      <h3 className={classes.icon}>{props.rightText}</h3>
    </div>
  );
};

export default SmallSwitch;
