"use client";

import React, { useState } from "react";
import { BiCloudUpload } from "react-icons/bi";

const AddProject = () => {
  const [formData, setFormData] = useState({});

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log(formData);
  };

  const handleChange = (event) => {
    setFormData({
      ...formData,
      [event.target.name]: event.target.value,
    });
  };

  return (
    <div className="pt-[120px] flex flex-col gap-12 items-center">
      <h1 className="font-bold text-4xl">Share Your Project</h1>
      <form
        onSubmit={handleSubmit}
        className="flex flex-col gap-2 w-1/2 p-12 rounded-md shadow-2xl"
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
            <input id={`dropzone-file`} type="file" className="hidden" />
          </label>
        </div>
        <input type="file" name="" className="" placeholder="documents" id="" />
        <button className="bg-black text-white p-4 rounded-lg">Submit</button>
      </form>
    </div>
  );
};

export default AddProject;
