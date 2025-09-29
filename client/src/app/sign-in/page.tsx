"use client";

import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Button } from "@/components/ui/button";
import { Card, CardHeader, CardDescription, CardContent, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Separator } from "@radix-ui/react-separator";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { login } from "@/services/auth/authservice";
import { toast } from "react-hot-toast";
import { LoginSchema } from "@/services/auth/authModels";
import { LoginPayload } from "@/services/auth/authModels";
import { useAtom } from "jotai";
import { isAuthenticatedAtom, userRoleAtom } from "@/stores/auth-atom";
import { useState } from "react";
import { jwtDecode } from "jwt-decode";

const SignInPage = () => {
  const router = useRouter();
  const [, setIsAuthenticated] = useAtom(isAuthenticatedAtom);
  const [, setUserRole] = useAtom(userRoleAtom);
  const [serverError, setServerError] = useState<string | null>(null);
  const {
    register,
    handleSubmit,
    formState: { errors, isSubmitting },
  } = useForm<LoginPayload>({
    resolver: zodResolver(LoginSchema),
  });

  const onSubmit = async (data: LoginPayload) => {
    setServerError(null); 
    try {
      const response = await login(data);
      toast.success("Login successful");
      const token = response.token.accessToken;
      localStorage.setItem("token", token);
      setIsAuthenticated(true);
      type TokenPayload = { role: string };
      const decoded = jwtDecode<TokenPayload>(token);
      setUserRole(decoded.role);
      router.push("/");
    } catch (err: any) {

      const msg =
        err?.response?.data?.Message ||
        (err?.response?.data?.Errors?.[0] ?? "Login failed");
      setServerError(msg);
    }
  };

  return (
    <div className="h-full flex items-center justify-center bg-[#1b0918]">
      <Card className="md:h-auto w-[80%] sm:w-[420px] p-4 sm:p-8">
        <CardHeader>
          <CardTitle className="text-center">Sign In</CardTitle>
          <CardDescription className="text-sm text-center text-accent-foreground">
            Please enter your email and password to log in.
          </CardDescription>
        </CardHeader>

        <CardContent className="px-2 sm:px-6">
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
            {/* API Hatası */}
            {serverError && (
              <div className="text-red-500 text-sm text-center">{serverError}</div>
            )}

            <div>
              <Input type="email" placeholder="Email" {...register("email")} />
              {errors.email && (
                <p className="text-red-500 text-xs mt-1">{errors.email.message}</p>
              )}
            </div>

            <div>
              <Input type="password" placeholder="Password" {...register("password")} />
              {errors.password && (
                <p className="text-red-500 text-xs mt-1">{errors.password.message}</p>
              )}
            </div>

            <Button
              type="submit"
              className="w-full cursor-pointer"
              size="lg"
              disabled={isSubmitting}
            >
              {isSubmitting ? "Logging in..." : "Sign In"}
            </Button>
          </form>

          <Separator className="my-4" />

          <p className="text-center text-sm text-muted-foreground">
            Don't have an account?
            <Link
              className="text-sky-700 ml-2 hover:underline cursor-pointer"
              href="/sign-up"
            >
              Sign up
            </Link>
          </p>
        </CardContent>
      </Card>
    </div>
  );
};

export default SignInPage;
