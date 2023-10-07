import { Comfortaa, Inter } from "next/font/google";
import Link from "next/link";
import React from "react";
import { Toaster } from "react-hot-toast";
const comfortaa = Comfortaa({
  subsets: ["latin"],
  weight: ["300", "400", "500", "600", "700"],
});
export default function AuthLayout({ children }) {
  return (
    <main className={comfortaa.className}>
      <Toaster />
      <div className="w-full h-screen grid grid-cols-2">
        <div className="bg-[#18181B] text-[#ffffff] flex flex-col justify-between py-2 px-10">
          <Link href="/" className="block w-[100px] h-[100px]">
            <img
              src="./assets/team-logo-black.png"
              className="w-full h-full object-contain"
              alt=""
            />
          </Link>
          <p className="font-light tracking-widest">
            Acme Inc “This library has saved me countless hours of work and
            helped me deliver stunning designs to my clients faster than ever
            before.”
          </p>
        </div>
        <div className="bg-[#ffffff] flex items-center justify-center relative">
          {children}
        </div>
      </div>
    </main>
  );
}
