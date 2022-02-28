import React from "react";
import { Outlet } from "react-router-dom";
import img from "../../assets/img-main.jpg";
import { StyledMain } from "./styles";

export const MainView = () => {
  return (
    <StyledMain>
      <Outlet />
      <img className="img-main" src={img} alt="img" />
    </StyledMain>
  );
};
