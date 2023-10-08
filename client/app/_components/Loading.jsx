"use client";
import { useEffect, useState } from "react";
import dynamic from "next/dynamic";

const ParticleBg = dynamic(() => import("./ParticleBg"), {
  ssr: false,
});

export default function Loading({ progress, setProgress }) {
  useEffect(() => {
    const interval = setInterval(() => {
      setProgress((prevProgress) =>
        prevProgress < 100 ? prevProgress + 1 : 100
      );
    }, 30);

    return () => clearInterval(interval);
  }, []);

  return (
    <>
      {progress !== 100 && (
        <div className="flex fixed h-screen bg-white flex-col items-center justify-center  top-0 w-full z-50">
          <ParticleBg />
          <div className="w-1/2 text-center font-bold text-3xl bg-white p-1  rounded-md tracking-wider">
            {`${progress}%`}
            <div
              className="bg-[#C2021D] h-8 rounded-md text-center text-black mt-2"
              style={{ width: `${progress}%` }}
            ></div>
          </div>
          <p className="px-44 mt-4 text-xl font-thin italic text-center">
            The magic is happening, sorry for the wait.
          </p>
        </div>
      )}
    </>
  );
}
