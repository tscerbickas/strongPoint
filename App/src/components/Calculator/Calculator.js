import React, { useState } from "react";
import Header from "../UI/Header/Header";
import WideButton from "../UI/Button/WideButton";
import FloatingInput from "../UI/Input/FloatingInput";
import CalculationResult from "./CalculationResult";

const Calculator = (props) => {
  const [massError, setMassError] = useState("");
  const [velocityError, setVelocityError] = useState("");

  const errorMsg = "Input should be greater than 0.";

  const maxLength = 10;
  const lengthErrorMsg = `Input max length ${maxLength}.`;

  const calculateHandler = (event) => {
    event.preventDefault();

    if (isFormIsValid() === false) {
      return;
    }

    const mass = event.target.mass.value;
    const velocity = event.target.velocity.value;

    props.onCalculationSubmit(velocity, mass);
  };

  const validateVelocity = (velocity) => {
    validateInputValue(velocity, setVelocityError);
  };

  const validateMass = (mass) => {
    validateInputValue(mass, setMassError);
  };

  const validateInputValue = (value, setErrorMsg) => {
    if (!isInputValid(value)) {
      setErrorMsg(errorMsg);
      return;
    }

    if (value.length > maxLength) {
      setErrorMsg(lengthErrorMsg);
      return;
    }

    setErrorMsg("");
  };

  const isInputValid = (input) => {
    return Number(input) > 0;
  };

  const isFormIsValid = () => {
    return massError.length <= 0 && velocityError.length <= 0;
  };

  return (
    <React.Fragment>
      <Header title="Kinetic Energy Calculator" />
      <div className="col-12 mb-5">
        <form onSubmit={calculateHandler}>
          <FloatingInput
            type="number"
            id="velocity"
            placeholder="Velocity (m/s)"
            onChange={(event) => {
              validateVelocity(event.target.value);
            }}
            error={velocityError}
          />
          <FloatingInput
            type="number"
            id="mass"
            placeholder="Mass (kg)"
            onChange={(event) => {
              validateMass(event.target.value);
            }}
            error={massError}
          />
          <WideButton text="Calculate Kinetic Energy" />
        </form>
      </div>
      {props.results.description && props.results.kineticEnergy && (
        <CalculationResult {...props.results} />
      )}
    </React.Fragment>
  );
};

export default Calculator;
