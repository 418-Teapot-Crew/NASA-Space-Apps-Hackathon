import React from "react";
import Header from "../_components/Header";
import { Space_Mono } from "next/font/google";

const spaceMono = Space_Mono({ subsets: ["latin"], weight: ["400", "700"] });

export default function UserLayout({ children }) {
  return (
    <div className={spaceMono.className}>
      <Header />
      <body className={spaceMono.className}>{children}</body>
    </div>
  );
}
