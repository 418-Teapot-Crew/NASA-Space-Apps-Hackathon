import React from "react";
import ContentHeader from "./ContentHeader";
import ContentBody from "./ContentBody";
import Row from "./Row";

const Details = ({ project }) => {
  const [isOpen, setIsOpen] = React.useState(false);
  return (
    <div>
      <ContentHeader title={"Details"} setIsOpen={setIsOpen} isOpen={isOpen} />

      <ContentBody id={"Details"} isOpen={isOpen}>
        <div className="flex flex-col">
          <Row
            label={"Owner of Project"}
            value={project?.owner?.firstName + " " + project?.owner?.lastName}
          />
          <div className="bg-gray-50 py-2 px-12 mb-2">
            <span className="font-bold ">Project URL : </span>
            <a
              href={project?.projectURL}
              target="_blank"
              className="underline text-title"
            >
              {project?.projectURL}
            </a>
          </div>
          <Row label={"Geographic Scope"} value={project?.geographicScope} />
          <Row label={"Project Status"} value={project?.projectStatus} />
          <Row label={"Start Date"} value={project?.startDate} />
          <Row label={"Project Contact"} value={project?.projectContact} />
          <Row label={"Sponsors"} value={project?.sponsors} />
          <Row label={"Fields of Science"} value={project?.fieldsOfScience} />
          <Row label={"Intented Outcomes"} value={project?.intendedOutcomes} />
        </div>
      </ContentBody>
    </div>
  );
};

export default Details;
