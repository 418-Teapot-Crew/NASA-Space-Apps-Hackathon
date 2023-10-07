"use client";
import { Canvas, useFrame, useLoader } from "@react-three/fiber";
import React, { Suspense, useRef } from "react";
import { TextureLoader } from "three/src/loaders/TextureLoader";

function Earth() {
  const [color, normal, aoMap] = useLoader(TextureLoader, [
    "/assets/color.jpg",
    "/assets/normal.png",
    "/assets/occlusion.jpg",
  ]);

  const meshRef = useRef();

  useFrame(() => {
    meshRef.current.rotation.y += 0.005;
  });

  return (
    <mesh ref={meshRef} scale={2.0}>
      <sphereGeometry args={[1, 64, 64]} />
      <meshStandardMaterial map={color} normalMap={normal} aoMap={aoMap} />
    </mesh>
  );
}

export default function EartCanvas() {
  return (
    <Canvas>
      <ambientLight intensity={0.1} />
      <directionalLight intensity={2.5} position={[1, 0.5, 0.25]} />
      <Suspense
        fallback={() => (
          <div className="bg-black text-white h-screen w-full fixed top-0 left-0">
            Loading
          </div>
        )}
      >
        <Earth />
      </Suspense>
    </Canvas>
  );
}
