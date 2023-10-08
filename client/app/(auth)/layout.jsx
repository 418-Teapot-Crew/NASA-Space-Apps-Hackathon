"use client";
import { Comfortaa, Inter } from "next/font/google";
import Link from "next/link";
import React from "react";
import { Toaster } from "react-hot-toast";
import { GoogleOAuthProvider } from "@react-oauth/google";
const comfortaa = Comfortaa({
  subsets: ["latin"],
  weight: ["300", "400", "500", "600", "700"],
});
export default function AuthLayout({ children }) {
  return (
    <GoogleOAuthProvider clientId="647260585114-e8oo2ltotft736v102le12c25a7fc5pj.apps.googleusercontent.com">
      <main className={comfortaa.className}>
        <Toaster />
        <div className="w-full h-screen grid grid-cols-2">
          <div
            className="bg-[#18181B] text-[#ffffff] flex flex-col justify-between py-2 px-10"
            style={{
              backgroundImage: `url("/assets/pexels-alex-andrews-816608.jpg")`,
              backgroundSize: "contain",
              backgroundPosition: "center",
              backgroundRepeat: "repeat",
            }}
          >
            <Link href="/" className="block w-[100px] h-[100px]">
              <img
                src="./assets/team-logo.png"
                className="w-full h-full object-contain"
                alt=""
              />
            </Link>
            <p className="font-light tracking-widest">
              "Unlocking the doors to a world of endless possibilities, our
              project utilizes artificial intelligence to seamlessly connect
              users with Open Science projects tailored to their unique
              profiles. Embrace the future of discovery, where science meets
              individuality."
            </p>
          </div>
          <div className="bg-[#ffffff] flex items-center justify-center relative">
            {children}
          </div>
        </div>
      </main>
    </GoogleOAuthProvider>
  );
}
