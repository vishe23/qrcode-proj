import React, { Component } from "react";
import axios from "axios";
import ListRender from "./listRender.jsx";

export default class App extends Component {
  constructor() {
    super();

    this.state = {
      links: []
    };
  }

  componentDidMount() {
    const dataUrlApi = "http://localhost:49774/api/dataurl";
    let th = this;

    return (this.serverRequest = axios
      .get(dataUrlApi)
      .then(function(result) {
        th.setState({
          links: result.data
        });
      })
      .catch(function(error) {
        console.log(error);
      }));
  }

  componentWillUnmount() {
    this.serverRequest.abort();
  }

  render() {
    return <ListRender list={this.state.links} />;
  }
}
