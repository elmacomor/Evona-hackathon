import React from "react";
import "../../styles/signUp.css";
import { useAppDispatch } from "../../redux/hooks";
import { LogInUser } from "../../redux/slices/userSLice";
function SignUp() {
  const dispatch = useAppDispatch();

  const handleButtonClick = () => {
    dispatch(
      LogInUser({
        LogInUser: true,
      })
    );
  };
  return (
    <div className="wrapper1">
      <div className="box">
        <div className="TO-JE-TAJ-BUTTON">
          <div className="SIGN-IN-OBJEKAT">
            <div className="overlap-group">
              <link rel="preconnect" href="https://fonts.googleapis.com" />
              <link
                rel="preconnect"
                href="https://fonts.gstatic.com"
                crossorigin
              />
              <link
                href="https://fonts.googleapis.com/css2?family=Big+Shoulders+Display:wght@900&family=Raleway:wght@200;400;700&display=swap"
                rel="stylesheet"
              />
              <div className="text-wrapper">
                <p>SIGN UP</p>
              </div>
              <div className="boxic">
                <img
                  className="checkmark"
                  src="src/images/checkmark_360.png"
                  alt="checkmark"
                />
              </div>
              <div className="label">Nickname</div>
              <div className="input-field">
                <input type="text" placeholder="Enter your nickname" />
              </div>
              <div className="label">Password</div>
              <div className="input-field">
                <input type="password" placeholder="Enter your password" />
              </div>
              <div className="div-wrapper">
                {/* Add a Link to navigate to another page */}
                <div className="text-wrapper-4" onClick={handleButtonClick}>
                  Sign up
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
export default SignUp;
