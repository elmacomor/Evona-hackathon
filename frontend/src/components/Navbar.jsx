import React from "react";

import "../styles/Navbar.css";

const Navbar = () => {
  const click = () => {
    console.log("radim");
  };

  return (
    <nav className="navbar">
      <a className="link-main" href="/back">
        back
      </a>
      <button className="signup" id="signUp" onClick={click}>
        Sign Up
      </button>
    </nav>
  );
};

export default Navbar;
