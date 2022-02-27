import React from "react";
import { Login } from "../Login/Login";
import img from "../../assets/img-main.jpg";
import { StyledMain } from "./styles";

export const Main = () => {
  return (
    <StyledMain>
      <Login />
      <img className="img-main" src={img} alt="img" />
    </StyledMain>
  );
};
