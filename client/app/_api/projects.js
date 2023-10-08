import { instance as axios } from "./axiosInstance";

const createProject = async (data) => axios.post("/api/Projects/add", data);
const deleteProject = async (id) => axios.delete(`/projects/${id}`);
const patchProject = async (id, data) => axios.patch(`/projects/${id}`, data);

const getProjects = async () => axios.get("/api/Projects/getall");
const getProject = async (id) => axios.get("/api/Projects/getbyid?id=" + id);

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
