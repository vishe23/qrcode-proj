import ListRender from "../components/listRender.jsx";
import React from "react";
import { shallow } from "enzyme";

describe("ListRender component", () => {
  it("should render without throwing an error", () => {
    expect(
      shallow(<ListRender list={[]} />)
        .find("div")
        .exists()
    ).toBe(true);
  });

  it("should not render and throw an error when list not passed", () => {
    try {
      shallow(<ListRender />)
        .find("div")
        .exists();
    } catch (e) {
      expect(e.message).toBe("Cannot read property 'map' of undefined");
    }
  });

  it("should have Tooltip component", () => {
    expect(
      shallow(<ListRender list={[]} />)
        .find("div")
        .find("Tooltip")
        .exists()
    ).toBe(true);
  });
});
