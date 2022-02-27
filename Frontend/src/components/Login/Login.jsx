import React from "react";
import logo from "../../assets/logo.png";
import { StyledLogin } from "./styles";
import { AiFillUnlock } from "react-icons/ai";

export const Login = () => {
  return (
    <StyledLogin>
      <div className="header">
        <img className="logo" src={logo} alt="" />
        <h2>Personal Information</h2>
        <span></span>
        <p>Enter your e-mail address and your password</p>
      </div>
      <form action="">
        <input className="input-user" type="text" placeholder="User Name" />
        <input
          className="input-pass"
          type="password"
          placeholder="Type Password"
        />
        <div className="login">
          <input className="input-submit" type="submit" value="Login" />

          <label htmlFor="">
            {" "}
            <AiFillUnlock className="input-icon" />
            Forgot Password
          </label>
        </div>
      </form>
      <div className="container-create">
        <button>Create an account</button>
      </div>
    </StyledLogin>
  );
};
