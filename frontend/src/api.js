const api_url = 'http://127.0.0.1:5115/api/'

import axios from 'axios'

const ACCESS_TOKEN_KEY = 'accessToken'
const REFRESH_TOKEN_KEY = 'refreshToken'

const ax = axios.create({
  baseURL: api_url,
  timeout: 5000,
  headers: {
    'X-Custom-Header': 'foobar',
    'Access-Control-Allow-Origin': '*',
  },
})

ax.interceptors.request.use(function (config) {
  const token = localStorage.getItem(ACCESS_TOKEN_KEY)
  if (token) {
    config.headers.Authorization = 'Bearer ' + token
  }
  return config
})

// axios.interceptors.response.use(function (config) {
//   if(config.status = 401) {
//
//   }
//
//   // const token = localStorage.getItem('token')
//   // if (token) {
//   //   config.headers.Authorization = 'Bearer ' + token
//   // }
//   // return config
// })

ax.interceptors.response.use(
  response => response, // Directly return successful responses.
  async error => {
    const originalRequest = error.config;
    if (error.response.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true; // Mark the request as retried to avoid infinite loops.
      try {
        const refreshToken = localStorage.getItem(REFRESH_TOKEN_KEY); // Retrieve the stored refresh token.
        // Make a request to your auth server to refresh the token.
        const response = await axios.post( '/authentication/refresh', {
          refreshToken,
        });
        const { accessToken, refreshToken: newRefreshToken } = response.data;
        // Store the new access and refresh tokens.
        localStorage.setItem(ACCESS_TOKEN_KEY, accessToken);
        localStorage.setItem(REFRESH_TOKEN_KEY, newRefreshToken);
        // Update the authorization header with the new access token.
        ax.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
        return ax(originalRequest); // Retry the original request with the new access token.
      } catch (refreshError) {
        // Handle refresh token errors by clearing stored tokens and redirecting to the login page.
        console.error('Token refresh failed:', refreshError);
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
        window.location.href = '/login';
        return Promise.reject(refreshError);
      }
    }
    return Promise.reject(error); // For all other errors, return the error as is.
  }
);

const parseError = (error) => {
  //console.log(error)
  const errorMessage = error.response?.data?.message ?? "Unknown error"
  return errorMessage;
}

const post = async (url, data) => {
  let result = false
  await ax
    .post(url, data)
    .then((response) => {
      console.log(response)
      result = { success: true }
    })
    .catch((error) => {
      console.log(error)

      result = { message: "", success: false }
    })

  return result
}

export const API = {
  IsLoggedIn: () => {
    console.log('IsLoggedIn')
    return !!localStorage.getItem(ACCESS_TOKEN_KEY)
  },
  LogIn: async (email, password) => {
    let result = false
    await ax
      .post('/authentication/login', {
        email: email,
        password: password,
      })
      .then((response) => {
        console.log(response)
        localStorage.setItem(ACCESS_TOKEN_KEY, response.data.data["access_token"]);
        localStorage.setItem(REFRESH_TOKEN_KEY, response.data.data["refresh_token"]);
        result = { success: response.data.success }
      })
      .catch((error) => {
        result = { message: parseError(error), success: false }
      })

    return result
  },
  SignUp: async (email, password) => {
    return await post('/authentication/register', { email, password})
  },
}

export default API
