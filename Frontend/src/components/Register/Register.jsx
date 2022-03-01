import React from "react";
import { StyledRegister } from "./styles";
import logo from "../../assets/logo.png";
import { Link } from "react-router-dom";

export const Register = () => {
  return (
    <StyledRegister>
      <div className="header">
        <img className="logo" src={logo} alt="" />
        <h2>Personal Information</h2>
        <span></span>
        <p>Enter your personal detail below:</p>
      </div>
      <form action="">
        <input type="text" placeholder="Name" />
        <input type="text" placeholder="Last Name" />
        <input type="text" placeholder="Email Address" />
        <input type="date" placeholder="date" />
        <input type="password" placeholder="Password" />
        <div className="terms">
          <input type="checkbox" className="checkbox" />
          <label htmlFor="">
            I agree to the <span>Terms of Service & Privacy Policy</span>
          </label>
        </div>
        <div className="container-buttons">
          <Link to="/">Back</Link>
          <input type="submit" value="Submit" />
        </div>
      </form>
    </StyledRegister>
  );
};
