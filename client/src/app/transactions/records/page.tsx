"use client";

import { useEffect, useState } from "react";
import { getFinancialRecords } from "@/services/financialRecord/financialRecordService";
import { FinancialRecord } from "@/services/financialRecord/financialRecordModels";

const RecordsPage = () => {
  const [records, setRecords] = useState<FinancialRecord[]>([]);
  const [filter, setFilter] = useState<"all" | "income" | "expense">("all");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      setError(null);
      try {
        const data = await getFinancialRecords(filter);
        setRecords(data);
      } catch (err) {
        console.error(err);
        setError("Failed to load records");
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [filter]);

  return (
    <div className="min-h-screen bg-[#1b0918] text-white p-8">
      <h1 className="text-3xl font-bold mb-6">Transactions</h1>

  
      <div className="flex gap-4 mb-6">
        <button
          className={`px-4 py-2 rounded ${filter === "all" ? "bg-sky-500" : "bg-gray-700"}`}
          onClick={() => setFilter("all")}
        >
          All
        </button>
        <button
          className={`px-4 py-2 rounded ${filter === "income" ? "bg-green-500" : "bg-gray-700"}`}
          onClick={() => setFilter("income")}
        >
          Income
        </button>
        <button
          className={`px-4 py-2 rounded ${filter === "expense" ? "bg-red-500" : "bg-gray-700"}`}
          onClick={() => setFilter("expense")}
        >
          Expense
        </button>
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
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default RecordsPage;
