import React, { useState, useContext } from "react";
import logo from "../../assets/logo.png";
import axios from "axios";
import { StyledLogin } from "./styles";
import { AiFillUnlock } from "react-icons/ai";
import { Link, useNavigate } from "react-router-dom";
import { DataContext } from "../../context/DataContext";

export const Login = () => {
  const [inputLogin, setInputLogin] = useState({
    email: "",
    password: "",
  });

  const { data, setData } = useContext(DataContext);

  let navigate = useNavigate();

  const handleChange = (e) => {
    setInputLogin({
      ...inputLogin,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    setInputLogin({
      email: "",
      password: "",
    });
    login();
  };

  const login = async () => {
    try {
      const login = await axios.post(
        "https://localhost:44322/api/Usuarios/login",
        inputLogin
      );

      if (login.data.email) {
        const { nombre, email, password } = login.data;
        localStorage.setItem("token", password);
        localStorage.setItem("user", JSON.stringify({ nombre, email }));
        setData({
          ...data,
          nombre,
          isLogged: true,
        });
        navigate("/home");
      } else {
        return alert(login.data);
      }
    } catch (error) {
      alert("Usuario y/o Contrase;a incorrecta");
    }
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
        <label htmlFor="email">Email :</label>
        <input
          id="email"
          className="input-user"
          type="text"
          placeholder="User Name"
          name="email"
          value={inputLogin.email}
          onChange={handleChange}
        />
        <label htmlFor="password">Password :</label>
        <input
          id="password"
          className="input-pass"
          type="password"
          placeholder="Type Password"
          name="password"
          value={inputLogin.password}
          onChange={handleChange}
        />
        <div className="login">
          <input className="input-submit" type="submit" value="Login" />

          {/*  <label htmlFor="">
            {" "}
            <AiFillUnlock className="input-icon" />
            Forgot Password
          </label> */}
        </div>
      </form>
      <div className="container-create">
        <Link to="/register">Create an account</Link>
      </div>
    </StyledLogin>
  );
};
