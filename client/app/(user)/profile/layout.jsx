import React from "react";
import Sidebar from "../../_components/profile/Sidebar";

const ProfileLayout = ({ children }) => {
  return (
    <div className="pt-[120px] px-24 flex gap-10 items-center">
      <Sidebar />
      {children}
    </div>
  );
};

export default ProfileLayout;
