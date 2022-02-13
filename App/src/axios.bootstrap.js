import axios from 'axios';

const axiosConfiguration = {
    baseURL: "https://localhost:44385/api",
}

const http = axios.create(axiosConfiguration);

export default http;