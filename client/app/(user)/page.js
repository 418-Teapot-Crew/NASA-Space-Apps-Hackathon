"use client";
import ParticlesBg from "particles-bg";
import Earth from "../_components/Earth";

export default function Home() {
  return (
    <div className="h-screen relative  flex items-center justify-between px-64">
      <ParticlesBg color="#FFFFFF" num={50} type="cobweb" bg={true} />
      <div className=" flex flex-col gap-4 text-center  text-white ">
        <div className="overflow-hidden">
          <h1 className="m-0 font-bold  text-8xl">418 TEAPOT</h1>
          <p className="m-0 font-bold ">
            "Connecting Minds, Building Futures: Uniting Open Science Innovators
            with Enthusiastic Contributors!"
          </p>
        </div>
      </div>
      <div className="h-[100vh] w-full">
        <Earth />
      </div>
    </div>
  );
}
