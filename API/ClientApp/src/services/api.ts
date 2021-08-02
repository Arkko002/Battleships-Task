import axios, { AxiosError } from "axios";

const instance = axios.create({
  baseURL: "http://localhost:5000",
  responseType: "json",
});

instance.interceptors.response.use(
  function (res) {
    return res;
  },
  function (err: AxiosError) {
    console.error(err.message);

    return Promise.reject(err);
  }
);

export default instance;

