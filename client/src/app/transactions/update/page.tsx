"use client";

import { useEffect, useState } from "react";
import { useRouter, useParams } from "next/navigation";
import axios from "axios";
import toast, { Toaster } from "react-hot-toast";
import { BASE_API_URL, API_ENDPOINTS } from "@/lib/config/api";

interface FinancialRecord {
  financialRecordId: number;
  amount: number;
  categoryId: number;
  categoryName: string;
  financialRecordType: "Income" | "Expense";
  description: string;
}

const UpdateFinancialRecordPage = () => {
  const router = useRouter();
  const params = useParams(); // URL param: id
  const recordId = params.id;

  const [record, setRecord] = useState<FinancialRecord | null>(null);
  const [amount, setAmount] = useState(0);
  const [categoryId, setCategoryId] = useState(1);
  const [financialRecordType, setFinancialRecordType] = useState<"Income" | "Expense">("Income");
  const [description, setDescription] = useState("");
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchRecord = async () => {
      setLoading(true);
      try {
        const response = await axios.get(`${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/${recordId}`);
        const data: FinancialRecord = response.data;
        setRecord(data);
        setAmount(data.amount);
        setCategoryId(data.categoryId);
        setFinancialRecordType(data.financialRecordType);
        setDescription(data.description);
      } catch (err) {
        console.error(err);
        toast.error("Failed to load record.");
      } finally {
        setLoading(false);
      }
    };

    fetchRecord();
  }, [recordId]);

  const handleUpdate = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    try {
      await axios.put(`${BASE_API_URL}${API_ENDPOINTS.FINANCIAL_RECORD}/${recordId}`, {
        amount,
        categoryId,
        financialRecordType,
        description,
      });
      toast.success("Record updated successfully!");
      router.push("/transactions/records");
    } catch (err) {
      console.error(err);
      toast.error("Failed to update record.");
    } finally {
      setLoading(false);
    }
  };

  if (loading) return <p>Loading...</p>;
  if (!record) return <p>Record not found</p>;

  return (
    <div className="min-h-screen bg-[#1b0918] text-white p-8 flex justify-center">
      <Toaster position="top-right" reverseOrder={false} />

      <form onSubmit={handleUpdate} className="flex flex-col gap-4 w-full max-w-md">
        <h1 className="text-2xl font-bold mb-4 text-center">Update Transaction</h1>

        <label>
          Amount:
          <input
            type="number"
            value={amount}
            onChange={(e) => setAmount(Number(e.target.value))}
            className="w-full p-2 rounded bg-gray-700 text-white mt-1"
            required
          />
        </label>

        <label>
          Category ID:
          <input
            type="number"
            value={categoryId}
            onChange={(e) => setCategoryId(Number(e.target.value))}
            className="w-full p-2 rounded bg-gray-700 text-white mt-1"
            required
          />
        </label>

        <label>
          Type:
          <select
            value={financialRecordType}
            onChange={(e) => setFinancialRecordType(e.target.value as "Income" | "Expense")}
            className="w-full p-2 rounded bg-gray-700 text-white mt-1"
          >
            <option value="Income">Income</option>
            <option value="Expense">Expense</option>
          </select>
        </label>

        <label>
          Description:
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            className="w-full p-2 rounded bg-gray-700 text-white mt-1"
            required
          />
        </label>

        <button
          type="submit"
          className="bg-yellow-500 hover:bg-yellow-600 px-4 py-2 rounded mt-2"
        >
          Update
        </button>
      </form>
    </div>
  );
};

export default UpdateFinancialRecordPage;
