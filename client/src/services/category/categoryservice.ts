import { Category } from "./categoryModels";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";
import axios from "axios";
import { CategoryApiResponse } from "./categoryModels";


export const getAllCategories = async (): Promise<Category[]> => {
    const { data } = await axios.get<CategoryApiResponse>(`${BASE_API_URL}${API_ENDPOINTS.CATEGORY}`);
    return data.data;
};