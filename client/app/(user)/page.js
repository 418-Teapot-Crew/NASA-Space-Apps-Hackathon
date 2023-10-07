"use client";
import Earth from "../_components/Earth";
import ParticleBg from "../_components/ParticleBg";

export default function Home() {
  return (
    <div className="h-screen relative flex items-center justify-between ">
      <ParticleBg />
      <div className=" flex flex-1 flex-col gap-4 text-center  text-black ">
        <h1 className="m-0 font-extrabold text-6xl">
          <i>Let's</i> Explore Open Science Together
        </h1>
        <p className="m-0 font-bold ">
          "Connecting Minds, Building Futures: Uniting Open Science Innovators
          with Enthusiastic Contributors!"
        </p>
      </div>

      <div className="h-[100vh]  flex-1 w-full">
        <Earth />
      </div>
    </div>
  );
}
