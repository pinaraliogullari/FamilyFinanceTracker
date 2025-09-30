"use client";

import { useEffect, useState } from "react";
import { getMyRecords } from "@/services/profile/profileService";
import { MyFinancialRecord, FinancialRecordType } from "@/services/profile/profileModels";
import toast, { Toaster } from "react-hot-toast";

const MyRecordsPage = () => {
  const [records, setRecords] = useState<MyFinancialRecord[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchMyRecords = async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await getMyRecords();
      setRecords(data);
      if (data.length === 0) toast("Any records found.");
    } catch (err) {
      console.error(err);
      setError("An error occurred while loading records");
      toast.error("Failed to load records!");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchMyRecords();
  }, []);

  return (
    <div className="min-h-screen bg-gray-100 text-gray-900 p-8">
      <Toaster position="top-right" reverseOrder={false} />
      <h1 className="text-3xl font-bold mb-6 text-center">My Financial Records</h1>

      {loading && <p className="text-center">Loading...</p>}
      {error && <p className="text-center text-red-500">{error}</p>}

      {!loading && !error && records.length > 0 && (
        <table className="w-full text-left border border-gray-300 bg-white shadow-md rounded-lg overflow-hidden">
          <thead className="bg-gray-200">
            <tr>
              <th className="px-4 py-2 border-b">ID</th>
              <th className="px-4 py-2 border-b">Amount</th>
              <th className="px-4 py-2 border-b">Category</th>
              <th className="px-4 py-2 border-b">Type</th>
              <th className="px-4 py-2 border-b">Description</th>
            </tr>
          </thead>
          <tbody>
            {records.map((record) => (
              <tr key={record.financialRecordId} className="hover:bg-gray-100">
                <td className="px-4 py-2 border-b">{record.financialRecordId}</td>
                <td className="px-4 py-2 border-b">{record.amount}</td>
                <td className="px-4 py-2 border-b">{record.categoryName}</td>
                <td className="px-4 py-2 border-b">
                  {record.financialRecordType === FinancialRecordType.Income ? "Income" : "Expense"}
                </td>
                <td className="px-4 py-2 border-b">{record.description}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      {!loading && !error && records.length === 0 && (
        <p className="text-center mt-4">No records found.</p>
      )}
    </div>
  );
};

export default MyRecordsPage;
