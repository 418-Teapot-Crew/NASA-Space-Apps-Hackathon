"use client";
import React, { useState } from "react";

const profileObj = {
  fullname: "John Doe",
  description:
    "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Totam, perferendis id! Rerum perferendis iure et minus unde non recusandae ullam! Voluptate laboriosam reiciendis culpa quas reprehenderit nulla tempore quam id repudiandae? Maxime, exercitationem esse? Mollitia provident voluptatem harum recusandae fugit, debitis vel, modi consequuntur amet, delectus voluptas tenetur earum ducimus quod ipsum. Dolor quae numquam nam dicta libero modi, aspernatur culpa nemo! Earum similique natus esse et at, dolorem eligendi veniam accusantium reprehenderit! Rerum quos tenetur veniam quod illum accusantium! Asperiores quas suscipit reprehenderit rem dolor, sed laboriosam tempore, consequatur enim eius voluptates distinctio velit ex veritatis ut ab? Voluptatem illum tempora ab autem, consequuntur soluta mollitia id quisquam, repudiandae beatae quam sapiente odio alias in ratione vel, consectetur aut aperiam obcaecati harum quis nemo! Recusandae, dolores. Perspiciatis odit adipisci at! Minus ipsum repellat quis hic quaerat fuga quod aliquam porro architecto, sed repudiandae sapiente ab corporis est pariatur quibusdam odio, ut ipsam assumenda possimus dicta cumque! Quis facilis harum tempora! Cupiditate accusamus dolore repellendus ex, officiis enim, totam veniam iste possimus eligendi voluptatum, iure mollitia? Optio nostrum minima dignissimos aliquid dolore, laboriosam illo. Ullam ratione dignissimos inventore beatae quis explicabo laboriosam corrupti, doloribus eos ut minus cum expedita autem.",
  email: "johndoe@example.com",
};

const Profile = () => {
  const [profile, setProfile] = useState(profileObj);

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
