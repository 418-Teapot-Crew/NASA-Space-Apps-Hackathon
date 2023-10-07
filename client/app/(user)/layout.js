import React from "react";
import Header from "../_components/Header";
import { Space_Mono } from "next/font/google";

const spaceMono = Space_Mono({ subsets: ["latin"], weight: ["400", "700"] });

export default function UserLayout({ children }) {
  return (
    <main className={spaceMono.className}>
      <Header />
      <div className=" px-24">{children}</div>
    </main>
  );
}
