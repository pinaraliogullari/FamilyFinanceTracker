import { ApiResponse } from "@/lib/config/api-response-type";
import { FinancialRecordType } from "../financialRecord/financialRecordModels";

export interface Category {
  id: number;
  name: string;
  isCustom: boolean;
  financialRecordType: FinancialRecordType;
}

export interface CreateCategoryPayload {
  name: string;
  financialRecordType: FinancialRecordType;
}


export type MultipleCategoryApiResponse = ApiResponse<Category[]>;
export type SingleCategoryApiResponse = ApiResponse<Category>;