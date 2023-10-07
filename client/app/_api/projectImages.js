import { instance as axios } from "./axiosInstance";

const postImage = () => axios.post("/project-images");

export { postImage };
