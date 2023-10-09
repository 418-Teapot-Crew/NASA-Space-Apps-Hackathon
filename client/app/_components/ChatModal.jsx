"use client";
import React, { useEffect, useState } from "react";
import { RxCross1 } from "react-icons/rx";
import { BsSendFill } from "react-icons/bs";
import * as signalR from "@microsoft/signalr";
import { getMessages } from "../_api/projects";

const messagesArray = [
  {
    sender_id: 1,
    message:
      "Hello! Welcome to our website. I noticed that you're interested in supporting our scientific project. How can I assist you?",
  },
  {
    sender_id: 2,
    message:
      "Hello! I've been looking into your projects, and they really caught my attention. I'd like to learn more about how I can support them.",
  },
  {
    sender_id: 1,
    message:
      "Thank you for your interest! What area of our projects are you interested in? Biology, physics, chemistry, or another field?",
  },
  {
    sender_id: 2,
    message:
      "Biology is quite fascinating to me. Could you provide more information about your biology projects?",
  },
  {
    sender_id: 1,
    message:
      "Certainly! Here are a few of our biology projects: 1. Genetic Research 2. Ecosystem Studies 3. Biomedical Engineering Projects. Which one would you like to explore further?",
  },
  {
    sender_id: 2,
    message:
      "Genetic research looks really interesting. How can I contribute to this project?",
  },
  {
    sender_id: 1,
    message:
      "Great choice! There are several ways you can contribute to our genetic research project. You can make a donation, participate in laboratory experiments, or share your expertise in data analysis. Could you please tell me more about how you'd like to contribute?",
  },
  {
    sender_id: 2,
    message:
      "I'd like to participate in laboratory experiments. How can I apply for that?",
  },
  {
    sender_id: 1,
    message:
      "Excellent! To participate in laboratory experiments, you'll need to fill out an application form first.",
  },
];

const ChatModal = ({ closeModal, projectId }) => {
  const [messages, setMessages] = useState(messagesArray);
  const [message, setMessage] = useState("");
  /*   useEffect(() => {
    getMessages(projectId).then((data) => {
      console.log("data.data.data", data.data.data);
      setMessages(data.data.data);
    });
  }, [projectId]);

  let signalRConnection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:44364/chatHub", {
      accessTokenFactory: () => {
        return localStorage.getItem("token");
      },
    })
    .build();

  signalRConnection.on("ChatChannel", function (message) {
    setMessages([...messages, { message: message, mine: false }]);
  });

  signalRConnection
    .start()
    .then(function () {})
    .catch(function (err) {
      return console.error("signal hata", err.toString());
    });

  const handleSendMessage = () => {
    signalRConnection.invoke("SendMessage", message, projectId);
    setMessages([...messages, { message: message, mine: true }]);
    setMessage("");
  }; */

  return (
    <div className="fixed top-0 left-0 z-[100] bg-black bg-opacity-30 w-full h-full flex justify-center items-center">
      <div className="bg-white w-1/2 h-[550px] rounded flex flex-col">
        <div className="flex justify-end px-5 py-3 border-b-2">
          <RxCross1
            className="text-xl text-black cursor-pointer"
            onClick={() => closeModal()}
          />
        </div>
        <div className="flex-1  bg-gray-100 overflow-y-scroll flex flex-col">
          {messages?.map((message) => (
            <div
              key={message.id}
              className={`flex gap-3 items-center px-5 py-3 ${
                message.sender_id === 2 ? "justify-end" : "justify-start"
              }`}
            >
              <div
                className={`${
                  message.sender_id === 1
                    ? "bg-blue-600 text-white rounded-tl rounded-br"
                    : "bg-white text-black rounded-tr rounded-bl"
                } px-3 py-2`}
              >
                {message.message}
              </div>
            </div>
          ))}
        </div>
        <div className="border-t-2 flex justify-between items-center gap-3 rounded-b">
          <input
            type="text"
            value={message}
            className="py-2 outline-none px-4 flex-1"
            placeholder="Type a message"
            onChange={(e) => setMessage(e.target.value)}
          />
          <div className="bg-navbar h-full px-3 flex items-center justify-center rounded-br">
            <BsSendFill
              className="text-xl  text-white  cursor-pointer"
              onClick={() => handleSendMessage()}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default ChatModal;
