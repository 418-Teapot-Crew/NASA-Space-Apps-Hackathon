import React, { useState } from "react";
import ContentHeader from "./ContentHeader";
import ContentBody from "./ContentBody";
import { useAuthContext } from "../../_contexts/AuthContext";

const Invites = ({ project }) => {
  const [isOpen, setIsOpen] = React.useState(false);

  const { state } = useAuthContext();
  const [data, setData] = useState([]);

  return (
    <>
      {state?.user?.id === project?.ownerId && (
        <div className="mt-3">
          <ContentHeader
            title={"Invites"}
            setIsOpen={setIsOpen}
            isOpen={isOpen}
          />

          <ContentBody id={"Invites"} isOpen={isOpen}>
            <div className="flex flex-col">
              {data?.map((user) => (
                <div className="bg-gray-50 font-bold flex flex-row gap-4 text-slate-900  hover:bg-slate-700 hover:text-white cursor-pointer py-2 px-12 mb-2">
                  {user.firstName + " " + user.lastName}
                  <button>Accept</button>
                  <button>Deny</button>
                </div>
              ))}
            </div>
          </ContentBody>
        </div>
      )}
    </>
  );
};

export default Invites;
