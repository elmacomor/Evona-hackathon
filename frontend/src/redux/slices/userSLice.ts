import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";
import type { RootState } from "../store";
import { stat } from "fs";

// Define a type for the slice state
interface User {
  isLoggedIn: boolean;
  id: string;
  name: string;
  surname: string;
  email: string;
  username: string;
  //user login info
}

// Define the initial state using that type
const initialState: User = {
  isLoggedIn: false,
  id: "",
  name: "",
  surname: "",
  email: "",
  username: "",
};

export const userSlice = createSlice({
  name: "counter",
  // `createSlice` will infer the state type from the `initialState` argument
  initialState,
  reducers: {
    // Use the PayloadAction type to declare the contents of `action.payload`
    LogInUser: (
      state,
      action: PayloadAction<{
        isLoggedIn: boolean;
        id: string;
        name: string;
        surname: string;
        email: string;
        username: string;
      }>
    ) => {
      state.isLoggedIn = action.payload.isLoggedIn;
      state.id = action.payload.id;
      state.name = action.payload.name;
      state.surname = action.payload.surname;
      state.email = action.payload.email;
      state.username = action.payload.username;
    },
  },
});

export const { LogInUser } = userSlice.actions;

export default userSlice.reducer;
