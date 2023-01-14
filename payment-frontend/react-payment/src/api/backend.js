import axios from "axios";

export default axios.create({
    baseURL: "http://localhost:49988/api"
})