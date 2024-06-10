import axios from 'axios';

const apiClient = axios.create({
  baseURL: 'https://localhost:7254/api',
  withCredentials: false,
  headers: {
    'Content-Type': 'application/json'
  }
});

export default {
  getRegistrations() {
    return apiClient.get('/registration');
  },
  registerCar(registration: any) {
    return apiClient.post('/registration', registration);
  }
};
