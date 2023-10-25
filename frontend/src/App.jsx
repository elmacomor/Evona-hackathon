import React from "react";
import { Routes, Route, BrowserRouter } from "react-router-dom";
import Navbar from "./components/Navbar";
import AchievmentSection from "./components/AchievementPAge/AchievmentSection";
import RankingPage from "./components/RankingPage/RankingPage";
import SignUp from "./components/SignUp/SignUp";
import { Provider } from "react-redux";
import { store } from "./redux/store";
import NewSignup from "./components/SignUp/newSignup";

const App = () => {
  return (
    <>
      <Provider store={store}>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<RankingPage />} />
            <Route path="/AchievementSection" element={<AchievmentSection />} />
            <Route path="*" element={<RankingPage />}></Route>
            <Route path="/signUp" element={<NewSignup></NewSignup>}></Route>
          </Routes>
        </BrowserRouter>
      </Provider>
    </>
  );
};

export default App;
