import { instance as axios } from './axiosInstance';

const createProject = async (data) => axios.post('/projects', data);
const deleteProject = async (id) => axios.delete(`/projects/${id}`);
const patchProject = async (id, data) => axios.patch(`/projects/${id}`, data);

const getProjects = async () => axios.get('/projects');

export { createProject, deleteProject, patchProject, getProjects };
