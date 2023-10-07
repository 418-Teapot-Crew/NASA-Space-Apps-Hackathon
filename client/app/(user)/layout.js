import React from "react";
import Header from "../_components/Header";
import { Comfortaa } from "next/font/google";

const spaceMono = Comfortaa({
  subsets: ["latin"],
  weight: ["300", "400", "500", "600", "700"],
});

export default function UserLayout({ children }) {
  return (
    <main className={spaceMono.className}>
      <Header />
      <div className="">{children}</div>
    </main>
  );
}
