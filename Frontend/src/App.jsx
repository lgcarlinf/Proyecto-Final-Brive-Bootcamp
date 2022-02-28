import "./App.css";
import { Routes, Route } from "react-router-dom";

import { Login } from "./components/Login/Login";
import { MainView } from "./components/Main/MainView";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<MainView />}>
          <Route index element={<Login />} />
          {/*   <Route path="/Register" element={<Register />} />
          <Route path="/ForgotPsw" element={<ForgotPsw />} /> */}
        </Route>
      </Routes>
    </div>
  );
}

export default App;
