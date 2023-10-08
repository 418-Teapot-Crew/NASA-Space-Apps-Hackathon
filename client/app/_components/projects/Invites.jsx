import React, { useEffect, useState } from "react";
import ContentHeader from "./ContentHeader";
import ContentBody from "./ContentBody";
import { useAuthContext } from "../../_contexts/AuthContext";
import { acceptInvite, getProjectInvite } from "../../_api/invites";

const Invites = ({ project }) => {
  const [isOpen, setIsOpen] = React.useState(false);

  const { state } = useAuthContext();
  const [data, setData] = useState([]);
  const [render, setRender] = useState(false);

  useEffect(() => {
    getProjectInvite(project?.id).then((res) => setData(res?.data?.data));
  }, [project, render]);

  console.log(data);

  const handleClick = async (id) => {
    try {
      await acceptInvite(id);
      setRender(!render);
    } catch {}
  };

  return (
    <>
      {state?.user?.id == project?.ownerId && (
        <div className="mt-3">
          <ContentHeader
            title={"Invites"}
            setIsOpen={setIsOpen}
            isOpen={isOpen}
          />

          <ContentBody id={"Invites"} isOpen={isOpen}>
            <div className="flex flex-col">
              {data?.map((invite) => (
                <div className="bg-gray-50 items-center  font-bold flex flex-row gap-4 text-slate-900   py-2 px-12 mb-2">
                  {invite?.contributor?.firstName +
                    " " +
                    invite?.contributor?.lastName}
                  {invite?.status == true ? (
                    <>
                      <h1>Accepted</h1>
                    </>
                  ) : (
                    <button
                      className="p-2 bg-green-600 text-white rounded-md"
                      onClick={() => handleClick(invite?.id)}
                    >
                      Accept
                    </button>
                  )}
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
