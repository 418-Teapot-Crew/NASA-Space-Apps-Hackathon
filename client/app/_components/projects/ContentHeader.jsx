import React from "react";
import { AnimatePresence, motion } from "framer-motion";
import { BiDownArrow, BiUpArrow } from "react-icons/bi";

const ContentHeader = ({ title, setIsOpen, isOpen }) => {
  return (
    <div
      className="text-white text-xl font-bold  px-5 py-4 bg-navbar cursor-pointer border border-blue flex justify-between tracking-wide"
      onClick={() => setIsOpen((prev) => !prev)}
    >
      <span>{title}</span>
      <AnimatePresence initial={false} mode="wait">
        <motion.div
          key={isOpen ? "minus" : "plus"}
          initial={{
            rotate: isOpen ? -90 : 90,
          }}
          animate={{
            rotate: 0,
            transition: {
              type: "tween",
              duration: 0.15,
              ease: "circOut",
            },
          }}
          exit={{
            rotate: isOpen ? -90 : 90,
            transition: {
              type: "tween",
              duration: 0.15,
              ease: "circIn",
            },
          }}
        >
          {isOpen ? (
            <BiUpArrow className="text-2xl text-white" />
          ) : (
            <BiDownArrow className="text-2xl text-white" />
          )}
        </motion.div>
      </AnimatePresence>
    </div>
  );
};

export default ContentHeader;
