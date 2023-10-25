import React from "react";

import "../../styles/myAccount.css";

import AchievementBar from "./AchievementBar";

const MyAccount = () => {
  return (
    <div className="achievement-bar">
      <div className="heading">
        <h1>ACHIEVEMENTS</h1>
        <div className="bar-level">
          <p className="text_small">Level 1</p>
          <div className="bar">
            <div className="level-bar"></div>
            <p className="level-number text_small">
              <span id="current-level">0</span>/<span id="next-level">200</span>
            </p>
          </div>
          <p className="text_small">Level 2</p>
        </div>
      </div>
      <AchievementBar />
    </div>
  );
};

export default MyAccount;
