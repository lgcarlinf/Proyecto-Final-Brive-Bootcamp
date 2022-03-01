import React from "react";
import { StyledHome } from "./styles";
import { Link } from "react-router-dom";
import logo from "../../assets/logo.png";

export const Home = () => {
  return (
    <StyledHome>
      <div className="nav">
        <img src={logo} alt="" />
        <div className="acc-options">
          <Link to="/">Name</Link>
          <button>Log Out</button>
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
