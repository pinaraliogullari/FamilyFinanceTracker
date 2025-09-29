"use client";

import { useEffect, useState } from "react";
import { useRouter } from "next/navigation";
import { CreateFinancialRecordPayload, FinancialRecordType } from "@/services/financialRecord/financialRecordModels";
import { createFinancialRecord } from "@/services/financialRecord/financialRecordService";
import toast, { Toaster } from "react-hot-toast";
import { Category, CreateCategoryPayload } from "@/services/category/categoryModels";
import { getAllCategories, createCategory } from "@/services/category/categoryService";

const AddFinancialRecordPage = () => {
  const router = useRouter();

  const [amount, setAmount] = useState<string>("");
  const [categoryId, setCategoryId] = useState<number | null>(null);
  const [categories, setCategories] = useState<Category[]>([]);
  const [financialRecordType, setFinancialRecordType] = useState<FinancialRecordType>(FinancialRecordType.Income);
  const [description, setDescription] = useState("");
  const [loading, setLoading] = useState(false);
  const [categoryLoading, setCategoryLoading] = useState(true);

  const [isCategoryModalOpen, setIsCategoryModalOpen] = useState(false);
  const [newCategoryName, setNewCategoryName] = useState("");
  const [newCategoryType, setNewCategoryType] = useState<FinancialRecordType>(FinancialRecordType.Income);

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

  const handleOpenCategoryModal = () => setIsCategoryModalOpen(true);
  const handleCloseCategoryModal = () => setIsCategoryModalOpen(false);

  const handleAddCategory = async () => {
    if (!newCategoryName) {
      toast.error("Please enter a category name");
      return;
    }

    const payload: CreateCategoryPayload = {
      name: newCategoryName,
      financialRecordType: newCategoryType,
    };
    try {
      const newCat = await createCategory(payload);

      // Yeni kategoriyi listeye ekle
      setCategories((prev) => [...prev, newCat]);

      // Eklenen kategoriyi otomatik seç
      setCategoryId(newCat.id);

      setNewCategoryName("");
      setNewCategoryType(FinancialRecordType.Income);
      handleCloseCategoryModal();
      toast.success("Category added!");
    } catch (err: any) {
      console.error(err);
      toast.error(err?.response?.data?.message || "Failed to create category");
    }
  };

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
        router.push("/transactions/records");
      } else {
        toast.error("The record could not be added!");
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
                onChange={(e) => {
                  if (e.target.value === "new") handleOpenCategoryModal();
                  else setCategoryId(Number(e.target.value));
                }}
                className="w-full p-2 rounded bg-gray-700 text-white mt-1"
                required
              >
                <option value="" disabled>Select a category</option>
                {categories.map((cat) => (
                  <option key={cat.id} value={cat.id}>{cat.name}</option>
                ))}
                <option value="new">+ Create New Category...</option>
              </select>
            )}
          </label>

          <label>
            Type:
            <select
              value={financialRecordType}
              onChange={(e) => setFinancialRecordType(Number(e.target.value) as FinancialRecordType)}
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

      {isCategoryModalOpen && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
          <div className="bg-gray-900 p-6 rounded-lg w-full max-w-sm">
            <h2 className="text-lg font-bold mb-4">Create New Category</h2>
            <input
              type="text"
              placeholder="Category name"
              value={newCategoryName}
              onChange={(e) => setNewCategoryName(e.target.value)}
              className="w-full p-2 rounded bg-gray-700 text-white mb-2"
            />
            <select
              value={newCategoryType}
              onChange={(e) => setNewCategoryType(Number(e.target.value) as FinancialRecordType)}
              className="w-full p-2 rounded bg-gray-700 text-white mb-4"
            >
              <option value={FinancialRecordType.Income}>Income</option>
              <option value={FinancialRecordType.Expense}>Expense</option>
            </select>
            <div className="flex justify-end gap-2">
              <button
                className="bg-gray-600 p-2 rounded hover:bg-gray-700 transition-colors"
                onClick={handleCloseCategoryModal}
              >
                Cancel
              </button>
              <button
                className="bg-green-500 p-2 rounded hover:bg-green-600 transition-colors"
                onClick={handleAddCategory}
              >
                Add
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default AddFinancialRecordPage;
