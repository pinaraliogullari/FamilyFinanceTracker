"use client";

import { useState } from "react";
import axios from "axios";
import toast from "react-hot-toast";
import { useRouter } from "next/navigation";

const UpdatePasswordPage = () => {
  const router = useRouter();
  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [newPasswordConfirm, setNewPasswordConfirm] = useState("");
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (newPassword !== newPasswordConfirm) {
      toast.error("Yeni şifreler uyuşmuyor!");
      return;
    }

    setLoading(true);
    try {
      const response = await axios.put("/api/users/update-password", {
        userId: 1, // JWT ile gerçek kullanıcı ID alınacak
        oldPassword,
        newPassword,
        newPasswordConfirm,
      });

      toast.success(response.data.message || "Şifre başarıyla güncellendi!");

      // Kısa süre bekleyip profil sayfasına yönlendir
      setTimeout(() => {
        router.push("/profile/my-account"); 
      }, 1000); // 1 saniye beklet
    } catch (error: any) {
      toast.error(error.response?.data?.message || "Şifre güncellenirken hata oluştu!");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex justify-center items-start bg-gray-100 p-8">
      <div className="w-full max-w-md bg-white p-8 rounded-lg shadow">
        <h1 className="mb-6 text-center font-bold" style={{ fontSize: "20px" }}>
          Update Password
        </h1>
        <form onSubmit={handleSubmit} className="flex flex-col gap-4">
          <div>
            <label className="block mb-1 font-medium">Old Password</label>
            <input
              type="password"
              value={oldPassword}
              onChange={(e) => setOldPassword(e.target.value)}
              className="w-full px-3 py-2 border rounded"
              required
            />
          </div>

          <div>
            <label className="block mb-1 font-medium">New Password</label>
            <input
              type="password"
              value={newPassword}
              onChange={(e) => setNewPassword(e.target.value)}
              className="w-full px-3 py-2 border rounded"
              required
            />
          </div>

          <div>
            <label className="block mb-1 font-medium">Confirm New Password</label>
            <input
              type="password"
              value={newPasswordConfirm}
              onChange={(e) => setNewPasswordConfirm(e.target.value)}
              className="w-full px-3 py-2 border rounded"
              required
            />
          </div>

          <button
            type="submit"
            disabled={loading}
            className="w-full bg-blue-500 hover:bg-blue-600 text-white py-2 rounded"
          >
            {loading ? "Updating..." : "Update Password"}
          </button>
        </form>
      </div>
    </div>
  );
};

export default UpdatePasswordPage;
