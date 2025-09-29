
import { ApiResponse } from "@/lib/config/api-response-type";
import { z } from "zod";


export const SignUpSchema = z
  .object({
    firstName: z.string().min(1, "First name is required"),
    lastName: z.string().min(1, "Last name is required"),
    email: z.email({ message: "Please enter a valid email" }),

    password: z.string().min(8, { message: "Password must be at least 8 characters long" }),
    confirmPassword: z.string().min(8, { message: "Password must be at least 8 characters long" })
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords do not match",
    path: ["confirmPassword"]
  });

export type SignUpPayload = z.infer<typeof SignUpSchema>;

export interface SignUpResponse {
  id: number;
  firstname: string;
  lastname: string;
  email: string;
}


export const LoginSchema = z.object({
  email: z.email({ message: "Invalid email format" }), 
  password: z.string().min(1, { message: "Password is required" })
});

export type LoginPayload = z.infer<typeof LoginSchema>;

export interface Token {
  accessToken: string;
  refreshToken: string;
  accessTokenExpiration: string;
  refreshTokenExpiration: string;
}

export interface LoginResponse {
  token: Token;
}

export type SignUpApiResponse = ApiResponse<SignUpResponse>;
export type LoginApiResponse = ApiResponse<LoginResponse>;