import { ApiResponse } from "@/lib/config/api-response-type";

export interface Role {
  id: number;
  name: string;
}

export interface UpdateRole{
  userId: number;
  roleId: number;
}

export type RoleApiResponse = ApiResponse<Role[]>;
export type UpdateRoleApiResponse=ApiResponse<UpdateRole>;