import { Inter } from "next/font/google";
import React from "react";
import { Toaster } from "react-hot-toast";
const inter = Inter({ subsets: ["latin"] });
export default function AuthLayout({ children }) {
  return (
    <React.Fragment className={inter.className}>
      <Toaster />
      <div className="bg-red-200 w-full h-screen grid grid-cols-2">
        <div className="bg-[#18181B] text-[#ffffff] flex flex-col justify-between p-10">
          <div className="w-[100px] h-[100px]">
            <img
              src="./assets/team-logo.png"
              className="w-full h-full object-contain"
              alt=""
            />
          </div>
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
    </React.Fragment>
  );
}
