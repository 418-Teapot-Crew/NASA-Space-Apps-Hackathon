"use client";
import { OrbitControls, useGLTF } from "@react-three/drei";
import { Canvas, useFrame, useLoader } from "@react-three/fiber";
import React, { Suspense, useRef } from "react";
import { USDZLoader } from "three/examples/jsm/loaders/USDZLoader";
import { TextureLoader } from "three/src/loaders/TextureLoader";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";

function Earth() {
  const [color, normal, aoMap, alpha, bump, spac] = useLoader(TextureLoader, [
    "https://s3-us-west-2.amazonaws.com/s.cdpn.io/141228/earthmap1k.jpg",
    "/assets/normal.png",
    "/assets/occlusion.jpg",
    "https://s3-us-west-2.amazonaws.com/s.cdpn.io/141228/earthcloudmaptrans.jpg",
    "https://s3-us-west-2.amazonaws.com/s.cdpn.io/141228/earthbump1k.jpg",
    "https://s3-us-west-2.amazonaws.com/s.cdpn.io/141228/earthspec1k.jpg",
  ]);

  const meshRef = useRef();

  useFrame(() => {
    meshRef.current.rotation.y += 0.005;
  });

  return (
    <mesh ref={meshRef} scale={2.0}>
      <sphereGeometry args={[1, 64, 64]} />
      <meshPhongMaterial
        map={color}
        normalMap={normal}
        bumpMap={bump}
        alphaMap={alpha}
        specularMap={spac}
        aoMap={aoMap}
      />
    </mesh>
  );
}

export default function EartCanvas() {
  return (
    <Canvas className="cursor-pointer">
      <OrbitControls
        autoRotate
        enableZoom={false}
        maxPolarAngle={Math.PI / 2}
        minPolarAngle={Math.PI / 2}
        enablePan={false}
      />
      <ambientLight intensity={2} />
      <directionalLight intensity={4.5} position={[0.5, 2, 0.2]} />
      <Earth />
    </Canvas>
  );
}
