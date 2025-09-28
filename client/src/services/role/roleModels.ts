import { ApiResponse } from "@/lib/config/api-response-type";

export interface Role {
  userId: number;
  roleId: number;
}


export type MultipleRoleApiResponse = ApiResponse<Role[]>;
export type SingleRoleApiResponse = ApiResponse<Role>;