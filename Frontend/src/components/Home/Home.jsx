import React, { useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { StyledHome } from "./styles";
import logo from "../../assets/logo.png";
import { DataContext } from "../../context/DataContext";

export const Home = () => {
  const { data, setData } = useContext(DataContext);
  const navigate = useNavigate();
  const user = JSON.parse(localStorage.getItem("user"));

  useEffect(() => {
    setData({
      ...data,
      nombre: user?.nombre,
      email: user?.email,
      token: localStorage.getItem("token"),
      isLogged: true,
    });
  }, []);

  const handleLogout = () => {
    localStorage.clear();
    setData({
      ...data,
      nombre: "",
      email: "",
      token: "",
      isLogged: false,
    });
    navigate("/");
  };

  return (
    <StyledHome>
      <div className="nav">
        <img src={logo} alt="" />
        <div className="acc-options">
          <p>{data.nombre}</p>
          <button onClick={handleLogout}>Log Out</button>
        </div>
      </div>
      <div className="content">
        <div className="text-content">
          <span className="subtitle">
            Find Jobs, Employment & Carrer Opportunities
          </span>
          <h1>
            Search Between More Then <span>50,000 </span> Open Jobs.
          </h1>
          <div className="content-searchbar">
            <input
              className="input-text"
              type="text"
              placeholder="Company Tittle"
            />
            <input className="input-submit" type="submit" value="Find " />
          </div>
        </div>
      </div>
      <div className="result">
        <div className="description">
          <p>Company Name</p>
          <span>job offers</span>
        </div>
        <div className="info">
          <p>Coka kola</p>
          <span>458</span>
        </div>
      </div>
    </StyledHome>
  );
};
