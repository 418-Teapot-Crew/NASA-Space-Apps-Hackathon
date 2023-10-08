import { instance as axios } from "./axiosInstance";

const createProject = async (data) => axios.post("/api/Projects/add", data);
const deleteProject = async (id) => axios.delete(`/projects/${id}`);
const patchProject = async (id, data) => axios.patch(`/projects/${id}`, data);
const getMessages = async (projectId) =>
  axios.get(`/api/projects/getMessages/${projectId}`);

const getProjects = async () => axios.get("/api/Projects/getall");
const getProject = async (id) => axios.get("/api/Projects/getbyid?id=" + id);

<<<<<<< HEAD
const getByUserId = async (id) =>
  axios.get("/api/Projects/getbyuserid?userId=" + id);

export {
  createProject,
  deleteProject,
  patchProject,
  getProjects,
  getProject,
  getByUserId,
};
=======
export { createProject, deleteProject, patchProject, getProjects, getProject, getMessages };
>>>>>>> d1044965f44b4b2e56c17ca08a3eec58e3635762
