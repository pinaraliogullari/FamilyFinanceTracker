"use client";

import { useEffect, useState } from "react";
import Link from "next/link";
import { FiEdit, FiTrash2 } from "react-icons/fi";
import toast from "react-hot-toast";
import { User } from "@/services/user/userModels";
import { getAllUsers,deleteUser } from "@/services/user/userservice";



const UsersPage = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchUsers = async () => {
    setLoading(true);
    setError(null);
    try {
      const res = await getAllUsers();
      setUsers(res);
    } catch (err) {
      setError("Failed to load users");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

const handleDelete = async (id: number) => {
  if (confirm("Are you sure you want to delete this user?")) {
    try {
      const deletedId = await deleteUser(id);
      console.log("Deleted id:", deletedId);
      toast.success("User deleted successfully!");
      setUsers(users.filter(u => u.id !== deletedId)); 
    } catch {
      toast.error("Failed to delete user");
    }
  }
};


  if (loading) return <p className="text-center mt-6">Loading...</p>;
  if (error) return <p className="text-red-500 text-center mt-6">{error}</p>;

  return (
    <div className="min-h-screen bg-gray-900 text-white p-8">
      <h1 className="text-3xl font-bold mb-6 text-center">Users</h1>
      <table className="w-full border border-gray-700">
        <thead className="bg-gray-800">
          <tr>
            <th className="px-4 py-2 border-b border-gray-600">ID</th>
            <th className="px-4 py-2 border-b border-gray-600">First Name</th>
            <th className="px-4 py-2 border-b border-gray-600">Last Name</th>
            <th className="px-4 py-2 border-b border-gray-600">Email</th>
            <th className="px-4 py-2 border-b border-gray-600">Role</th>
            <th className="px-4 py-2 border-b border-gray-600">Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map((u) => (
            <tr key={u.id} className="hover:bg-gray-700">
              <td className="px-4 py-2 border-b border-gray-600">{u.id}</td>
              <td className="px-4 py-2 border-b border-gray-600">{u.firstname}</td>
              <td className="px-4 py-2 border-b border-gray-600">{u.lastname}</td>
              <td className="px-4 py-2 border-b border-gray-600">{u.email}</td>
              <td className="px-4 py-2 border-b border-gray-600">{u.roleName}</td>
              <td className="px-4 py-2 border-b border-gray-600 flex gap-2">
                <Link href={`/users/role-update/${u.id}`} className="text-yellow-400 hover:text-yellow-300">
                  <FiEdit size={20} />
                </Link>
                <button onClick={() => handleDelete(u.id)} className="text-red-500 hover:text-red-400">
                  <FiTrash2 size={20} />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default UsersPage;
