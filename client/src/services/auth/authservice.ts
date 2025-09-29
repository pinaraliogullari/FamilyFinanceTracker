import axios from 'axios';
import { LoginCredentials, LoginResponse, RegisterCredentials, RegisterResponse, RegisterSchema,LoginSchema, LogoutResponse } from './authModels'
import { API_ENDPOINTS, BASE_API_URL } from '@/lib/config/api';

export const register = async (credentials: RegisterCredentials): Promise<RegisterResponse> => {

    RegisterSchema.parse(credentials); 

    const response = await axios.post<RegisterResponse>(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/register`, credentials);
    return response.data;
}

export const login = async (credentials: LoginCredentials): Promise<LoginResponse> => {

    LoginSchema.parse(credentials);
    const response = await axios.post<LoginResponse>(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/login`, credentials);
    return response.data;
}
export const logout = async (): Promise<LogoutResponse> => {
    const response = await axios.post<LogoutResponse>(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/logout`);
    return response.data;
}
