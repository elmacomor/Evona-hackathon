import React, { useState, useEffect } from "react";
import axios from "../../utils/axios";

import "../../styles/achivmentBar.css";

import icons from "../../assets/Frame.png";
import { useAppSelector } from "../../redux/hooks";

export const achievementIcons = [
  {
    icon: icons,
    key: 1,
  },
];

const AchievementBar = () => {
  const [data, setData] = useState();
  const [loading, setLoading] = useState(true);

  const user = useAppSelector((state) => state.user);

  useEffect(() => {
    console.log(user.id);
    axios
      .get(`/api/data/achivements/${user.id}`)
      .then((response) => {
        setData(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error:", error);
        setLoading(false);
      });
  }, []);

  //setting up the button functionality
  const [isButton1Active, setIsButton1Active] = useState(true);
  const [clicked, setCLicked] = useState(false);

  const toggleButton = (index, points) => {
    const currentLevel = document.getElementById("current-level");
    const nextLevel = document.getElementById("next-level");

    setIsButton1Active(!isButton1Active);

    currentLevel.innerHTML += Number(points);
  };

  function CompleteButton(props) {
    return (
      <div className="toggle-button-container">
        {isButton1Active && (
          <button
            className="toggle-button"
            onClick={() => toggleButton(props.index, props.points)}
            title={props.title}
          >
            Collect
          </button>
        )}
        {!isButton1Active && (
          <button className="toggle-button">Collected</button>
        )}
      </div>
    );
  }
  const EmptySpace = () => {
    return <div className="empty"></div>;
  };

  function Complete(props) {
    const items = props;

    const tasks = props.tasks;
    const finnishedTasks = props.finnishedTasks;

    if (tasks == finnishedTasks) {
      return <CompleteButton item={items} />;
    } else {
      return <EmptySpace item={items} />;
    }
  }

  return (
    <div className="my-achievements">
      <h4 className="ac-title">My Achievements</h4>
      <div className="achievement-icon-bar">
        {achievementIcons.map((event, index) => (
          <img src={event.icon} alt="icon" />
        ))}
      </div>
      <div className="all-achievements">
        {data != undefined &&
          data.map((item, index) => (
            <div className="achievement">
              <img src={data.icons} alt="icons" />
              <div className="progress-achievement-bars">
                <div className="progress-achievement-bar-text">
                  <div className="bars-text-left-side">
                    <h4>{item.name}</h4>
                    <p>{item.points} points</p>
                  </div>
                  <p>
                    <span>{item.userTreashHold}</span> /{" "}
                    <span>{item.treashHold}</span>
                  </p>
                </div>
                <progress
                  id="file"
                  max={item.treashHold} //treba dodati
                  value={item.userTreashHold} //treba dodati
                  className="progress-achievement-bar"
                />
              </div>
              <Complete
                tasks={item.treashHold}
                finnishedTasks={item.userTreashHold}
                index={index}
                items={item}
                onClick={() => setCLicked(!clicked)}
                /*treba dodati */
              />
            </div>
          ))}
      </div>
    </div>
  );
};

export default AchievementBar;
