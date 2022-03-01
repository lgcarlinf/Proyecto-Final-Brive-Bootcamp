import "./App.css";
import { Routes, Route } from "react-router-dom";

import { Login } from "./components/Login/Login";
import { MainView } from "./components/layout/MainView";
import { Register } from "./components/Register/Register";
import { Home } from "./components/Home/Home";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<MainView />}>
          <Route index element={<Login />} />

          <Route path="/Register" element={<Register />} />
          {/*           <Route path="/ForgotPsw" element={<ForgotPsw />} /> */}
        </Route>
        <Route path="/home" element={<Home />} />
      </Routes>
    </div>
  );
}

export default App;
