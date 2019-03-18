import axios from 'axios';
import { API_URL } from '@/Configs.js';

function loginUser({ email, password }, onSuccess, onFailure) {
  axios.post(`${API_URL}session/login`, {
    data: {
       email,
      password
    }
  })
  .then(({ data }) => onSuccess(data.token))
  .catch(err => onFailure(err))
}

export default {
  loginUser
}