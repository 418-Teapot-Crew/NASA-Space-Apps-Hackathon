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
          <div className="bg-gray-50 py-2 px-12 mb-2">
            <span className="font-bold ">Project URL : </span>
            <a
              href={project?.project_url_external}
              target="_blank"
              className="underline text-title"
            >
              {project?.project_url_external}
            </a>
          </div>
          <Row label={"Geographic Scope"} value={project?.geographic_scope} />
          <Row label={"Project Status"} value={project?.project_status} />
          <Row label={"Start Date"} value={project?.start_date} />
          <Row label={"Project Contact"} value={project?.projectContact} />
          <Row label={"Fields of Science"} value={project?.fields_of_science} />
        </div>
      </ContentBody>
    </div>
  );
};

export default Details;
