import React from "react";
import ProjectCard from "../../_components/ProjectCard";
import { getMockData } from "../../_api/user";
import { BiSearch } from "react-icons/bi";
import { MdOutlineExplore } from "react-icons/md";
import Search from "../../_components/Search";

const Projects = () => {
  const data = getMockData();
  return (
    <>
      <div className="pt-[120px] px-24 flex flex-col gap-2  items-center">
        <Search />
        <button className="font-bold p-2 inline-flex bg-black items-center hover:scale-110 transition-all gap-2 m-6 rounded-md text-white">
          Explore Projects <MdOutlineExplore size={25} />
        </button>
        <div className="grid  grid-cols-3 gap-12 ">
          {data.projects.map((project) => (
            <ProjectCard project={project} />
          ))}
        </div>
      </div>
    </>
  );
};

export default Projects;
