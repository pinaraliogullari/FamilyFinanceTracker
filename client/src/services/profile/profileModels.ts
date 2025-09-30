import { ApiResponse } from "@/lib/config/api-response-type";

export interface UserProfile {
  userId: number;
  firstName: string;
  lastName: string;
  email: string;
  roleName: string;
}

export interface MyFinancialRecord {
  financialRecordId: number;
  amount: number;
  categoryId: number;
  categoryName: string;
  description: string;
  financialRecordType: FinancialRecordType;
}
export enum FinancialRecordType {
  Income = 0,
  Expense = 1
}

export type UserProfileApiResponse=ApiResponse<UserProfile>;
export type MyFinancialRecordsApiResponse=ApiResponse<MyFinancialRecord[]>;