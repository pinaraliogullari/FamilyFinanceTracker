import { ApiResponse } from "@/lib/config/api-response-type";


export interface User {
  id: number;
  firstname: string;
  lastname: string;
  email: string;
  roleName: string;
  roleId: number;
}



export type SingleUserApiResponse = ApiResponse<User>;
export type MultipleUsersApiResponse = ApiResponse<User[]>;