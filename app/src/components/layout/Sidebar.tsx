import React from "react";
import classes from './Sidebar.module.css'

const Sidebar: React.FC = () => {
    return (
        <div className={classes.sidebar}>
           <div className={classes.sidebarHeader}>
               <h3>Menu</h3>
           </div>
        </div>

    )
}

export default Sidebar