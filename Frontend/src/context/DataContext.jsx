import React, { createContext } from "react";

export const DataContext = createContext();

export const DataProvider = ({ children }) => {
  const [data, setData] = React.useState({
    nombre: "",
    email: "",
    token: "",
    isLogged: false,
  });

  return (
    <DataContext.Provider value={{ data, setData }}>
      {children}
    </DataContext.Provider>
  );
};
