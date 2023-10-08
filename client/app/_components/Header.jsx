"use client";
import Image from "next/image";
import React from "react";
import Menu from "./Menu";
import Link from "next/link";
import { usePathname } from "next/navigation";

export default function Header() {
  const path = usePathname();
  return (
    <header
      className={`flex w-full z-50 py-2   items-center fixed px-24 top-0 flex-row justify-between ${
        path === "/"
          ? "bg-transparent text-black"
          : "shadow-xl filter backdrop-filter backdrop-blur-lg bg-opacity-30 rounded-md"
      }`}
    >
      <div className="">
        <Link href={"/"}>
          <div className="flex flex-row gap-5 items-center text-center ">
            {path !== "/" ? (
              <div className="flex gap-2 items-center">
                {/* <div className="h-[70px] w-auto">
                  <img
                    src="/assets/spaceapps-logo.jpg"
                    className="w-full h-full"
                    alt=""
                  />
                </div> */}
                <div className="h-[50px] w-auto">
                  <img
                    src="/assets/nasa-logo.png"
                    className="w-full h-full"
                    alt=""
                  />
                </div>
              </div>
            ) : null}
          </div>
        </Link>
      </div>
      <Menu />
    </header>
  );
}
