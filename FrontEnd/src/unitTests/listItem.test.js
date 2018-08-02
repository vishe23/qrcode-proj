import ListItem from "../components/listItem.jsx";
import React from "react";
import { shallow } from "enzyme";

describe("ListItem component", () => {
  it("should render without throwing an error", () => {
    expect(
      shallow(<ListItem />)
        .find("li")
        .exists()
    ).toBe(true);
  });

  it("renders a inside li", () => {
    expect(
      shallow(<ListItem />)
        .find("li")
        .find("a").length
    ).toEqual(1);
  });
});
