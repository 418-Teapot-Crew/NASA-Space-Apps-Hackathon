"use client";
import Link from "next/link";
import { usePathname } from "next/navigation";

const Sidebar = () => {
  const path = usePathname();
  console.log("path", path);
  return (
    <div className="w-96 bg-gray-100 flex flex-col self-start">
      <Link
        href="/profile"
        className={`tracking-wider w-full py-2 text-center hover:bg-gray-200 ${
          path === "/profile" ? "bg-gray-200" : "bg-gray-100"
        }`}
      >
        Profile Details
      </Link>
      <Link
        href="/profile/my-projects"
        className={`tracking-wider w-full py-2 text-center hover:bg-gray-200 ${
          path === "/profile/my-projects" ? "bg-gray-200" : "bg-gray-100"
        }`}
      >
        My Projects
      </Link>
      <Link
        href="/profile/my-contributions"
        className={`tracking-wider w-full py-2 text-center hover:bg-gray-200 ${
          path === "/profile/my-contributions" ? "bg-gray-200" : "bg-gray-100"
        }`}
      >
        My Contributions
      </Link>
    </div>
  );
};

export default Sidebar;
