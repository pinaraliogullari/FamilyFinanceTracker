"use client";

import { useEffect, useState } from "react";
import { useParams, useRouter } from "next/navigation";
import toast, { Toaster } from "react-hot-toast";
import { User } from "@/services/user/userModels";
import { getUserById, updateRole } from "@/services/user/userservice";
import { getAllRoles } from "@/services/role/roleService";
import { Role } from "@/services/role/roleModels";
import { Button } from "@/components/ui/button";

const UpdateUserRolePage = () => {
  const { id } = useParams();
  console.log("User ID from params:", id);
  const router = useRouter();

  const [user, setUser] = useState<User | null>(null);
  const [roles, setRoles] = useState<Role[]>([]);
  const [loading, setLoading] = useState(true);
  const [currentUserRole, setCurrentUserRole] = useState<string>("");
  const [selectedRoleId, setSelectedRoleId] = useState<number | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const userRes = await getUserById(Number(id));
        const rolesRes = await getAllRoles();

        setUser(userRes);
        setRoles(rolesRes);
        setCurrentUserRole(userRes.roleName);
        setSelectedRoleId(userRes.roleId ?? null); 
      } catch (err) {
        toast.error("Failed to load data");
      } finally {
        setLoading(false);
      }
    };

    if (id) fetchData();
  }, [id]);

const onSubmit = async () => {
  if (!user || selectedRoleId === null) return;

  try {
    await updateRole({ userId: user.id, roleId: selectedRoleId });
    toast.success("Role updated successfully!");
    setTimeout(() => {
      router.push("/users/list");
    }, 2000);
  } catch {
    toast.error("Failed to update role");
  }
};

  if (loading) return <p className="text-center mt-6">Loading...</p>;
  if (!user) return <p className="text-center mt-6">User not found</p>;

  const isAdmin = currentUserRole === "Admin";

  return (
    <div className="min-h-screen bg-gray-900 text-white p-8">
      <Toaster position="top-right" />
      <h1 className="text-2xl font-bold mb-6 text-center">
        Update Role for {user.firstname} {user.lastname}
      </h1>

      <div className="max-w-md mx-auto bg-gray-800 p-6 rounded shadow">
        <div className="mb-4">
          <label className="block mb-2">Select Role</label>
          <select
            value={selectedRoleId ?? undefined}
            onChange={(e) => setSelectedRoleId(Number(e.target.value))}
            className="w-full p-2 text-black rounded"
            disabled={!isAdmin}
          >
            {roles.map((role) => (
              <option key={role.id} value={role.id}>
                {role.name}
              </option>
            ))}
          </select>
          {!isAdmin && (
            <p className="text-sm text-gray-400 mt-1">
              Only admins can change roles.
            </p>
          )}
        </div>

        <div className="flex justify-end gap-2">
          <Button
            className="bg-gray-500 px-4 py-2 rounded hover:bg-gray-600"
            onClick={() => router.push("/users/list")}
          >
            Cancel
          </Button>
          <Button
            onClick={onSubmit}
            className={`px-4 py-2 rounded ${
              isAdmin ? "bg-blue-500 hover:bg-blue-600" : "bg-gray-600 cursor-not-allowed"
            }`}
            disabled={!isAdmin}
          >
            Update
          </Button>
        </div>
      </div>
    </div>
  );
};

export default UpdateUserRolePage;
