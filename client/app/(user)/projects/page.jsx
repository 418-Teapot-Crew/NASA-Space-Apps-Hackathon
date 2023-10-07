import React from "react";
import ProjectCard from "../../_components/ProjectCard";
import { getMockData } from "../../_api/user";
import { BiSearch } from "react-icons/bi";
import { MdOutlineExplore } from "react-icons/md";

const Projects = () => {
  const data = getMockData();
  return (
    <>
      <div className="pt-[120px] mx-auto">
        <div className="flex flex-row rounded-md  px-4  border w-1/2 items-center justify-center">
          <input
            type="text"
            className="w-full focus:outline-none   p-2 "
            name=""
            placeholder="Search..."
            id=""
          />
          <button className="">
            <BiSearch className="self-center" size={30} />
          </button>
        </div>
        <button className="font-bold p-2 inline-flex bg-black items-center hover:scale-110 transition-all gap-2 m-6 rounded-md text-white">
          Explore Projects <MdOutlineExplore size={25} />
        </button>
        <div className="grid grid-cols-3 gap-y-12 py-20">
          {data.projects.map((project) => (
            <ProjectCard project={project} />
          ))}
        </div>
      </div>
    </>
  );
};

export default Projects;
