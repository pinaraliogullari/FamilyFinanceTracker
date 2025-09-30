"use client";

import { useEffect, useState } from "react";
import Link from "next/link";
import toast from "react-hot-toast";
import { UserProfile } from "@/services/profile/profileModels";
import { getMyProfile, updateMyProfile } from "@/services/profile/profileService";

const ProfilePage = () => {
  const [profile, setProfile] = useState<UserProfile | null>(null);
  const [loading, setLoading] = useState(true);
  const [updating, setUpdating] = useState(false);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
        const data = await getMyProfile();
        setProfile(data);
      } catch {
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
      await updateMyProfile(profile);
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
  
      <div className="w-1/4 bg-white shadow-md p-6 flex flex-col">
        <h2 className="font-bold text-xl mb-6 text-gray-800">My Account</h2>
        <ul className="flex flex-col gap-4">
          <li className="p-3 rounded hover:bg-gray-100 transition">
            <Link href="/profile/update-password" className="text-gray-700">Update Password</Link>
          </li>
          <li className="p-3 rounded hover:bg-gray-100 transition">
            <Link href="/profile/my-records" className="text-gray-700">My Records</Link>
          </li>
        </ul>
      </div>

      <div className="flex-1 bg-gray-50 p-8 overflow-y-auto">
        {profile && (
          <div className="max-w-xl mx-auto bg-white p-6 rounded-lg shadow-md">
            <h1 className="text-3xl font-bold mb-6 text-center text-gray-800">My Profile</h1>

            <div className="mb-4">
              <label className="block mb-1 text-gray-700">First Name</label>
              <input
                name="firstName"
                value={profile.firstName || ""}
                onChange={handleChange}
                className="w-full px-3 py-2 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
              />
            </div>

            <div className="mb-4">
              <label className="block mb-1 text-gray-700">Last Name</label>
              <input
                name="lastName"
                value={profile.lastName || ""}
                onChange={handleChange}
                className="w-full px-3 py-2 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
              />
            </div>

            <div className="mb-4">
              <label className="block mb-1 text-gray-700">Email</label>
              <input
                name="email"
                value={profile.email || ""}
                onChange={handleChange}
                className="w-full px-3 py-2 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
              />
            </div>

            <div className="mb-4">
              <label className="block mb-1 text-gray-700">Role</label>
              <select
                name="roleName"
                value={profile.roleName || ""}
                onChange={handleChange}
                className="w-full px-3 py-2 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
              >
                <option value="Admin">Admin</option>
                <option value="User">User</option>
              </select>
            </div>

            <button
              onClick={handleSubmit}
              disabled={updating}
              className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition"
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
