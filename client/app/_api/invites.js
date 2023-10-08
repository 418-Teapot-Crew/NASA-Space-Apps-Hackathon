import { instance as axios } from "./axiosInstance";

const addInvite = (data) => axios.post("/api/Invites/add", data);

export { addInvite };
