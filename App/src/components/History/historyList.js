import React from "react";
import HistoryItem from "./historyItem";
import Header from "./../UI/Header/Header";

const HistoryList = (props) => {
  return (
    <React.Fragment>
      <Header title="History" />
      {(props?.items?.length <= 0) && <div className="text-center"> History is empty.
        </div>}
      {props.items.map((c) => (
        <HistoryItem key={c.id} {...c} />
      ))}
    </React.Fragment>
  );
};

export default HistoryList;
