interface ChangeDiskDiagAction {
  type: string;
  diagState: string;
}

export default ChangeDiskDiagAction;

export enum ActionType {
  SWITCH_DISK_DIAGRAM = "SWITCH_DISK_DIAGRAM",
}

interface changeDiskDiagAction {
  type: ActionType.SWITCH_DISK_DIAGRAM;
  payload: string;
}
export type Action = changeDiskDiagAction;
