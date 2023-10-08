"use client";
import React, { useState } from "react";
import Details from "../../../_components/projects/Details";
import Contributers from "../../../_components/projects/Contributers";
import ChatModal from "../../../_components/ChatModal";
import { BsFillChatLeftFill } from "react-icons/bs";

const project = {
  id: 2,
  title: "Proje 1",
  description:
    "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cum eius accusantium laborum quae neque tenetur nisi perspiciatis labore  distinctio enim voluptatum iusto, sapiente quo ipsam at esse aperiam, saepe corporis explicabo odit corrupti voluptate perferendis. Voluptas consequuntur voluptatibus excepturi amet aperiam autem quas repellat ipsam omnis? Molestias laboriosam velit sunt tempora eaque nemoß doloremque a nulla, saepe cum rem repellat minus fugiat numquam iusto perferendis nostrum adipisci. Possimus fugiat voluptates perferendis repellendus. Recusandae harum omnis, asperiores vero odio tenetur quo, Lorem, ipsum dolor sit amet consectetur adipisicing elit. Cum eius accusantium laborum quae neque tenetur nisi perspiciatis labore  distinctio enim voluptatum iusto, sapiente quo ipsam at esse aperiam, saepe corporis explicabo odit corrupti voluptate perferendis. Voluptas consequuntur voluptatibus excepturi amet aperiam autem quas repellat ipsam omnis? Molestias laboriosam velit sunt tempora eaque nemoß doloremque a nulla, saepe cum rem repellat minus fugiat numquam iusto perferendis nostrum adipisci. Possimus fugiat voluptates perferendis repellendus. Recusandae harum omnis, asperiores vero odio tenetur quo",
  owner: "John Uysal",
  contributers: ["Jane Karyagdi", "Alice Demir"],
  projectURL: "https://github.com",
  geographicScope: "Istanbul",
  projectStatus: "Active - not recruiting volunteers",
  startDate: "2021-10-10",
  projectContact: "Wade.L.Eakle@spd02.usace.army.com",
  sponsors: ["John Uysal", "Jane Karyagdi", "Alice Demir"],
  fieldsOfScience: ["Computer Science", "Mathematics"],
  intentedOutcomes: ["Software", "Hardware", "Civic"],
};

// const messages = [
//   { id: 1, text: "Merhaba, nasıl yardımcı olabilirim?", senderId: 1 },
//   { id: 2, text: "Selam! Bugün hava nasıl?", senderId: 2 },
//   { id: 1, text: "Hava oldukça güzel, teşekkür ederim!", senderId: 1 },
//   { id: 2, text: "Harika! Ne yapıyorsun?", senderId: 2 },
//   { id: 1, text: "Şu anda bir proje üzerinde çalışıyorum.", senderId: 1 },
//   { id: 1, text: "Sizde ne var? ", senderId: 1 },
//   {
//     id: 2,
//     text: "Ben de işle ilgileniyorum. Projeniz ne hakkında?",
//     senderId: 2,
//   },
//   {
//     id: 1,
//     text: "Web uygulamaları geliştiriyorum. Sizin projeniz neyle ilgili?",
//     senderId: 1,
//   },
//   {
//     id: 2,
//     text: "Mobil uygulama geliştiriyorum. İlgini çeker mi?",
//     senderId: 2,
//   },
//   {
//     id: 1,
//     text: "Mobil uygulamalar da harika! Hangi platformları kullanıyorsun?",
//     senderId: 1,
//   },
//   {
//     id: 2,
//     text: "Flutter kullanıyorum. Siz hangi dilleri tercih ediyorsunuz?",
//     senderId: 2,
//   },
//   {
//     id: 1,
//     text: "Ben genellikle JavaScript ve React kullanıyorum.",
//     senderId: 1,
//   },
//   {
//     id: 2,
//     text: "JavaScript harika bir dil. Hangi kütüphaneleri kullanıyorsunuz?",
//     senderId: 2,
//   },
//   {
//     id: 1,
//     text: "Özellikle Redux ve Axios gibi kütüphaneleri tercih ediyorum.",
//     senderId: 1,
//   },
//   {
//     id: 2,
//     text: "Redux harika bir durum yönetimi kütüphanesi. İyi bir seçim!",
//     senderId: 2,
//   },
// ];

const ProjectDetail = ({ params }) => {
  const [openChatModal, setOpenChatModal] = useState(false);

  console.log("oarams", params);

  const supportProject = () => {
    console.log("support project");
  };

  return (
    <div className="py-[180px] font-light min-h-screen">
      <div className="flex gap-10 mb-10">
        <div className="w-[350px] h-[350px] bg-white shadow-lg">
          <img
            src="/assets/placeholder-project.png"
            className="w-full h-full object-contain"
            alt=""
          />
        </div>
        <div className="flex flex-col flex-1 gap-2">
          <div className="flex items-center justify-between w-full">
            <span className="text-4xl font-extrabold text-title">
              {project.title}
            </span>
            <button
              type="button"
              className="bg-white text-navbar border border-navbar hover:text-white hover:bg-navbar py-2 px-3 transition-all duration-200 rounded font-bold"
              onClick={() => supportProject()}
            >
              Support Request for Project
            </button>
          </div>
          <span className="text-base text-justify">{project.description}</span>
        </div>
      </div>
      <Details project={project} />
      <Contributers project={project} />
      {openChatModal ? (
        <ChatModal
          closeModal={() => setOpenChatModal(false)}
          projectId={project.id}
        />
      ) : null}
      <div className="fixed bottom-5 right-5 rounded-full bg-navbar text-white flex justify-center items-center h-14 w-14">
        <BsFillChatLeftFill
          className="text-xl cursor-pointer"
          onClick={() => setOpenChatModal(true)}
        />
      </div>
    </div>
  );
};

export default ProjectDetail;
