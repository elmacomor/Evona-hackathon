import "../../styles/rankingPage.css";

import axios from "../../utils/axios";

import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { useAppSelector } from "../../redux/hooks";

import zlato from "../../assets/zlato.png";
import srebro from "../../assets/srebro.png";
import bronza from "../../assets/bronza.png";

const RankingPage = () => {
  //fetching the data from API
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Make a GET request when the component mounts
    axios
      .get("/get-scoreboard")
      .then((response) => {
        console.log(response);
        setData(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error:", error);
        setLoading(false);
      });
  }, []);

  function FirstPlace(props) {
    return <img src={zlato} alt="zlato" />;
  }
  function SecondPlace(props) {
    return <img src={srebro} alt="srebro" />;
  }
  function ThirdPlace(props) {
    return <img src={bronza} alt="srebro" />;
  }

  //Award system
  function AwardingUsers(props) {
    let rank = props.rank;

    if (rank == 1) {
      return <FirstPlace />;
    } else if (rank == 2) {
      return <SecondPlace />;
    } else if (rank == 3) {
      return <ThirdPlace />;
    }
  }

  //routing
  const navigate = useNavigate();

  const isLoggedIn = useAppSelector((state) => state.user.isLoggedIn);

  return (
    <div className="wrapper">
      {isLoggedIn ? (
        <button
          className="MyProfilebutton"
          onClick={() => navigate("/AchievementSection")}
        >
          MY PROFILE
        </button>
      ) : (
        <button className="MyProfilebutton" onClick={() => navigate("/signUp")}>
          LOG IN
        </button>
      )}
      <div className="rankingDiv">
        <p className="rheadline">RANKING</p>
        <div className="headline">
          <div className="headline1">
            <h5>Rank</h5>
            <h5 className="left">Name</h5>
          </div>

          <div className="headline1">
            <h5>Points</h5>
            <h5>Level</h5>
          </div>
        </div>
        <table className="rankingTable">
          {data != undefined &&
            data.map((item, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>
                  <AwardingUsers rank={index + 1} />
                </td>
                <td>{item.name}</td>
                <td>{item.points}</td>
                <td>{item.level}</td>
              </tr>
            ))}
        </table>
      </div>
    </div>
  );
};

export default RankingPage;

/*
<tr>
  <td>Award</td>
  <td>Name</td>
  <td>Points</td>
  <td>Level</td>
</tr>
*/
