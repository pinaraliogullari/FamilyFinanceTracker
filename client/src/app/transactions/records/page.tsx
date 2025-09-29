"use client";

import { useEffect, useState } from "react";
import { deleteFinancialRecord, getAllFinancialRecords } from "@/services/financialRecord/financialRecordService";
import { FinancialRecord } from "@/services/financialRecord/financialRecordModels";
import Link from "next/link";
import { FiEdit, FiTrash2 } from "react-icons/fi";
import toast, { Toaster } from "react-hot-toast";
import { Button } from "@/components/ui/button";
import { userRoleAtom } from "@/stores/auth-atom";
import { useAtom } from "jotai";
import { useRouter } from "next/navigation";

const RecordsPage = () => {
  const [records, setRecords] = useState<FinancialRecord[]>([]);
  const [filter, setFilter] = useState<"all" | "income" | "expense">("all");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [userRole] = useAtom(userRoleAtom);

  const router = useRouter();
  const handleEditClick = (id: number) => {
    if (userRole !== "Admin") {
      toast.error("Yetkiniz yok");
      return;
    }

    router.push(`/transactions/update/${id}`);
  };

  const handleDeleteClick = (id: number) => {
    if (userRole !== "Admin") {
      toast.error("Yetkiniz yok");
      return;
    }
    handleDelete(id);
  };

  const fetchRecords = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await getAllFinancialRecords(filter);
      setRecords(data);
      console.log(data);
    } catch (err) {
      console.error(err);
      setError("Failed to load records");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRecords();
  }, [filter]);

  const handleDelete = async (id: number) => {
    if (confirm("Are you sure you want to delete this record?")) {
      const deletedId = await deleteFinancialRecord(id);
      toast.success("Record deleted successfully!");
      setRecords(records.filter((r) => r.financialRecordId !== deletedId));
    }
  };

  return (
    <div className="min-h-screen bg-[#1b0918] text-white p-8">
      <Toaster position="top-right" reverseOrder={false} />

      <h1 className="text-3xl font-bold mb-6 text-center">Transaction Records</h1>

      <div className="flex gap-4 mb-6">
        <Button
          className={`px-4 py-2 rounded ${filter === "all" ? "bg-sky-500" : "bg-gray-700"}`}
          onClick={() => setFilter("all")}
        >
          All
        </Button>
        <Button
          className={`px-4 py-2 rounded ${filter === "income" ? "bg-green-500" : "bg-gray-700"}`}
          onClick={() => setFilter("income")}
        >
          Income
        </Button>
        <Button
          className={`px-4 py-2 rounded ${filter === "expense" ? "bg-red-500" : "bg-gray-700"}`}
          onClick={() => setFilter("expense")}
        >
          Expense
        </Button>

        <Link
          href="/transactions/add"
          className="ml-auto text-white px-4 py-2 rounded bg-gray-900 !no-underline hover:bg-gray-800"
        >
          Add Transaction
        </Link>
      </div>

      {loading && <p>Loading...</p>}
      {error && <p className="text-red-500">{error}</p>}

      {!loading && !error && (
        <table className="w-full text-left border border-gray-600">
          <thead className="bg-gray-800">
            <tr>
              <th className="px-4 py-2 border-b border-gray-600">ID</th>
              <th className="px-4 py-2 border-b border-gray-600">Amount</th>
              <th className="px-4 py-2 border-b border-gray-600">Category</th>
              <th className="px-4 py-2 border-b border-gray-600">Type</th>
              <th className="px-4 py-2 border-b border-gray-600">Description</th>
              <th className="px-4 py-2 border-b border-gray-600">User</th>
              <th className="px-4 py-2 border-b border-gray-600">Actions</th>
            </tr>
          </thead>
          <tbody>
            {records.map((tx) => (
              <tr key={tx.financialRecordId} className="hover:bg-gray-700">
                <td className="px-4 py-2 border-b border-gray-600">{tx.financialRecordId}</td>
                <td className="px-4 py-2 border-b border-gray-600">{tx.amount}</td>
                <td className="px-4 py-2 border-b border-gray-600">{tx.categoryName}</td>
                <td className="px-4 py-2 border-b border-gray-600">{tx.financialRecordType}</td>
                <td className="px-4 py-2 border-b border-gray-600">{tx.description}</td>
                <td className="px-4 py-2 border-b border-gray-600">{`${tx.userFirstName} ${tx.userLastName}`}</td>
                <td className="px-4 py-2 border-b border-gray-600 flex gap-2">
                  <FiEdit
                    size={20}
                    className="text-yellow-400 hover:text-yellow-300 cursor-pointer"
                    onClick={() => handleEditClick(tx.financialRecordId)}
                  />
                  <FiTrash2
                    size={20}
                    className="text-red-500 hover:text-red-400 cursor-pointer"
                    onClick={() => handleDeleteClick(tx.financialRecordId)}
                  />

                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default RecordsPage;
