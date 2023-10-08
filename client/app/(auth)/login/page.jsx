"use client";
import { useRouter } from "next/navigation";
import React, { useEffect, useState } from "react";
import { toast } from "react-hot-toast";
import { AiFillGithub } from "react-icons/ai";
import Link from "next/link";
import { useAuthContext } from "../../_contexts/AuthContext";
import { useGoogleLogin } from "@react-oauth/google";
import { FcGoogle } from "react-icons/fc";
import { authLogin } from "../../_api/auth";

const custom_input =
  "py-2 text-sm text-slate-900 placeholder-slate-600 shadow-md border bg-gray-200 rounded-md px-3   focus:outline-none focus:ring-1";

const Login = () => {
  const [formData, setFormData] = useState({});
  const { state, dispatch } = useAuthContext();
  const [data, setData] = useState({ errorMessage: "", isLoading: false });

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
      const response = await authLogin(formData);
      dispatch({
        type: "LOGIN",
        payload: { token: response?.data?.token, isLoggedIn: true },
      });
      router.push("/");
    } catch (err) {
      console.log(err);
    }

    // router.push("/");
  };

  const { client_id, redirect_uri } = state;

  useEffect(() => {
    // After requesting Github access, Github redirects back to your app with a code parameter
    const url = window.location.href;
    const hasCode = url.includes("?code=");
    console.log("hello 1");

    // If Github API returns the code parameter
    if (hasCode) {
      console.log("hello 2");
      const newUrl = url.split("?code=");
      window.history.pushState({}, null, newUrl[0]);
      setData({ ...data, isLoading: true });

      const requestData = {
        code: newUrl[1],
      };

      const proxy_url = state.proxy_url;

      // Use code parameter and other parameters to make POST request to proxy_server
      fetch(proxy_url, {
        method: "POST",
        body: JSON.stringify(requestData),
      })
        .then((response) => response.json())
        .then((data) => {
          dispatch({
            type: "LOGIN",
            payload: { user: data, isLoggedIn: true },
          });
          // router.push()
        })
        .catch((error) => {
          setData({
            isLoading: false,
            errorMessage: "Sorry! Login failed",
          });
        });
    }
  }, [state, dispatch, data]);

  if (state.isLoggedIn) {
    router.push("/");
  }

  const loginGoogle = useGoogleLogin({
    onSuccess: (codeResponse) => console.log(codeResponse),
    onError: () => {
      console.log("Login Failed");
    },
    flow: "auth-code",
  });

  return (
    <div className="flex flex-col justify-center gap-2 w-2/3">
      <Link
        className="absolute bg-navbar text-sm text-white rounded-md right-7 top-7 font-light border shadow-lg px-4 py-2"
        href={"/signup"}
      >
        Sign Up
      </Link>

      <h1 className="m-0 font-thin self-center text-2xl">
        <i>Let's</i> Explore Open Science Together
      </h1>

      <div className="flex flex-col w-full">
        <form
          onSubmit={handleSubmit}
          className="flex  rounded-md  p-4  gap-4 w-full  flex-col"
          action=""
        >
          <input
            type="text"
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
            className="bg-[#18181B] w-full text-white py-2 text-sm font-light rounded tracking-wider"
            type="submit"
          >
            Login
          </button>

          <div className="border-b border-gray-400 relative text-center my-3">
            <span className="bg-white px-2 text-gray-400 text-sm  absolute -translate-x-1/2 -translate-y-1/2 tracking-wider">
              OR CONTINUE WITH
            </span>
          </div>

          <button
            type="button"
            className="bg-white w-full text-black shadow-xl border py-2 text-sm font-light rounded flex gap-1 items-center justify-center tracking-wider"
            onClick={() => loginGoogle()}
          >
            <FcGoogle className="text-xl" /> Google
          </button>

          {data.isLoading ? (
            <div
              className="bg-white w-full text-black shadow-xl border py-2 text-sm font-light rounded flex gap-1 items-center justify-center tracking-wider"
              type="button"
            >
              Loading
            </div>
          ) : (
            <a
              className="bg-white w-full text-black shadow-xl border py-2 text-sm font-light rounded flex gap-1 items-center justify-center tracking-wider"
              type="button"
              href={`https://github.com/login/oauth/authorize?scope=user&client_id=${client_id}&redirect_uri=${redirect_uri}`}
              onClick={() => {
                setData({ ...data, errorMessage: "" });
              }}
            >
              <AiFillGithub className="text-xl" /> Github
            </a>
          )}
        </form>
        <div />
      </div>
    </div>
  );
};

export default Login;
