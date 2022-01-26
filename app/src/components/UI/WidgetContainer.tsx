import classes from "./WidgetContainer.module.css";
import React from "react";

const WidgetContainer:React.FC = (props) => {
    return (
        <div className={classes.container}>
            {props.children}
        </div>
    )
}
export default WidgetContainer;