import React, { useContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { StyledHome } from "./styles";
import axios from "axios";
import logo from "../../assets/logo.png";
import { DataContext } from "../../context/DataContext";

export const Home = () => {
  const { data, setData } = useContext(DataContext);
  const navigate = useNavigate();
  const user = JSON.parse(localStorage.getItem("user"));

  const [company, setCompany] = useState({
    EMPRESA_BUSCADA: "",
  });

  const [result, setResult] = useState({
    fecha: "",
    resultado: "",
  });

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

  const handleChange = (e) => {
    setCompany({
      ...company,
      EMPRESA_BUSCADA: e.target.value,
    });
  };

  const handleClick = () => {
    busqueda();
    setCompany({
      ...company,
      EMPRESA_BUSCADA: "",
    });
  };

  const busqueda = async () => {
    try {
      const peticion = await axios.post(
        "https://localhost:44322/api/Busquedas",
        company
      );
      const { empresA_BUSCADA, resultadO_BUSQUEDA, fechA_BUSQUEDA } =
        peticion.data;

      setResult({
        ...result,
        empresa: empresA_BUSCADA,
        fecha: fechA_BUSQUEDA,
        resultado: resultadO_BUSQUEDA,
      });
    } catch (error) {
      alert("No existen Resultados");
    }
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
              onChange={handleChange}
              value={company.EMPRESA_BUSCADA}
            />
            <input
              className="input-submit"
              type="submit"
              value="Find "
              onClick={handleClick}
            />
          </div>
        </div>
      </div>
      <div className="result">
        <div className="description">
          <p>Company Name</p>
          <span>job offers</span>
        </div>
        <div className="info">
          <p>{result.empresa}</p>
          <span>{result.resultado}</span>
        </div>
      </div>
    </StyledHome>
  );
};
