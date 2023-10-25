// store.ts
import { configureStore } from '@reduxjs/toolkit';
import { combineReducers } from 'redux';
import userSlice from './slices/userSLice';

const reducer = combineReducers({
  user: userSlice,
});

export const store = configureStore({ reducer });

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
