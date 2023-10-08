"use client";
import React, { useEffect, useState } from "react";
import { getUser, putUser } from "../../_api/user";
import { useAuthContext } from "../../_contexts/AuthContext";
import FileUpload from "../../_components/FileUpload";
import ParticleBg from "../../_components/ParticleBg";

const Profile = () => {
  const [profile, setProfile] = useState({
    firstName: "",
    lastName: "",
    email: "",
    description: "",
  });
  const { state } = useAuthContext();

  console.log(profile);

  const fetchProfile = async () => {
    try {
      const res = await getUser(state?.user?.id);
      console.log("res data", res.data);
      setProfile({
        firstName: res.data.data.firstName,
        lastName: res.data.data.lastName,
        email: res.data.data.email,
        description: res.data.data.description,
      });
    } catch (e) {
      console.log(e);
    }
  };

  useEffect(() => {
    fetchProfile();
  }, []);

  const handleSubmit = async () => {
    try {
      const res = await putUser(state?.user?.id, profile);
      if (res.success)
        setProfile({
          firstName: res.data.data.firstName,
          lastName: res.data.data.lastName,
          email: res.data.data.email,
          description: res.data.data.description,
        });
    } catch (e) {
      console.log(e);
    }
  };

  const setDescription = (description) => {
    console.log("description", description);
    setProfile({ ...profile, description });
  };

  return (
    <div className="flex-1 flex flex-col gap-3  self-start">
      <ParticleBg />
      <input
        type="text"
        placeholder="First Name"
        className="py-2 px-4 outline-none w-full border border-slate-700 rounded"
        value={profile.firstName}
        onChange={(e) => setProfile({ ...profile, firstName: e.target.value })}
      />
      <input
        type="text"
        placeholder="Last Name"
        className="py-2 px-4 outline-none w-full border border-slate-700 rounded"
        value={profile.lastName}
        onChange={(e) => setProfile({ ...profile, lastName: e.target.value })}
      />

      <input
        type="text"
        placeholder="Email"
        className="py-2 px-4 outline-none w-full border border-slate-700 rounded"
        value={profile.email}
        onChange={(e) => setProfile({ ...profile, email: e.target.value })}
      />

      <textarea
        name="desc"
        id="desc"
        value={profile.description}
        className="py-2 px-4 outline-none w-full border border-slate-700 rounded"
        onChange={(e) =>
          setProfile({ ...profile, description: e.target.value })
        }
        cols="30"
        rows="10"
      ></textarea>

      <FileUpload setDescription={setDescription} />
      <button
        className="w-full bg-navbar text-white text-center py-2 rounded"
        type="button"
        onClick={() => handleSubmit()}
      >
        Save Profile
      </button>
    </div>
  );
};

export default Profile;
