"use client";

import { useEffect, useState } from "react";
import ParticleBg from "./ParticleBg";

export default function Loading() {
  const [progress, setProgress] = useState(0);

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
          <div className="w-1/2 text-center font-bold text-2xl bg-white p-1 rounded-md">
            {`${progress}%`}
            <div
              className="bg-sky-600 h-8 rounded-md text-center text-black"
              style={{ width: `${progress}%` }}
            ></div>
          </div>
          <p className="px-44 mt-4 text-lg font-thin italic text-center">
            "Unlocking the doors to a world of endless possibilities, our
            project utilizes artificial intelligence to seamlessly connect users
            with Open Science projects tailored to their unique profiles.
            Embrace the future of discovery, where science meets individuality."
          </p>
        </div>
      )}
    </>
  );
}
