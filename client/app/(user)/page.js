"use client";
import dynamic from "next/dynamic";
import Loading from "../_components/Loading";
const Earth = dynamic(() => import("../_components/Earth"), {
  loading: () => <Loading />,
});
const ParticleBg = dynamic(() => import("../_components/ParticleBg"));

export default function Home() {
  return (
    <div className="h-screen px-24 relative flex items-center justify-between ">
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
