import React, { useContext } from "react";
import { Home } from "../Home/Home";
import { NotFound } from "../NotFound/NotFound";

export const PrivateRoute = () => {
  const token = localStorage.getItem("token");

  if (token === null) {
    return <NotFound />;
  } else {
    return <Home />;
  }
};
