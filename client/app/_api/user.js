import { instance as axios } from "./axiosInstance";

const createUser = async (data) => axios.post("/api/Auth/register", data);
const deleteUser = async (id) => axios.delete(`/users/${id}`);
const putUser = async (id, data) =>
  axios.put(`/api/Users/update?id=${id}`, data);

const getUsers = async () => axios.get("/api/Users/getall");

const getUser = async (id) => axios.get(`/api/Users/getbyid?id=${id}`);

/* const updateResume = async (formData) =>
  axios.post("https://multicoloredroundcad.uysalibov.repl.co/resume", formData); */

const getMockData = () => {
  return {
    users: [
      {
        id: 1,
        firstName: "John",
        lastName: "Doe",
        email: "john@example.com",
        projects: ["project1", "project2"],
      },
      {
        id: 2,
        firstName: "Jane",
        lastName: "Smith",
        email: "jane@example.com",
        projects: ["project3"],
      },
      {
        id: 3,
        firstName: "Alice",
        lastName: "Johnson",
        email: "alice@example.com",
        projects: ["project4", "project5"],
      },
      {
        id: 4,
        firstName: "Bob",
        lastName: "Brown",
        email: "bob@example.com",
        projects: [],
      },
      {
        id: 5,
        firstName: "Sarah",
        lastName: "Wilson",
        email: "sarah@example.com",
        projects: ["project6"],
      },
      {
        id: 6,
        firstName: "Michael",
        lastName: "Lee",
        email: "michael@example.com",
        projects: [],
      },
      {
        id: 7,
        firstName: "Emily",
        lastName: "Davis",
        email: "emily@example.com",
        projects: ["project7"],
      },
      {
        id: 8,
        firstName: "David",
        lastName: "Brown",
        email: "david@example.com",
        password: "********",
        projects: [],
      },
    ],
    projects: [
      {
        id: 1,
        title: "Proje 1",
        description: "Proje 1 Açıklama",
        owner: "John",
        contributers: ["Jane", "Alice"],
      },
      {
        id: 2,
        title: "Proje 2",
        description: "Proje 2 Açıklama",
        owner: "Alice",
        contributers: ["John"],
      },
      {
        id: 3,
        title: "Proje 3",
        description: "Proje 3 Açıklama",
        owner: "Jane",
        contributers: [],
      },
      {
        id: 4,
        title: "Proje 4",
        description: "Proje 4 Açıklama",
        owner: "Alice",
        contributers: [],
      },
      {
        id: 5,
        title: "Proje 5",
        description: "Proje 5 Açıklama",
        owner: "John",
        contributers: [],
      },
      {
        id: 6,
        title: "Proje 6",
        description: "Proje 6 Açıklama",
        owner: "Sarah",
        contributers: [],
      },
      {
        id: 7,
        title: "Proje 7",
        description: "Proje 7 Açıklama",
        owner: "Emily",
        contributers: [],
      },
      {
        id: 8,
        title: "Proje 8",
        description: "Proje 8 Açıklama",
        owner: "John",
        contributers: [],
      },
      {
        id: 9,
        title: "Proje 9",
        description: "Proje 9 Açıklama",
        owner: "David",
        contributers: [],
      },
      {
        id: 10,
        title: "Proje 10",
        description: "Proje 10 Açıklama",
        owner: "Jane",
        contributers: [],
      },
    ],
  };
};

export { createUser, deleteUser, getUsers, getUser, getMockData, putUser };
