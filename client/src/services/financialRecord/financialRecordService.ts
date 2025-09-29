import axios from "axios";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";
import { FinancialRecord, MultipleFinancialRecordsApiResponse, SingleFinancialRecordApiResponse, CreateFinancialRecordPayload, UpdateFinancialRecordPayload } from "./financialRecordModels";
import { de } from "zod/v4/locales";

export const getAllFinancialRecords = async (
  filter: "all" | "income" | "expense" = "all"
): Promise<FinancialRecord[]> => {
  const filterValue =
    filter === "all" ? "" : filter.charAt(0).toUpperCase() + filter.slice(1);

  const url =
    filter === "all"
      ? `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}`
      : `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/type/${filterValue}`;

  try {
    const { data } = await axios.get<MultipleFinancialRecordsApiResponse>(url);
    return data.data;
  } catch (error: any) {
    console.error("Failed to fetch financial records:", error);
    throw new Error(error?.response?.data?.message || error?.message || "Failed to load records");
  }
}

export const getFinancialRecordById = async (id: number): Promise<FinancialRecord> => {
  const { data } = await axios.get<SingleFinancialRecordApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/record/${id}`
  );
  return data.data;
}

export const deleteFinancialRecord = async (id: number): Promise<number> => {
  await axios.delete(`${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/${id}`);
  return id;
};

export const createFinancialRecord = async (payload: CreateFinancialRecordPayload): Promise<FinancialRecord> => {
  const { data } = await axios.post<SingleFinancialRecordApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}`,
    payload
  );
  return data.data;
};

export const updateFinancialRecord = async (payload: UpdateFinancialRecordPayload): Promise<FinancialRecord> => {
  const { data } = await axios.put<SingleFinancialRecordApiResponse>(
    `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}`,
    payload
  );
  return data.data;
};
