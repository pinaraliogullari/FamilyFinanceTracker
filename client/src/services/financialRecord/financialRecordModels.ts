import { ApiResponse } from "@/lib/config/api-response-type";

export interface FinancialRecord {
  financialRecordId: number;
  amount: number;
  categoryId: number;
  categoryName: string;
  description: string;
  userId: number;
  userFirstName: string;
  userLastName: string;
  financialRecordType: FinancialRecordType;
}
export enum FinancialRecordType {
  Income = 0,
  Expense = 1
}

export interface CreateFinancialRecordPayload {
  amount: number;
  categoryId: number;
  financialRecordType: FinancialRecordType;
  description: string;
  userId: number;
}

export interface UpdateFinancialRecordPayload{
  financialRecordId: number;
  amount?: number;
  categoryId?: number;
  financialRecordType?: FinancialRecordType;
  description?: string;
  userId?: number;
}

export type SingleFinancialRecordApiResponse = ApiResponse<FinancialRecord>;
export type MultipleFinancialRecordsApiResponse = ApiResponse<FinancialRecord[]>;
