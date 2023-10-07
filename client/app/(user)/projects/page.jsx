import React from "react";
import ProjectCard from "../../_components/ProjectCard";
import { getMockData } from "../../_api/user";

const Projects = () => {
  const data = getMockData();
  return (
    <>
      <div className="pt-[120px] mx-auto">
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
