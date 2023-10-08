"use client";
import { usePathname } from "next/navigation";
import ParticlesBg from "particles-bg";
import React from "react";

const ParticleBg = () => {
  const path = usePathname();
  return (
    <ParticlesBg
      color={path === "/" ? "#0728AF" : "#C2021D"}
      num={75}
      type="cobweb"
      bg={true}
    />
  );
};

export default ParticleBg;
