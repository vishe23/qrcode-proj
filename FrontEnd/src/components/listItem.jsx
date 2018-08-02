import React, { Component } from "react";

class ListItem extends Component {
  render() {
    const apiQrCodeGenerator = "http://localhost:49774/api/QrCode?url=";

    return (
      <li
        key={this.props.itemValue}
        data-tooltip={apiQrCodeGenerator + this.props.itemUrl}
        data-tooltip-at="bottom"
      >
        <a href={this.props.itemUrl}>{this.props.itemValue}</a>
      </li>
    );
  }
}

export default ListItem;
