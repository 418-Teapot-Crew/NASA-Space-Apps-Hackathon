import { instance as axios } from "./axiosInstance";

const addInvite = (data) => axios.post("/api/Invites/add", data);
const getUserInvite = (userId, projectId) =>
  axios.get(
    `/api/Invites/getbyprojectidandcontributorid?projectId=${projectId}&contributor=${userId}`
  );

export { addInvite, getUserInvite };
