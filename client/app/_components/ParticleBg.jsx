"use client";
import { usePathname } from "next/navigation";
import ParticlesBg from "particles-bg";
import React from "react";

const ParticleBg = () => {
  const path = usePathname();
  return (
    <ParticlesBg
      color={path === "/" ? "#375bec" : "#C2021D"}
      num={75}
      type="cobweb"
      bg={true}
    />
  );
};

export default ParticleBg;
