
import { z } from "zod";

//REGISTER

export const RegisterSchema = z
  .object({
    firstName: z.string().min(1, "First name is required"),
    lastName: z.string().min(1, "Last name is required"),
    email: z.email({ message: "Please enter a valid email" }) ,

    password: z.string().min(8, { message: "Password must be at least 6 characters long" }),
    confirmPassword: z.string().min(8, { message: "Password must be at least 6 characters long" })
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords do not match",
    path: ["confirmPassword"]
  });

export type RegisterCredentials = z.infer<typeof RegisterSchema>;

export interface RegisterResponse {
  id: number;
  firstname: string;
  lastname: string;
  email: string;
}

//LOGIN

export const LoginSchema = z.object({
  email: z.email({ message: "Invalid email format" }), 
  password: z.string().min(1, { message: "Password is required" })
});

export type LoginCredentials = z.infer<typeof LoginSchema>;

export interface LoginResponse {
  token: string;
}

//LOGOUT
export interface LogoutResponse {
  message: string;
  success: boolean;
}

