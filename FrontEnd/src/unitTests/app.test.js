import App from "../components/app.jsx";
import React from "react";
import { shallow } from "enzyme";

const axios = require("axios");
const dataUrlApi = "http://localhost:49774/api/dataurl";
const linksProp = "links";

jest.mock("axios", () => {
  const dataUrl = [{ Title: "Facebook", url: "http://facebook.com" }];

  return {
    get: jest.fn(() => Promise.resolve(dataUrl))
  };
});

describe("App component", () => {
  it("should render ListRender component without throwing an error", () => {
    expect(
      shallow(<App />)
        .find("ListRender")
        .exists()
    ).toBe(true);
  });

  it("state not modified before promise on #componentDidMount", () => {
    const app = shallow(<App />);
    app.instance().componentDidMount();
    expect(axios.get).toHaveBeenCalled();
    expect(axios.get).toHaveBeenCalledWith(dataUrlApi);
    expect(app.state()).toHaveProperty(linksProp, []);
  });

  it("fetches dataUrl on #componentDidMount", () => {
    const app = shallow(<App />);
    app
      .instance()
      .componentDidMount()
      .then(response => {
        expect(axios.get).toHaveBeenCalled();
        expect(axios.get).toHaveBeenCalledWith(dataUrlApi);
        expect(app.state()).toHaveProperty(linksProp, response);
        done();
      });
  });
});
