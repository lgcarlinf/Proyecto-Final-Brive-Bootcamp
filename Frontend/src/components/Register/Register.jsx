import React from "react";
import { StyledRegister } from "./styles";
import logo from "../../assets/logo.png";
import { Link } from "react-router-dom";
import axios from "axios";

export const Register = () => {
  const [inputRegister, setInputRegister] = React.useState({
    nombre: "",
    apellidos: "",
    email: "",
    fechanacimiento: "",
    password: "",
  });

  const users = async () => {
    const response = await axios.get("https://localhost:44322/api/Usuarios");
    console.log(response.data);
  };

  const register = async () => {
    const response = await axios.post(
      "https://localhost:44322/api/Usuarios",
      inputRegister
    );
    alert("Usuario registrado");
  };

  const handleChange = (e) => {
    setInputRegister({
      ...inputRegister,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    /*     console.log(inputRegister); */
    setInputRegister({
      nombre: "",
      apellidos: "",
      email: "",
      fechanacimiento: "",
      password: "",
    });
    register();
  };
  users();
  return (
    <StyledRegister>
      <div className="header">
        <img className="logo" src={logo} alt="" />
        <h2>Personal Information</h2>
        <span></span>
        <p>Enter your personal detail below:</p>
      </div>
      <form action="" onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Name"
          name="nombre"
          onChange={handleChange}
          value={inputRegister.nombre}
        />
        <input
          type="text"
          placeholder="Last Name"
          name="apellidos"
          onChange={handleChange}
          value={inputRegister.apellidos}
        />
        <input
          type="text"
          placeholder="Email Address"
          name="email"
          value={inputRegister.email}
          onChange={handleChange}
        />
        <input
          type="date"
          placeholder="date"
          name="fechanacimiento"
          value={inputRegister.fechanacimiento}
          onChange={handleChange}
        />
        <input
          type="password"
          placeholder="Password"
          name="password"
          value={inputRegister.password}
          onChange={handleChange}
        />
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
