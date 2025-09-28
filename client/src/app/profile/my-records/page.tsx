"use client";

import { useEffect, useState } from "react";
import axios from "axios";
import toast from "react-hot-toast";
import { Card, CardContent } from "@/components/ui/card";

interface MyRecord {
  financialRecordId: number;
  amount: number;
  categoryId: number;
  categoryName: string;
  description: string;
  financialRecordType: string;
}

const GetMyRecordsPage = () => {
  const [records, setRecords] = useState<MyRecord[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const fetchRecords = async () => {
      setLoading(true);
      try {
        const res = await axios.get<MyRecord[]>("/api/financial-record/my-records");
        setRecords(res.data);
      } catch (err) {
        toast.error("Failed to load financial records");
      } finally {
        setLoading(false);
      }
    };

    fetchRecords();
  }, []);

  if (loading) return <p className="text-center mt-6">Loading...</p>;

  return (
    <div className="max-w-4xl mx-auto mt-8">
      <h1 className="text-[20px] font-bold mb-4 text-center">My Financial Records</h1>

      {records.length === 0 ? (
        <p className="text-center text-gray-400">No financial records found.</p>
      ) : (
        <div className="grid gap-4">
          {records.map((record) => (
            <Card key={record.financialRecordId} className="bg-gray-900 text-white border border-gray-700">
              <CardContent className="p-4">
                <div className="flex justify-between items-center">
                  <div>
                    <p className="text-lg font-semibold">{record.categoryName}</p>
                    <p className="text-sm text-gray-400">{record.description}</p>
                  </div>
                  <div className="text-right">
                    <p className="text-xl font-bold">{record.amount} ₺</p>
                    <p className="text-sm text-gray-400">{record.financialRecordType}</p>
                  </div>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>
      )}
    </div>
  );
};

export default GetMyRecordsPage;
