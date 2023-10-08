"use client";
import React, { useEffect, useState } from "react";
import { getUser } from "../../_api/user";

const Profile = () => {
  const [profile, setProfile] = useState({});

  useEffect(() => {
    getUser().then((res) => setProfile(res.data.data));
  }, []);

  const handleSubmit = () => {
    console.log(profile);
  };

  return (
    <div className="flex-1 flex flex-col gap-3  self-start">
      <input
        type="text"
        placeholder="Fullname"
        className="py-2 px-4 outline-none w-full border border-slate-700 rounded"
        value={profile.fullname}
        onChange={(e) => setProfile({ ...profile, fullname: e.target.value })}
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

      <button className="w-full bg-navbar text-white text-center py-2 rounded">
        Upload CV
      </button>
      <button
        className="w-full bg-navbar text-white text-center py-2 rounded"
        type="button"
        onClick={() => handleSubmit()}
      >
        Submit
      </button>
    </div>
  );
};

export default Profile;
