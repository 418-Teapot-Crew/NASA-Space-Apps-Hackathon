import dynamic from "next/dynamic";

const Earth = dynamic(() => import("./(components)/Earth"), { ssr: false });

export default function Home() {
  return (
    <div className="flex flex-row items-center justify-between p-48 bg-black h-screen">
      <div className="flex flex-col  text-white">
        <h1 className="font-bold text-8xl">Teapot</h1>
      </div>
      <div className="h-screen w-full">
        <Earth />
      </div>
    </div>
  );
}
