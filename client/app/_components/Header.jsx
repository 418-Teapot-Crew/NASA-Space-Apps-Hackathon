"use client";
import Image from "next/image";
import React from "react";
import Menu from "./Menu";
import Link from "next/link";
import { usePathname } from "next/navigation";

export default function Header() {
  const path = usePathname();
  console.log("path", path);
  return (
    <header
      className={`flex w-full z-50 py-2  items-center fixed px-10 top-0 flex-row justify-between ${
        path === "/" ? "bg-transparent text-black" : "bg-navbar text-white"
      }`}
    >
      <div className="">
        <Link href={"/"}>
          <div className="w-[100px] h-full relative">
            <img
              src="/assets/team-logo.png"
              className="w-full h-full object-contain"
              alt=""
            />
          </div>
        </Link>
      </div>
      <Menu />
    </header>
  );
}
