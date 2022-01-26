import { configureStore } from "@reduxjs/toolkit";
import StoreState from "../models/storeState";
import { Action } from "../models/storeTypes";
import { useSelector, TypedUseSelectorHook } from "react-redux";

const initialState: StoreState = {
  diskDiagramState: "dough",
};

const reducer = (
  state: StoreState = initialState,
  action: Action
): StoreState => {
  if (action.type === "SWITCH_DISK_DIAGRAM") {
    return {
      diskDiagramState: action.payload,
    };
  }
  return state;
};

const store = configureStore({
  reducer: reducer,
});

export default store;

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;

export const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector;
