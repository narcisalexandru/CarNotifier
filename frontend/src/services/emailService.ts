import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:64424/api',
    withCredentials: false,
    headers: {
        'Content-Type': 'application/json',
    },
});

interface CarData {
    fullName: string;
    email: string;
    licensePlate: string;
    service: string;
    expiryDate: string | null;
}

export const registerCar = async (carData: CarData) => {
    try {
        const response = await apiClient.post('/registration', carData);
        return response.data;
    } catch (error) {
        console.error('Error registering car: ', error);
        throw error;
    }
};
