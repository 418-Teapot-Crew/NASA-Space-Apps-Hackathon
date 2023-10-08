import { instance as axios } from "./axiosInstance";

const addInvite = (data) => axios.post("/api/Invites/add", data);
const getUserInvite = (userId, projectId) =>
  axios.get(
    `/api/Invites/getbyprojectidandcontributorid?projectId=${projectId}&contributor=${userId}`
  );
const getProjectInvite = (projectId) =>
  axios.get(`/api/Invites/getbyprojectid?projectId=${projectId}`);

const acceptInvite = (id) =>
  axios.put(`/api/Invites/update?id=${id}`, { status: true });

export { addInvite, getUserInvite, getProjectInvite, acceptInvite };
