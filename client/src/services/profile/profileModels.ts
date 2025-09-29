import { ApiResponse } from "@/lib/config/api-response-type";

export interface UserProfile {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  roleName: string;
}

export type UserProfileApiResponse=ApiResponse<UserProfile>;