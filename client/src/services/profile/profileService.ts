import axios from "axios";
import { UserProfile,UserProfileApiResponse,MyFinancialRecord,MyFinancialRecordsApiResponse } from "./profileModels";
import { API_ENDPOINTS, BASE_API_URL } from "@/lib/config/api";

const getAuthHeaders = () => {
  const token = localStorage.getItem("token");
  return token ? { Authorization: `Bearer ${token}` } : {};
};
export const getMyProfile = async (): Promise<UserProfile> => {
  const res = await axios.get<UserProfileApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.USER}/my-profile`, {
    headers: getAuthHeaders(),
  });

  return res.data.data;
};

export const updateMyProfile = async (payload: UserProfile): Promise<UserProfile> => {
  const res = await axios.put<UserProfileApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.USER}/update-profile`, payload, {
    headers: getAuthHeaders(),
  }); 

  return res.data.data;
};  

export const getMyRecords = async (): Promise<MyFinancialRecord[]> => {
  const res = await axios.get<MyFinancialRecordsApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.USER}/my-records`, {
    headers: getAuthHeaders(),
  });
  return res.data.data;
};