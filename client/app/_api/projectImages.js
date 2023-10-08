import { instance as axios } from "./axiosInstance";

const addFile = (id, values) =>
  axios.post(`/api/ProjectFiles/upload/${id}`, values);

export { addFile };
