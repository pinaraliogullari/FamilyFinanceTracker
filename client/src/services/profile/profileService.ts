import axios from "axios";
import { UserProfile,UserProfileApiResponse } from "./profileModels";
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
