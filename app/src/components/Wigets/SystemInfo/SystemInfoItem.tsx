import React, { useEffect, useState } from "react";
import classes from "./SystemInfoItem.module.css";

const SystemInfoItem: React.FC<{
  systemDetailsData: any;
  systemDataFields: any;
}> = (props) => {
  const [data, setData] = useState([]);
  const listOfItems: any = [];
  const filterdData: any = {};

  useEffect(() => {
    setData(props.systemDetailsData);
  }, [props]);

  if (data.length > 0) {
    data.forEach((item: any) => {
      for (const [key, value] of Object.entries(item)) {
        filterdData[key] = value;
      }

      for (const [key, value] of Object.entries(filterdData)) {
        if (value && key) {
          const label = key.match(/([A-Z]?[^A-Z]*)/g) || [""];

          const array = new Uint32Array(2);
          const keyId = crypto.getRandomValues(array);

          listOfItems.push(
            <li key={key + "_" + keyId}>
              <span className={classes.key}>
                {`${label.slice(0, -1).join(" ").toLowerCase()}: `}
              </span>
              {value}
            </li>
          );
        }
      }
      if (data.length > 1) {
        const array = new Uint32Array(2);
        const keyId = crypto.getRandomValues(array);
        listOfItems.push(
          <div key={keyId.join("")} className={classes.divider} />
        );
      }
    });
  }

  return (
    <div>
      <ul>{data.length > 0 ? listOfItems : "Loading"}</ul>
    </div>
  );
};

export default SystemInfoItem;
