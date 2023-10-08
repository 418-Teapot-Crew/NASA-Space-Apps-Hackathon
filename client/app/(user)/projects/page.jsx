import React from "react";
import ProjectCard from "../../_components/ProjectCard";
import { getMockData } from "../../_api/user";
import { MdOutlineExplore } from "react-icons/md";
import Search from "../../_components/Search";
import { PiShareFatBold } from "react-icons/pi";
import Link from "next/link";

async function getData() {
  const res = await fetch(
    process.env.NEXT_PUBLIC_BASE_URL + "/api/Projects/getall"
  );

  if (!res.ok) {
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

const Projects = async () => {
  const data = await getData();
  return (
    <>
      <div className="pt-[120px]  px-24 flex flex-col gap-2  items-center">
        <Search />
        <div className="flex flex-row gap-4 items-center">
          <button className="font-bold p-2 inline-flex bg-black items-center hover:scale-110 transition-all shadow-xl gap-2 m-2 rounded-md text-white">
            Explore Projects <MdOutlineExplore size={25} />
          </button>
          <Link
            href={"/projects/add"}
            className="font-bold p-2 inline-flex bg-white items-center hover:scale-110 transition-all shadow-xl gap-2 m-6 rounded-md text-black"
          >
            Share a Project <PiShareFatBold size={25} />
          </Link>
        </div>
        <div className="grid  grid-cols-3 gap-12 ">
          {data.data.map((project) => (
            <ProjectCard project={project} />
          ))}
        </div>
      </div>
    </>
  );
};

export default Projects;
