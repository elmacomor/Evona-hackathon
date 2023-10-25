import axios from "axios";
import { BASE_URL } from "./constants";

axios.defaults.baseURL = BASE_URL;
axios.defaults.headers.common["Content-Type"] = "application/json";


export default axios;