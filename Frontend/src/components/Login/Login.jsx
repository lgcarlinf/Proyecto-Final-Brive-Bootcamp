import React, { useState } from "react";
import logo from "../../assets/logo.png";
import { StyledLogin } from "./styles";
import { AiFillUnlock } from "react-icons/ai";
import { Link } from "react-router-dom";

export const Login = () => {
  const [inputLogin, setInputLogin] = useState({
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    setInputLogin({
      ...inputLogin,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(inputLogin);
    setInputLogin({
      email: "",
      password: "",
    });
  };

  return (
    <StyledLogin>
      <div className="header">
        <img className="logo" src={logo} alt="" />
        <h2>Personal Information</h2>
        <span></span>
        <p>Enter your e-mail address and your password</p>
      </div>
      <form action="" onSubmit={handleSubmit}>
        <input
          className="input-user"
          type="text"
          placeholder="User Name"
          name="email"
          value={inputLogin.email}
          onChange={handleChange}
        />
        <input
          className="input-pass"
          type="password"
          placeholder="Type Password"
          name="password"
          value={inputLogin.password}
          onChange={handleChange}
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
        <Link to="/register">Create an account</Link>
      </div>
    </StyledLogin>
  );
};
