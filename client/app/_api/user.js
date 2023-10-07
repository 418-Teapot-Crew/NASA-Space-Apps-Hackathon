import { instance as axios } from './axiosInstance';

const createUser = async (data) => axios.post('/users', data);
const deleteUser = async (id) => axios.delete(`/users/${id}`);
const patchUser = async (id, data) => axios.patch(`/users/${id}`, data);

const getUsers = async () => axios.get('/users');

export { createUser, deleteUser, patchUser, getUsers };
