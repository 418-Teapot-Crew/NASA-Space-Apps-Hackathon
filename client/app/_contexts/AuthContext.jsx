"use client";
import { useReducer, createContext, useContext } from "react";
import jwtDecode from "jwt-decode";

export const INITIAL_STATE = {
  isLoggedIn: JSON.parse(localStorage.getItem("isLoggedIn")) || false,
  user: JSON.parse(localStorage.getItem("user")) || null,
  client_id: process.env.NEXT_PUBLIC_CLIENT_ID,
  redirect_uri: process.env.NEXT_PUBLIC_REDIRECT_URI,
  client_secret: process.env.NEXT_PUBLIC_CLIENT_SECRET,
  proxy_url: process.env.NEXT_PUBLIC_PROXY_URL,
  google_client_secret: process.env.NEXT_PUBLIC_GOOGLE_CLIENT_SECRET,
  google_client_id: process.env.NEXT_PUBLIC_GOOGLE_CLIENT_ID,
};

const AuthContext = createContext({
  state: INITIAL_STATE,
  dispatch: () => {},
});

export const reducer = (state, action) => {
  switch (action.type) {
    case "LOGIN": {
      localStorage.setItem(
        "isLoggedIn",
        JSON.stringify(action.payload.isLoggedIn)
      );
      localStorage.setItem(
        "token",
        action?.payload?.token
      );
      const user = jwtDecode(action?.payload?.token);
      const userObj = {
        id: user[
          "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
        ],
        email: user.email,
        fullName:
          user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
      };
      localStorage.setItem("user", JSON.stringify(userObj));
      return {
        ...state,
        user: userObj,
        isLoggedIn: action.payload.isLoggedIn,
      };
    }
    case "LOGOUT": {
      localStorage.clear();
      return {
        ...state,
        isLoggedIn: false,
        user: null,
      };
    }
    default:
      return state;
  }
};

export const AuthProvider = ({ children }) => {
  const [state, dispatch] = useReducer(reducer, INITIAL_STATE);

  return (
    <AuthContext.Provider value={{ state, dispatch }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuthContext = () => useContext(AuthContext);
