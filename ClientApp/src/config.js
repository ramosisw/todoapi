const development = !process.env.NODE_ENV || process.env.NODE_ENV === 'development';
const api_endpoint = "api";
const apiUrlPro = "/";
const apiUrlDev = "http://192.168.12.11:1080/";

export const config = {
    development,
    homePath: development ? "" : "",
    apiUrl: (development ? apiUrlDev : apiUrlPro) + api_endpoint,
};
