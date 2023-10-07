import { instance as axios } from './axiosInstance';

const authLogin = (data) => axios.post('/auth', data);

export { authLogin };
