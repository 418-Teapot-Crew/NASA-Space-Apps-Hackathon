import React from "react";
import ContentHeader from "./ContentHeader";
import ContentBody from "./ContentBody";

const Contributers = ({ project }) => {
  const [isOpen, setIsOpen] = React.useState(false);
  return (
    <div className="mt-3">
      <ContentHeader
        title={"Contributers"}
        setIsOpen={setIsOpen}
        isOpen={isOpen}
      />

      <ContentBody id={"Contributers"} isOpen={isOpen}>
        <div className="flex flex-col">
          {project?.contributers?.map((contributer) => (
            <div className="bg-gray-50 font-bold text-slate-900  hover:bg-slate-700 hover:text-white cursor-pointer py-2 px-12 mb-2">
              {contributer.firstName + " " + contributer.lastName}
            </div>
          ))}
        </div>
      </ContentBody>
    </div>
  );
};

export default Contributers;
