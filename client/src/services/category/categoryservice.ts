import { Category, CreateCategoryPayload } from "./categoryModels";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";
import axios from "axios";
import { MultipleCategoryApiResponse, SingleCategoryApiResponse } from "./categoryModels";

export const getAllCategories = async (): Promise<Category[]> => {
   const token = localStorage.getItem("token");
  const { data } = await axios.get<MultipleCategoryApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.CATEGORY}`,
    {
      headers: {
        Authorization: `Bearer ${token}`
      }
    }
  );
  return data.data;
};

export const createCategory = async (payload: CreateCategoryPayload): Promise<Category> => {
   const token = localStorage.getItem("token");
  const { data } = await axios.post<SingleCategoryApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.CATEGORY}`,
    payload,
    {
      headers: {
        Authorization: `Bearer ${token}`
      }
    }
  );
  return data.data;
};
