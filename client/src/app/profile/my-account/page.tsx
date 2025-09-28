"use client";

import { useEffect, useState } from "react";
import axios from "axios";
import toast from "react-hot-toast";
import Link from "next/link";

interface UserProfile {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  roleName: string;
}

const ProfilePage = () => {
  const [profile, setProfile] = useState<UserProfile | null>(null);
  const [loading, setLoading] = useState(false);
  const [updating, setUpdating] = useState(false);

  useEffect(() => {
    const fetchProfile = async () => {
      setLoading(true);
      try {
        const res = await axios.get<UserProfile>("/api/my-profile");
        setProfile(res.data);
      } catch (err) {
        toast.error("Failed to load profile.");
      } finally {
        setLoading(false);
      }
    };
    fetchProfile();
  }, []);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    if (!profile) return;
    setProfile({ ...profile, [e.target.name]: e.target.value });
  };

  const handleSubmit = async () => {
    if (!profile) return;
    setUpdating(true);
    try {
      await axios.put("/api/update-profile", profile);
      toast.success("Profile updated successfully!");
    } catch {
      toast.error("Profile update failed.");
    } finally {
      setUpdating(false);
    }
  };

  if (loading) return <p className="text-center mt-8">Loading...</p>;

  return (
    <div className="flex min-h-screen w-full bg-gray-100">
      {/* Sol Menü */}
      <div className="w-1/4 bg-gray-200 p-6 flex flex-col">
        <h2 className="font-bold text-xl mb-6">My Account</h2>
        <ul className="flex flex-col gap-4">
          <li className="p-3 rounded hover:bg-gray-300">
            <Link href="/profile/update-password">Update Password</Link>
          </li>
          <li className="p-3 rounded hover:bg-gray-300">
            <Link href="/profile/my-records">My Records</Link>
          </li>
        </ul>
      </div>

      {/* Sağ İçerik */}
      <div className="flex-1 bg-gray-900 text-white p-8 overflow-y-auto">
        {profile && (
          <div className="max-w-xl mx-auto">
            <h1 className="text-3xl font-bold mb-6 text-center">My Profile</h1>

            <div className="mb-4">
              <label className="block mb-1">First Name</label>
              <input
                name="firstName"
                value={profile.firstName}
                onChange={handleChange}
                className="w-full px-3 py-2 text-black rounded"
              />
            </div>

            <div className="mb-4">
              <label className="block mb-1">Last Name</label>
              <input
                name="lastName"
                value={profile.lastName}
                onChange={handleChange}
                className="w-full px-3 py-2 text-black rounded"
              />
            </div>

            <div className="mb-4">
              <label className="block mb-1">Email</label>
              <input
                name="email"
                value={profile.email}
                onChange={handleChange}
                className="w-full px-3 py-2 text-black rounded"
              />
            </div>

            <div className="mb-4">
              <label className="block mb-1">Role</label>
              {profile.roleName === "Admin" ? (
                <select
                  name="roleName"
                  value={profile.roleName}
                  onChange={handleChange}
                  className="w-full px-3 py-2 text-black rounded"
                >
                  <option value="Admin">Admin</option>
                  <option value="User">User</option>
                  <option value="Manager">Manager</option>
                </select>
              ) : (
                <input
                  name="roleName"
                  value={profile.roleName}
                  readOnly
                  className="w-full px-3 py-2 text-gray-500 bg-gray-700 rounded cursor-not-allowed"
                />
              )}
            </div>

            <button
              onClick={handleSubmit}
              disabled={updating}
              className="w-full bg-blue-500 py-2 rounded hover:bg-blue-600"
            >
              {updating ? "Updating..." : "Update Profile"}
            </button>
          </div>
        )}
      </div>
    </div>
  );
};

export default ProfilePage;
