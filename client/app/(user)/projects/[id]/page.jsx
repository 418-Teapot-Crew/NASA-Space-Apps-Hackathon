"use client";
import React from "react";

const project = {
  id: 2,
  title: "Proje 1",
  description: "Proje 1 Açıklama",
  owner: "John Uysal",
  contributers: ["Jane Karyagdi", "Alice Demir"],
};

const ProjectDetail = ({ params }) => {
  console.log("oarams", params);
  return (
    <div className="pt-32 font-light min-h-screen">
      <div className="flex gap-10">
        <div className="w-[350px] h-[350px] bg-white shadow-lg">
          <img
            src="/assets/placeholder-project.png"
            className="w-full h-full object-contain"
            alt=""
          />
        </div>
        <div className="flex flex-col flex-1 gap-2">
          <span className="text-4xl font-extrabold">{project.title}</span>
          <span className="text-xl ">{project.owner}</span>
        </div>
      </div>
    </div>
  );
};

export default ProjectDetail;
