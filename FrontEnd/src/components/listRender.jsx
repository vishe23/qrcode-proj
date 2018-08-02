import React, { Component } from "react";
import ListItem from "./listItem.jsx";
import Tooltip from "./tooltip.jsx";
import style from "./../index.css";

class ListRender extends Component {
  render() {
    return (
      <div>
        <Tooltip events delay={100} />
        <ul style={{ maxWidth: "400px" }}>
          {this.props.list.map(function(listValue) {
            return (
              <ListItem
                key={listValue.Id}
                itemValue={listValue.Title}
                itemUrl={listValue.Url}
              />
            );
          })}
        </ul>
      </div>
    );
  }
}

export default ListRender;
