import { Action, ActionType } from "./storeTypes";
import { Dispatch } from "react";

export const changeDiskDiagramType = (type: string) => {
  return (dispatch: Dispatch<Action>) => {
    dispatch({
      type: ActionType.SWITCH_DISK_DIAGRAM,
      payload: type,
    });
  };
};
