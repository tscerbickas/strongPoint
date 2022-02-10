import React from "react";

const Header = (props) => {
  return (
    <div className="col-lg-12 text-center">
      <h5>{props.title}</h5>
      <hr />
    </div>
  );
};

export default Header;
