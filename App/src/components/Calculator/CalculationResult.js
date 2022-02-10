const CalculationResult = (props) => {
  return (
    <div className="col-12">
      <h5>Calculation Result</h5>
      <hr />
      <p>
        <strong>Kinetic Energy:</strong> {props.kineticEnergy}
      </p>
      <p>
        <strong> Description: </strong>
        {props.description}
      </p>
    </div>
  );
};

export default CalculationResult;
