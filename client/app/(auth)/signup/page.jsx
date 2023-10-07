"use client";
import { useRouter } from "next/navigation";
import React, { useEffect, useState } from "react";
import { toast } from "react-hot-toast";
import { AiFillGithub } from "react-icons/ai";
import Link from "next/link";
import { useAuthContext } from "../../_contexts/AuthContext";
import { createUser } from "../../_api/user";

const custom_input =
  "py-2 text-sm text-slate-900 placeholder-slate-600 shadow-md border bg-gray-200 rounded-md px-3   focus:outline-none focus:ring-1";

const Signup = () => {
  const [formData, setFormData] = useState({});
  const { state, dispatch } = useAuthContext();
  const router = useRouter();

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await createUser(formData);
      router.push("/login");
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="flex flex-col justify-center gap-1 w-2/3">
      <Link
        className="absolute bg-black text-sm text-white rounded-md right-7 top-7 font-light border shadow-lg px-4 py-2"
        href={"/login"}
      >
        Login
      </Link>
      <h2 className="text-2xl font-medium text-center tracking-wide">
        Create an account
      </h2>
      <p className="font-light opacity-50 text-center tracking-wide">
        Enter your credentials below to create your account
      </p>

      <div className="flex flex-col">
        <form
          onSubmit={handleSubmit}
          className="flex  rounded-md  p-4  gap-4 w-full  flex-col"
          action=""
        >
          <input
            type="text"
            name="firstName"
            className={custom_input}
            placeholder="First name"
            onChange={handleChange}
            autoComplete="off"
          />
          <input
            type="text"
            name="lastName"
            className={custom_input}
            placeholder="Last name"
            onChange={handleChange}
            autoComplete="off"
          />
          <input
            type="email"
            name="email"
            className={custom_input}
            placeholder="Email"
            onChange={handleChange}
            autoComplete="off"
          />
          <input
            type="password"
            name="password"
            className={custom_input}
            placeholder="Password"
            onChange={handleChange}
            autoComplete="off"
          />

          <button
            className="bg-[#18181B] w-full text-white py-2 text-sm font-light rounded tracking-wide"
            type="submit"
          >
            Create
          </button>
        </form>
      </div>
    </div>
  );
};

export default Signup;
