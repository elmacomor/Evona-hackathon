import React from "react";

import "../../styles/achievmentSection.css";

import MyAccount from "../../components/AchievementPAge/MyAccount";
import UserPreview from "./UserPreview";

const AchievmentSection = () => {
  return (
    <div className="achievement-section">
      <MyAccount />
      <UserPreview />
    </div>
  );
};

export default AchievmentSection;
