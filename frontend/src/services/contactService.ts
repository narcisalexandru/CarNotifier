import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:64424/api',
    withCredentials: false,
    headers: {
        'Content-Type': 'application/json',
    },
});

interface ContactData {
    fullName: string;
    email: string;
    subject: string;
    message: string;
}

export const sendContactMessage = async (contactData: ContactData) => {
    try {
        const response = await apiClient.post('/contact', contactData);
        return response.data;
    } catch (error) {
        console.error('Error sending contact message: ', error);
        throw error;
    }
};
