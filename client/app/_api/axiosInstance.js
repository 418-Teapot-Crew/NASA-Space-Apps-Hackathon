import axios from 'axios';
import { toast } from 'react-hot-toast';

export const baseURL = 'http://localhost:4000';
console.log('baseURL', baseURL);

const instance = axios.create({
  baseURL,
});

instance.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (config.method !== 'get') {
    const loadingToastId = toast.loading('Loading...');
    config.__loadingToastId = loadingToastId;
  }
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

instance.interceptors.response.use(
  (response) => {
    if (response.status >= 200 && response.status < 300) {
      if (response.config.method !== 'get') {
        toast.success(response.data?.message, {
          id: response.config.__loadingToastId,
        });
      }
    }
    return response;
  },

  (error) => {
    if (error?.response?.status === 401) {
      toast.error('Oturumunuz sona erdi. Lütfen tekrar giriş yapın.', {
        id: error.config.__loadingToastId,
      });
    }
    try {
      toast.error(error?.response?.data?.message, {
        id: error.config.__loadingToastId,
      });
    } catch (e) {
      toast.error('An Error Encourred', {
        id: error.config.__loadingToastId,
      });
    }
    return error;
  }
);

const fetcher = (url) => instance.get(url).then((res) => res.data);

export { instance, fetcher };
