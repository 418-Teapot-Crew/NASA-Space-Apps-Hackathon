import Search from "../../_components/Search";
import { getMockData } from "../../_api/user";
import ExploreProjectCard from "../../_components/ExploreProjectCard";
import React from "react";
import Loading from "../../_components/Loading";

const Explore = () => {
  const data = getMockData();

  return (
    <div className="pt-[120px] flex flex-col gap-4 items-center">
      <Loading />
      <h1 className="font-light italic text-lg px-12">
        "Unlocking the doors to a world of endless possibilities, our project
        utilizes artificial intelligence to seamlessly connect users with Open
        Science projects tailored to their unique profiles. Embrace the future
        of discovery, where science meets individuality."
      </h1>
      <Search />
      {data.projects.map((project) => (
        <ExploreProjectCard />
      ))}
    </div>
  );
};

export default Explore;
