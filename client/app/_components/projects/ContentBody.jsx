import React from "react";
import { AnimatePresence, motion } from "framer-motion";

const ContentBody = ({ id, isOpen, children }) => {
  return (
    <AnimatePresence initial={false} mode="wait">
      <motion.div
        id={id}
        initial={false}
        animate={
          isOpen
            ? {
                height: "auto",
                opacity: 1,
                display: "block",
                transition: {
                  height: {
                    duration: 0.4,
                  },
                  opacity: {
                    duration: 0.25,
                    delay: 0.15,
                  },
                },
              }
            : {
                height: 0,
                opacity: 0,
                transition: {
                  height: {
                    duration: 0.4,
                  },
                  opacity: {
                    duration: 0.25,
                  },
                },
                transitionEnd: {
                  display: "none",
                },
              }
        }
        className="w-full bg-white border border-blue border-t-0  py-4 self-start row-span-1 cursor-pointer tracking-wide"
      >
        {children}
      </motion.div>
    </AnimatePresence>
  );
};

export default ContentBody;
