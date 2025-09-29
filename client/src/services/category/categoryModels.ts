import { ApiResponse } from "@/lib/config/api-response-type";

export interface Category {
  id: number;
  name: string;
  isCustom: boolean;
  financialRecordType: string
}


export type CategoryApiResponse = ApiResponse<Category[]>;