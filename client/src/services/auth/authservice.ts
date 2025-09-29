import axios from 'axios';
import { LoginPayload, LoginResponse, SignUpPayload, SignUpResponse,LoginSchema, LogoutResponse } from './authModels'
import { API_ENDPOINTS, BASE_API_URL } from '@/lib/config/api';
import { SignUpApiResponse,LoginApiResponse,LogoutApiResponse } from './authModels';

export const signup = async (payload: SignUpPayload): Promise<SignUpResponse> => {

    const response = await axios.post<SignUpApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/signup`, payload);
    return response.data.data;
}

export const login = async (payload: LoginPayload): Promise<LoginResponse> => {

    LoginSchema.parse(payload);
    const response = await axios.post<LoginApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/login`, payload);
    return response.data.data;
}
export const logout = async (): Promise<LogoutResponse> => {
    const response = await axios.post<LogoutApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/logout`);
    return response.data.data;
}
