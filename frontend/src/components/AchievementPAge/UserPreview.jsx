import React from "react";

import "../../styles/userPreview.css";
import avatar from "../../assets/avatar.png";
import { useNavigate } from "react-router-dom";
import { useAppSelector } from "../../redux/hooks";

const UserPreview = () => {
  const user = useAppSelector((state) => state.user);

  const navigate = useNavigate();
  return (
    <div className="user-preview">
      <div className="avatar-style">
        <img src={avatar} alt="avatar" id="avatar" />
        <h3 className="avatar-name" id="name">
          {user.name} <span className="bold">{user.surname}</span>
        </h3>
        <p className="avatar-level">
          Level: <span id="level">1</span>
        </p>
      </div>
      <div className="progress-bar">
        <p className="text_small">1</p>
        <div className="level-bar"></div>
        <p className="text_small">2</p>
      </div>
      <div className="user-links">
        <ul>
          <li>
            <a onClick={() => navigate("/AchievementSection")}>Achievements</a>
          </li>
          <li>
            <a onClick={() => navigate("/")}>Ranking</a>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default UserPreview;
