import React from "react";
import classes from "./Switch.module.css";
import { useDispatch } from "react-redux";
import { useTypedSelector } from "../../store";
import { changeDiskDiagramType } from "../../models/storeActions";

const Switch: React.FC<any> = (props) => {
  const dispatch = useDispatch();
  const currentDiskDiagramType = useTypedSelector(
    (state) => state.diskDiagramState
  );

  const switchStateHandler = () => {
    dispatch(
      changeDiskDiagramType(
        currentDiskDiagramType === "dough" ? "line" : "dough"
      )
    );
  };

  const activeClass = currentDiskDiagramType === "line" ? classes.left : "";

  return (
    <div className={classes.switchContainer} onClick={switchStateHandler}>
      <div className={`${classes.currentState} ${activeClass}`} />
      <div className={classes.icon}>{props.leftIcon}</div>
      <span className={classes.icon}>{props.rightIcon}</span>
    </div>
  );
};

export default Switch;
