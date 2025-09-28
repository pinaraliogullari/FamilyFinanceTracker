export interface FinancialRecord {
  financialRecordId: number;
  amount: number;
  categoryId: number;
  categoryName: string;
  description: string;
  userId: number;
  userFirstName: string;
  userLastName: string;
  financialRecordType: string; 
}
interface AddFinancialRecordPayload {
  amount: number;
  categoryId: number;
  financialRecordType: "Income" | "Expense";
  description: string;
}
