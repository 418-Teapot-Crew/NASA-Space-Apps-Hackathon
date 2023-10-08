"use client";
import React, { useState } from "react";
import toast from "react-hot-toast";
import axios from "axios";

function FileUpload() {
  const [selectedFile, setSelectedFile] = useState(null);

  const handleFileChange = (e) => {
    setSelectedFile(e.target.files[0]);
  };

  const handleFileUpload = async () => {
    if (!selectedFile) {
      toast.error("Please select a file.");
      return;
    }

    const formData = new FormData();
    formData.append("file", selectedFile);

    try {
      const response = await axios.post(
        "https://multicoloredroundcad.uysalibov.repl.co/resume",
        {
          Headers: {
            "Content-Type": "multipart/form-data",
          },
        },
        formData
      );

      if (response.ok) {
        toast.success("CV uploaded successfully.");
      } else {
        toast.error("CV upload failed.");
      }
    } catch (error) {
      console.error("Error encourred:", error);
    }
  };

  return (
    <div className="flex items-center gap-3 w-full">
      <label
        htmlFor="file-upload"
        className="bg-slate-700 hover:bg-slate-900 text-white py-2 px-4 rounded cursor-pointer text-center"
      >
        Select File
      </label>
      <input
        type="file"
        id="file-upload"
        onChange={handleFileChange}
        className="hidden w-full" // Inputu gizleyin
      />
      <button
        onClick={handleFileUpload}
        className="bg-red-500 hover:bg-blood text-white py-2 px-4 rounded flex-1 cursor-pointer"
      >
        Upload CV
      </button>
    </div>
  );
}

export default FileUpload;
