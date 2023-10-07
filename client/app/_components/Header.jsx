import Image from "next/image";
import React from "react";
import Menu from "./Menu";
import Link from "next/link";

export default function Header() {
  return (
    <header className="flex w-full h-24 z-50 py-4 items-center fixed px-24 top-0 flex-row justify-between">
      <div className="">
        <Link href={"/"}>
          <Image src={"/assets/team-logo.png"} width={64} height={64} alt="" />
        </Link>
      </div>
      <Menu />
    </header>
  );
}
