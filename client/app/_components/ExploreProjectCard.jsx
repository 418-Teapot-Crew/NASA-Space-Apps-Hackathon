"use client";

import Image from "next/image";
import Link from "next/link";
import React from "react";
import { motion } from "framer-motion";

const ExploreProjectCard = ({ project }) => {
  const variants = {
    hidden: { opacity: 0, x: -200, y: 0 },
    enter: { opacity: 1, x: 0, y: 0 },
  };

  return (
    <motion.div
      variants={variants}
      initial="hidden"
      whileInView="enter"
      transition={{ type: "linear" }}
    >
      <Link
        href={`/projects/${project?.project_id}`}
        className="flex h-72 items-center justify-between bg-white border border-gray-200 rounded-lg shadow flex-row w-full  hover:bg-gray-100 "
      >
        <div className="h-full w-1/4 relative">
          <Image src={"/assets/bg.jpg"} fill objectFit="cover" alt="" />
        </div>
        <div className="flex flex-col justify-between p-20 w-3/4 leading-normal">
          <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 ">
            Name : {project?.project_name}
          </h5>
          <h5 className="mb-2 text-lg font-bold tracking-tight text-gray-900 ">
            Location : {project?.geographic_scope}
          </h5>
          <p className="mb-3 line-clamp-3 font-normal text-gray-700 ">
            {project?.project_description}
          </p>
          <p className="italic line-clamp-1">
            Matched Skills: {project.fields_of_science}
          </p>
          <h3 className="font-semibold ">John Doe</h3>
        </div>
      </Link>
    </motion.div>
  );
};

export default ExploreProjectCard;
