"use client";

import { useEffect, useState } from "react";
import { useRouter, useParams } from "next/navigation";
import toast, { Toaster } from "react-hot-toast";
import {FinancialRecord,UpdateFinancialRecordPayload,FinancialRecordType} from "@/services/financialRecord/financialRecordModels";
import {updateFinancialRecord,getFinancialRecordById} from "@/services/financialRecord/financialRecordService";
import { getAllCategories } from "@/services/category/categoryService";

interface Category {
  id: number;
  name: string;
}

const UpdateFinancialRecordPage = () => {
  const router = useRouter();
  const { id } = useParams();
  const recordId = Number(id);

  const [record, setRecord] = useState<FinancialRecord | null>(null);
  const [amount, setAmount] = useState("0"); // string olarak
  const [categoryId, setCategoryId] = useState(0);
  const [financialRecordType, setFinancialRecordType] = useState<FinancialRecordType>(
    FinancialRecordType.Income
  );
  const [description, setDescription] = useState("");
  const [categories, setCategories] = useState<Category[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const [recordData, categoryData] = await Promise.all([
          getFinancialRecordById(recordId),
          getAllCategories(), // tüm kategorileri çekiyoruz
        ]);

        setRecord(recordData);
        setAmount(recordData.amount.toString());
        setCategoryId(recordData.categoryId);
        setFinancialRecordType(recordData.financialRecordType);
        setDescription(recordData.description);
        setCategories(categoryData);
      } catch (err) {
        console.error(err);
        toast.error("Failed to load data.");
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [recordId]);

  const handleUpdate = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    try {
      const payload: UpdateFinancialRecordPayload = {
        financialRecordId: recordId,
        amount: Number(amount),
        categoryId,
        financialRecordType,
        description,
       userId: record?.userId,
      };
      await updateFinancialRecord(payload);
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
            onChange={(e) => setAmount(e.target.value)} // string olarak alıyoruz
            className="w-full p-2 rounded bg-gray-700 text-white mt-1"
            required
          />
        </label>

        <label>
          Category:
          <select
            value={categoryId}
            onChange={(e) => setCategoryId(Number(e.target.value))}
            className="w-full p-2 rounded bg-gray-700 text-white mt-1"
          >
            {categories.map((cat) => (
              <option key={cat.id} value={cat.id}>
                {cat.name}
              </option>
            ))}
          </select>
        </label>

        <label>
          Type:
          <select
            value={financialRecordType}
            onChange={(e) =>
              setFinancialRecordType(Number(e.target.value as "Income" | "Expense"))
            }
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
