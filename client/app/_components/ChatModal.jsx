"use client";
import React, { useState } from "react";
import { RxCross1 } from "react-icons/rx";
import { BsSendFill } from "react-icons/bs";

const ChatModal = ({ closeModal, messages }) => {
  const [message, setMessage] = useState("");

  const handleSendMessage = () => {
    console.log(message);
    setMessage("");
  };

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
          {messages.map((message) => (
            <div
              key={message.id}
              className={`flex gap-3 items-center px-5 py-3 ${
                message.senderId === 1 ? "justify-end" : "justify-start"
              }`}
            >
              <div
                className={`${
                  message.senderId === 1
                    ? "bg-blue-600 text-white rounded-tl rounded-br"
                    : "bg-white text-black rounded-tr rounded-bl"
                } px-3 py-2`}
              >
                {message.text}
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
