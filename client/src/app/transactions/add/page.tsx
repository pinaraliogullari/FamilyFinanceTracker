"use client";

import { useState } from "react";
import axios, { AxiosResponse } from "axios";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";
import toast, { Toaster } from "react-hot-toast";

interface AddFinancialRecordPayload {
  amount: number;
  categoryName: string;
  financialRecordType: "Income" | "Expense";
  description: string;
}

interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  statusCode: number;
}

const AddFinancialRecordPage = () => {
  const [amount, setAmount] = useState<number>(0);
  const [categoryName, setCategoryName] = useState<string>("");
  const [financialRecordType, setFinancialRecordType] = useState<"Income" | "Expense">("Income");
  const [description, setDescription] = useState("");
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    const payload: AddFinancialRecordPayload = {
      amount,
      categoryName,
      financialRecordType,
      description,
    };

    try {
      const response: AxiosResponse<ApiResponse<any>> = await axios.post(
        `${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}`,
        payload
      );

      if (response.data.success) {
        toast.success("The record has been added!");
        setAmount(0);
        setCategoryName("");
        setFinancialRecordType("Income");
        setDescription("");
      } else {
        toast.error(response.data.message || "The record could not be added!");
      }
    } catch (err: any) {
      console.error(err);
      toast.error(err?.response?.data?.message || err?.message || "An error occurred while adding the record");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-[#1b0918] text-white flex items-center justify-center p-8">
      <div className="w-full max-w-md bg-gray-900 p-6 rounded-lg shadow-md">
        <h1 className="font-bold mb-4 text-center text-xl">Financial Record Add</h1>

        <form onSubmit={handleSubmit} className="flex flex-col gap-4">
          <label>
            Tutar:
            <input
              type="number"
              value={amount}
              onChange={(e) => setAmount(Number(e.target.value))}
              className="w-full p-2 rounded bg-gray-700 text-white mt-1"
              required
            />
          </label>

          <label>
            Kategori:
            <input
              type="text"
              value={categoryName}
              onChange={(e) => setCategoryName(e.target.value)}
              className="w-full p-2 rounded bg-gray-700 text-white mt-1"
              required
            />
          </label>

          <label>
            Tür:
            <select
              value={financialRecordType}
              onChange={(e) => setFinancialRecordType(e.target.value as "Income" | "Expense")}
              className="w-full p-2 rounded bg-gray-700 text-white mt-1"
            >
              <option value="Income">Gelir</option>
              <option value="Expense">Gider</option>
            </select>
          </label>

          <label>
            Açıklama:
            <textarea
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              className="w-full p-2 rounded bg-gray-700 text-white mt-1"
              maxLength={500}
            />
          </label>

          <button
            type="submit"
            className="bg-sky-500 p-2 rounded hover:bg-sky-600 transition-colors"
            disabled={loading}
          >
            {loading ? "Kaydediliyor..." : "Kaydı Ekle"}
          </button>
        </form>
      </div>

      {/* Toaster Component */}
      <Toaster position="top-right" reverseOrder={false} />
    </div>
  );
};

export default AddFinancialRecordPage;
