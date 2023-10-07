"use client";
import { motion } from "framer-motion";
import ParticleBg from "../_components/ParticleBg";
import Earth from "../_components/Earth";

export default function Home() {
  const variants = {
    hidden: { opacity: 0, x: -200, y: 0 },
    enter: { opacity: 1, x: 0, y: 0 },
  };

  const earthVariant = {
    hidden: { opacity: 0, x: +200, y: 0 },
    enter: { opacity: 1, x: 0, y: 0 },
  };

  return (
    <div className="h-screen  relative flex items-center justify-between ">
      <ParticleBg />
      <motion.div
        variants={variants}
        initial="hidden"
        animate="enter"
        transition={{ type: "linear", delay: 0.5 }}
        className=" flex flex-1 flex-col gap-4 text-center  text-black "
      >
        <h1 className="m-0 font-extrabold text-6xl">
          <i>Let's</i> Explore Open Science Together
        </h1>
        <p className="m-0 font-light italic text-2xl">
          "Connecting Minds, Building Futures: Uniting Open Science Innovators
          with Enthusiastic Contributors!"
        </p>
        <div className="flex flex-row items-center justify-center">
          <button className="bg-black text-white shadow-lg rounded-2xl border py-2 px-4">
            Get Started
          </button>
        </div>
      </motion.div>

      <motion.div
        variants={earthVariant}
        initial="hidden"
        animate="enter"
        transition={{ type: "linear", delay: 0.7 }}
        className="h-[100vh]  flex-1 w-full"
      >
        <Earth />
      </motion.div>
    </div>
  );
}
