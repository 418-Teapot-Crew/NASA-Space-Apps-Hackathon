import { instance as axios } from './axiosInstance';

const authLogin = (data) => axios.post('/api/Auth/login', data);

export { authLogin };
