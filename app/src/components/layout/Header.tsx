import React from "react";
import classes from './Header.module.css'

const Header: React.FC = () => {
    return (
        <div className={classes.header}>
            <h1>Servers Management System</h1>
        </div>

    )
}

export default Header;