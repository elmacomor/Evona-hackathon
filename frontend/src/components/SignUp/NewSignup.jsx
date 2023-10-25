import "../../styles/elmaSignUp.css";
import { useAppDispatch } from "../../redux/hooks";
import { LogInUser } from "../../redux/slices/userSLice";
import React, { useState } from "react";
import axios from "../../utils/axios";
import { useNavigate } from "react-router-dom";

const NewSignup = () => {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    UserName: "",
    Id: "",
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleClick = async () => {
    console.log(formData.Id);
    console.log(formData.UserName);
    axios
      .post(`/Login-app/${formData.Id}/${formData.UserName}`)
      .then((response) => {
        // Handle the response data
        console.log("Response:", response.data);

        dispatch(
          LogInUser({
            isLoggedIn: true,
            id: response.data.id,
            name: response.data.name,
            surname: response.data.surname,
            email: response.data.email,
            username: response.data.username,
          })
        );
        navigate("/");
      })
      .catch((error) => {
        // Handle any errors
        console.error("Error:", error);
      });
  };
  return (
    <div className="signUpWrapper">
      <div className="middleBox">
        <h1>LOG IN</h1>
        <div className="imageDiv"></div>
        <div className="label">Nickname</div>
        <div className="input-field">
          <input
            type="email"
            placeholder="Username"
            name="UserName"
            value={formData.UserName}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="label">Password</div>
        <div className="input-field">
          <input
            type="password"
            placeholder="Password"
            name="Id"
            value={formData.Id}
            onChange={handleInputChange}
            required
          />
        </div>
        <button className="signInButton" onClick={handleClick}>
          Log In
        </button>
      </div>
    </div>
  );
};
export default NewSignup;
