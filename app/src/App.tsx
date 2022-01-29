import React from "react";
import "./App.css";
import Header from "./components/layout/Header";
import Sidebar from "./components/layout/Sidebar";
import Main from "./components/layout/Main";
import axios from "axios";

axios.defaults.baseURL = "http://localhost:59422/api";

function App() {
  return (
    <div className="App">
      <Header />
      <div className="page">
        <Sidebar />
        <Main />
      </div>
    </div>
  );
}

export default App;
