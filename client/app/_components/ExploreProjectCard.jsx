"use client";

import Image from "next/image";
import Link from "next/link";
import React from "react";
import { motion } from "framer-motion";

const ExploreProjectCard = () => {
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
        href="/"
        className="flex h-60 items-center bg-white border border-gray-200 rounded-lg shadow flex-row w-full  hover:bg-gray-100 "
      >
        <div className="h-full w-1/3 relative">
          <Image src={"/assets/bg.jpg"} fill alt="" />
        </div>
        <div className="flex flex-col justify-between p-4 leading-normal">
          <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 ">
            Noteworthy technology acquisitions 2021
          </h5>
          <p className="mb-3 font-normal text-gray-700 ">
            Here are the biggest enterprise technology acquisitions of 2021 so
            far, in reverse chronological order.
          </p>
          <p className="italic">
            Matched Skills : "Lorem, ipsum dolor sit amet consectetur
            adipisicing elit. Error atque debitis ea est aut cupiditate itaque
            dolorem fugit quasi nam".
          </p>
          <h3 className="font-semibold ">John Doe</h3>
        </div>
      </Link>
    </motion.div>
  );
};

export default ExploreProjectCard;
