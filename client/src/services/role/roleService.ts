import axios from "axios";
import { Role, RoleApiResponse } from "./roleModels";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";

export const getAllRoles = async (): Promise<Role[]> => {
  const { data } = await axios.get<RoleApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.ROLE}`
  );
  return data.data; 
}
