"use client";
import { createProject } from "../../../_api/projects";
import ParticleBg from "../../../_components/ParticleBg";
import { useState } from "react";
import { BiCloudUpload } from "react-icons/bi";

const AddProject = () => {
  const [values, setValues] = useState({});
  const [file, setFile] = useState();
  const [fileUrl, setFileUrl] = useState("");

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    console.log(`e target files`, e.target.files);
    console.log(`file`, file);
    const url = URL.createObjectURL(file);
    setFile(file);
    setFileUrl(url);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      setValues({
        ...values,
        ["ownerId"]: ,
      });
      const formData = new FormData();
      const res = await createProject(values);
      console.log(res.data);
    } catch (error) {
      console.log(error);
    }
    console.log(values);
  };

  const handleChange = (event) => {
    setValues({
      ...values,
      [event.target.name]: event.target.value,
    });
  };

  return (
    <div className="pt-[100px] pb-12 flex flex-col gap-12 items-center">
      <ParticleBg />
      <h1 className="font-bold text-4xl">Share Your Project</h1>
      <form
        onSubmit={handleSubmit}
        className="flex flex-col  bg-white  gap-2 w-1/2 p-12 rounded-md shadow-2xl"
      >
        <input
          type="text"
          name="title"
          onChange={handleChange}
          placeholder="Project Title"
          className="p-2 w-full rounded-sm border"
        />

        <textarea
          type="text"
          placeholder="Description"
          name="description"
          onChange={handleChange}
          className="p-2 w-full rounded-sm border"
        />
        <input
          type="text"
          name="url"
          onChange={handleChange}
          placeholder="Project URL"
          className="p-2 w-full rounded-sm border"
        />
        <select className="p-2 w-full rounded-sm border">
          <option value="">Select Status</option>
          <option value="">Active</option>
          <option value="">Passive</option>
        </select>
        <input
          type="date"
          placeholder="ds"
          className="p-2 w-full rounded-sm border"
          name=""
          id=""
        />
        <div className="flex items-center justify-center flex-1">
          <label
            htmlFor={`dropzone-file`}
            className="flex flex-col items-center justify-center w-full h-40 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-800  hover:bg-gray-100  "
          >
            <div className="flex flex-col items-center w-1/2 justify-center pt-5 pb-6">
              <BiCloudUpload size={60} />
              <p className="mb-2 text-sm text-gray-500 dark:text-gray-400">
                <span className="font-semibold">
                  Click to upload your project image
                </span>{" "}
                or drag and drop
              </p>
              <p className="text-xs text-gray-500 dark:text-gray-400">
                SVG, PNG, JPG or GIF (MAX. 800x400px)
              </p>
            </div>
            <input
              id={`dropzone-file`}
              onChange={handleImageChange}
              name="image"
              type="file"
              x
              className="hidden"
            />
          </label>
        </div>
        <input type="file" name="" className="" placeholder="documents" id="" />
        <button className="bg-black text-white p-4 rounded-lg">Submit</button>
      </form>
    </div>
  );
};

export default AddProject;
