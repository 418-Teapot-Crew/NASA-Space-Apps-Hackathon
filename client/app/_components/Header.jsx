import Image from "next/image";
import React from "react";
import Menu from "./Menu";

export default function Header() {
  return (
    <header className="flex w-full h-24 py-4 items-center fixed px-24 top-0 flex-row justify-between">
      <div className="">
        <Image src={"/assets/team-logo.png"} width={64} height={64} alt="" />
      </div>
      <Menu />
    </header>
  );
}
