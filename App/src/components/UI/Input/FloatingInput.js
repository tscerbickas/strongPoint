import React from "react";

const Input = (props) => {
  return (
    <React.Fragment>
      <div className="form-floating mb-3">
        <input
          type={props.type}
          className={`form-control ${props.error && props.error.length > 0 ? "is-invalid" : ""}`}
          id={props.id}
          name={props.id}
          placeholder={props.placeholder}
          onChange={props.onChange}
        />
        <label htmlFor={props.id}>{props.placeholder}</label>
        <p className="invalid-feedback">{props.error}</p>
      </div>
    </React.Fragment>
  );
};

export default Input;
