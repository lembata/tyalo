//const api_url = 'http://127.0.0.1:5115/api/'
const api_url = '/api/'

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

ax.interceptors.response.use(
  async (response) => {
    return response; // Directly return successful responses.
  },
  async (error) => {
    const originalRequest = error.config
    if (error.response.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true // Mark the request as retried to avoid infinite loops.
      try {
        const refreshToken = localStorage.getItem(REFRESH_TOKEN_KEY) // Retrieve the stored refresh token.
        // Make a request to your auth server to refresh the token.
        const response = await axios.post('/authentication/refresh', {
          refreshToken,
        })
        const { accessToken, refreshToken: newRefreshToken } = response.data
        // Store the new access and refresh tokens.
        localStorage.setItem(ACCESS_TOKEN_KEY, accessToken)
        localStorage.setItem(REFRESH_TOKEN_KEY, newRefreshToken)
        // Update the authorization header with the new access token.
        ax.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`
        return ax(originalRequest) // Retry the original request with the new access token.
      } catch (refreshError) {
        // Handle refresh token errors by clearing stored tokens and redirecting to the login page.
        console.error('Token refresh failed:', refreshError)
        localStorage.removeItem('accessToken')
        localStorage.removeItem('refreshToken')
        window.location.href = '/login'
        return Promise.reject(refreshError)
      }
    }
    return Promise.reject(error) // For all other errors, return the error as is.
  },
)

const parseError = (error) => {
  //console.log(error)
  const errorMessage = error.response?.data?.message ?? 'Unknown error'
  return errorMessage
}

const get = async (url, config) => {
  let result = false
  await ax
    .get(url, config)
    .then((response) => {
      // console.log(response)
      result = {
        success: response.data.success,
        data: response.data.data,
        message: response.data.message
      }
    })
    .catch((error) => {
      //console.log(error)
      result = {
        message: parseError(error),
        success: false
      }
    })

  return result
}

const del = async (url, config) => {
  let result = false
  await ax
    .delete(url, config)
    .then((response) => {
      console.log(response)
      result = { success: true }
    })
    .catch((error) => {
      console.log(error)
      result = { message: parseError(error), success: false }
    })

  return result
}

const post = async (url, data, config) => {
  let result = false
  await ax
    .post(url, data, config)
    .then((response) => {
      console.log(response)
      result = { success: true }
    })
    .catch((error) => {
      console.log(error)

      result = { message: parseError(error), success: false }
    })

  return result
}

const put = async (url, data, config) => {
  let result = false
  await ax
    .put(url, data, config)
    .then((response) => {
      console.log(response)
      result = { success: true }
    })
    .catch((error) => {
      console.log(error)

      result = { message: parseError(error), success: false }
    })

  return result
}

const patch = async (url, data, config) => {
  let result = false
  await ax
    .patch(url, data, config)
    .then((response) => {
      console.log(response)
      result = { success: true }
    })
    .catch((error) => {
      console.log(error)

      result = { message: parseError(error), success: false }
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
        localStorage.setItem(ACCESS_TOKEN_KEY, response.data.data['access_token'])
        localStorage.setItem(REFRESH_TOKEN_KEY, response.data.data['refresh_token'])
        result = { success: response.data.success }
      })
      .catch((error) => {
        result = { message: parseError(error), success: false }
      })

    return result
  },
  LogOut: async () => {
    const refreshToken = localStorage.getItem(REFRESH_TOKEN_KEY)
    localStorage.setItem(REFRESH_TOKEN_KEY, null)
    localStorage.setItem(REFRESH_TOKEN_KEY, null)

    if (!refreshToken) {
      return { success: true }
    }

    return await post('/authentication/logout', null, {
      params: {
        refreshToken: localStorage.getItem(REFRESH_TOKEN_KEY),
      },
    })
  },
  SignUp: async (email, password) => {
    return await post('/authentication/register', { email, password })
  },
  Settings: {
    Get: async () => {
      return await get('/settings')
    },
    Update: async (settings) => {
      return await patch('/settings', settings)
    },
  }
}

export default API
