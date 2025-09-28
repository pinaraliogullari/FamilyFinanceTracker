import axios from "axios";
import { User, MultipleUsersApiResponse,SingleUserApiResponse } from "./userModels";
import {UpdateRole,UpdateRoleApiResponse } from "../role/roleModels";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";

export const getAllUsers = async (): Promise<User[]> => {
  const { data } = await axios.get<MultipleUsersApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.USER}`
  );
  return data.data; 
};

export const deleteUser = async (id: number): Promise<number> => {
    await axios.delete(`${BASE_API_URL}${API_ENDPOINTS.USER}/${id}`);
    return id;
};

export const getUserById = async (id: number): Promise<User> => {
  const { data } = await axios.get<SingleUserApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.USER}/${id}`
  );
  return data.data;
};


export const updateRole = async (role: { userId: number; roleId: number }): Promise<UpdateRole> => {
  const { data } = await axios.put<UpdateRoleApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.USER}/update-role`,
    role
  );
  return data.data;
};