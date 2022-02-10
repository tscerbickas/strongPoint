const HistoryItem = (props) => {
  return (
    <div className="col-lg-12">
    <dl className="row">
      <dt className="col-sm-5">Velicoty (V)</dt>
      <dd className="col-sm-7">{props.velocity} (ms/s)</dd>

      <dt className="col-sm-5">Mass (M)</dt>
      <dd className="col-sm-7">{props.mass} kg</dd>

      <dt className="col-sm-5">Kinetic Energy (KE)</dt>
      <dd className="col-sm-7">{props.kineticEnergy}</dd>

      <dt className="col-sm-5">Description</dt>
      <dd className="col-sm-7">{props.description}</dd>
    </dl>
    <hr />
  </div>
  );
};

export default HistoryItem;
