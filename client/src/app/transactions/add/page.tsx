"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { Category } from "@/services/category/categoryModels";
import { getAllCategories } from "@/services/category/categoryservice";
import { CreateFinancialRecordPayload } from "@/services/financialRecord/financialRecordModels";
import { FinancialRecordType } from "@/services/financialRecord/financialRecordModels";

import { createFinancialRecord } from "@/services/financialRecord/financialRecordService";
import toast, { Toaster } from "react-hot-toast";

const AddFinancialRecordPage = () => {
  console.log("FinancialRecordType:", FinancialRecordType);

  const router = useRouter();
  const [amount, setAmount] = useState<string>("");
  const [categoryId, setCategoryId] = useState<number | null>(null);
  const [categories, setCategories] = useState<Category[]>([]);
  const [financialRecordType, setFinancialRecordType] = useState<FinancialRecordType>(FinancialRecordType.Income);
  const [description, setDescription] = useState("");
  const [loading, setLoading] = useState(false);
  const [categoryLoading, setCategoryLoading] = useState(true);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const data = await getAllCategories();
        setCategories(data);
      } catch (err) {
        console.error(err);
        toast.error("Failed to load categories");
      } finally {
        setCategoryLoading(false);
      }
    };

    fetchCategories();
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (!categoryId) {
      toast.error("Please select a category");
      return;
    }

    setLoading(true);

    const payload: CreateFinancialRecordPayload = {
      amount: Number(amount),
      categoryId,
      financialRecordType,
      description,
    };

    try {
      const response = await createFinancialRecord(payload);
      if (response) {
        toast.success("The record has been added!");
        setAmount("");
        setCategoryId(null);
        setFinancialRecordType(FinancialRecordType.Income);
        setDescription("");
      } else {
        toast.error("The record could not be added!");
        setTimeout(() => {
          window.location.reload();
        }, 2000);
        router.push("/transactions/records");
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
        <h1 className="font-bold mb-4 text-center text-xl">Add Financial Record</h1>

        <form onSubmit={handleSubmit} className="flex flex-col gap-4">
          <label>
            Amount:
            <input
              type="number"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              className="w-full p-2 rounded bg-gray-700 text-white mt-1"
              min={0}
              step={0.01}
              required
            />
          </label>

          <label>
            Category:
            {categoryLoading ? (
              <p className="text-gray-400 mt-1">Loading categories...</p>
            ) : (
              <select
                value={categoryId ?? ""}
                onChange={(e) => setCategoryId(Number(e.target.value))}
                className="w-full p-2 rounded bg-gray-700 text-white mt-1"
                required
              >
                <option value="" disabled>
                  Select a category
                </option>
                {categories.map((cat) => (
                  <option key={cat.id} value={cat.id}>
                    {cat.name}
                  </option>
                ))}
              </select>
            )}
          </label>
          <label>
            Type:
            <select
              value={financialRecordType}
              onChange={(e) =>
                setFinancialRecordType(Number(e.target.value) as FinancialRecordType)
              }
              className="w-full p-2 rounded bg-gray-700 text-white mt-1"
            >
              <option value={FinancialRecordType.Income}>Income</option>
              <option value={FinancialRecordType.Expense}>Expense</option>
            </select>
          </label>


          <label>
            Description:
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
            {loading ? "Saving..." : "Add Record"}
          </button>
        </form>
      </div>

      <Toaster position="top-right" reverseOrder={false} />
    </div>
  );
};

export default AddFinancialRecordPage;
