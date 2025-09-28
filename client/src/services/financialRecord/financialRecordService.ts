import axios, { AxiosResponse } from "axios";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";
import { FinancialRecord } from "./financialRecordModels";

interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  statusCode: number;
}

export async function getFinancialRecords(
  filter: "all" | "income" | "expense" = "all"
): Promise<FinancialRecord[]> {
  const filterValue =
    filter === "all" ? "" : filter.charAt(0).toUpperCase() + filter.slice(1); 

  const url =
    filter === "all"
      ? `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}`
      : `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/type/${filterValue}`;

  try {
   const response: AxiosResponse<ApiResponse<FinancialRecord[]>> = await axios.get(url);
   return response.data.data;
  } catch (error: any) {
    console.error("Failed to fetch financial records:", error);
    throw new Error(error?.response?.data?.message || error?.message || "Failed to load records");
  }
}
