import React, { useEffect, useState } from "react";

import Calculator from "./components/Calculator/Calculator";
import HistoryList from "./components/History/historyList";

import getRequestOptions from "./helpers/RequestOptions";

import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  const uri = process.env.REACT_APP_API_URL;

  const [historyItems, setHistoryItems] = useState([]);
  const [calculationResults, setCalculationResults] = useState({});

  const calculateHandler = (velocity, mass) => {
    const requestOptions = getRequestOptions("POST", {
      velocity: velocity,
      mass: mass,
    });

    fetch(uri + "/KineticEnergyCalculator", requestOptions)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        loadHistory();
        setCalculationResults(data);
      });
  };

  useEffect(() => {
    loadHistory();
  }, []);

  const loadHistory = () => {
    const requestOptions = getRequestOptions("GET");

    fetch(uri + "/CalculationHistory", requestOptions)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        setHistoryItems(data);
      });
  };

  return (
    <div className="container" style={{ marginTop: "5%" }}>
      <div className="row">
        <div className="col-3 offset-2">
          <Calculator
            onCalculationSubmit={calculateHandler}
            results={calculationResults}
          />
        </div>
        <div className="col-4 offset-2">
          <HistoryList items={historyItems} />
        </div>
      </div>
    </div>
  );
}

export default App;
