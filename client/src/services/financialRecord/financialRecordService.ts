import axios from "axios";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";
import { FinancialRecord } from "./financialRecordModels"; 

export async function getFinancialRecords(
  filter: "all" | "income" | "expense" = "all"
): Promise<FinancialRecord[]> {
  const url =
    filter === "all"
      ? `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}`
      : `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/${filter}`;

  const response = await axios.get<FinancialRecord[]>(url);
  return response.data;
}