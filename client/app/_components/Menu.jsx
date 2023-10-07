"use client";
import Image from "next/image";
import React, { useState } from "react";
import { BiMenu } from "react-icons/bi";
import { RxCross1 } from "react-icons/rx";
import { AnimatePresence, motion } from "framer-motion";
import Link from "next/link";

const Menu = () => {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);
  const variants = {
    hidden: { opacity: 0, x: 0, y: -200 },
    enter: { opacity: 1, x: 0, y: 0 },
    exit: { opacity: 0, x: 0, y: -200 },
  };
  return (
    <div className="text-white">
      <button onClick={toggle}>
        <BiMenu size={50} />
      </button>
      <AnimatePresence mode="wait">
        {isOpen && (
          <motion.div
            variants={variants}
            initial="hidden"
            whileInView="enter"
            exit="exit"
            className="fixed flex flex-col bg-black top-0 left-0 h-screen w-full "
          >
            <div className="flex w-full h-24 py-4 items-center  px-24 top-0 flex-row justify-between">
              <div className="">
                <Image
                  src={"/assets/team-logo.png"}
                  width={64}
                  height={64}
                  alt=""
                />
              </div>
              <button onClick={toggle}>
                <RxCross1 size={45} />
              </button>
            </div>
            <div className="flex flex-row h-[75vh] w-full justify-around items-center">
              <div>
                <ul className="flex gap-6 text-6xl flex-col items-center">
                  <li>
                    <Link href={"/login"}>Login</Link>
                  </li>
                  <li>
                    <Link href={"/register"}> Register</Link>
                  </li>
                  <li>Explore</li>
                  <li>Projects</li>
                </ul>
              </div>
              <div className="flex gap-4 items-center flex-col">
                <Image
                  src={"/assets/team-logo.png"}
                  width={400}
                  height={400}
                  alt=""
                />
                <p className="font-semibold text-2xl italic">
                  "Explore Open Science Together"
                </p>
              </div>
            </div>
          </motion.div>
        )}
      </AnimatePresence>
    </div>
  );
};

export default Menu;
