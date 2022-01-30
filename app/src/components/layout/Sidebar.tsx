import React, { useState } from "react";
import classes from "./Sidebar.module.css";
import { BsMenuButtonWide } from "react-icons/bs";
import { IoCloseSharp } from "react-icons/io5";

const Sidebar: React.FC = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleMenu = () => {
    setIsMenuOpen((prevValue) => {
      return !prevValue;
    });
  };

  return (
    <div
      className={`${classes.sidebar} ${
        !isMenuOpen ? classes.sidebarNarrow : ""
      }`}
    >
      <div className={classes.sidebarHeader}>
        {isMenuOpen && <h3>Menu</h3>}
        <div className={classes.menuIcon} onClick={toggleMenu}>
          {!isMenuOpen && <BsMenuButtonWide />}
          {isMenuOpen && <IoCloseSharp />}
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
