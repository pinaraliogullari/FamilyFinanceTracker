"use client"

import { useState } from "react"
import Link from "next/link"
import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import toast, { Toaster } from "react-hot-toast"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { Card, CardHeader, CardDescription, CardContent, CardTitle } from "@/components/ui/card"
import { Separator } from "@radix-ui/react-separator"
import { SignUpSchema, UserSignUpPayload } from "@/services/auth/authModels"
import { signup } from "@/services/auth/authservice"
import { useRouter } from "next/navigation"

const SignUpPage = () => {
  const [pending, setPending] = useState(false)
  const [serverError, setServerError] = useState<string | null>(null)
  const router =useRouter();

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset
  } = useForm<UserSignUpPayload>({
    resolver: zodResolver(SignUpSchema)
  })

  const onSubmit = async (data: UserSignUpPayload) => {
    setPending(true)
    setServerError(null)

    try {
      const response = await signup(data)
      toast.success(`Account created successfully for ${response.firstname} ${response.lastname}`)
      router.push('/sign-in');
      reset()
    } catch (err: any) {
      console.error("Signup error:", err)
      
  
      const backendMessage =
        err?.response?.data?.Message ||
        err?.response?.data?.message ||
        "Something went wrong"

      setServerError(backendMessage)
      toast.error(backendMessage)
    } finally {
      setPending(false)
    }
  }

  return (
    <div className="h-full flex items-center justify-center bg-[#1b0918]">
      <Toaster position="top-right" reverseOrder={false} />
      <Card className="md:h-auto w-[80%] sm:w-[420px] p-4 sm:p-8">
        <CardHeader>
          <CardTitle className="text-center">Sign Up</CardTitle>
          <CardDescription className="text-sm text-center text-accent-foreground">
            Please enter your details to create an account.
          </CardDescription>
        </CardHeader>
        <CardContent className="px-2 sm:px-6">

          {/* Backend Hatası */}
          {serverError && <p className="text-red-500 text-sm mb-2">{serverError}</p>}

          <form onSubmit={handleSubmit(onSubmit)} className="space-y-3">
            <div>
              <Input
                type="text"
                placeholder="First Name"
                disabled={pending}
                {...register("firstName")}
              />
              {errors.firstName && <p className="text-red-500 text-sm">{errors.firstName.message}</p>}
            </div>

            <div>
              <Input
                type="text"
                placeholder="Last Name"
                disabled={pending}
                {...register("lastName")}
              />
              {errors.lastName && <p className="text-red-500 text-sm">{errors.lastName.message}</p>}
            </div>

            <div>
              <Input
                type="text"
                placeholder="Email"
                disabled={pending}
                {...register("email")}
              />
              {errors.email && <p className="text-red-500 text-sm">{errors.email.message}</p>}
            </div>

            <div>
              <Input
                type="password"
                placeholder="Password"
                disabled={pending}
                {...register("password")}
              />
              {errors.password && <p className="text-red-500 text-sm">{errors.password.message}</p>}
            </div>

            <div>
              <Input
                type="password"
                placeholder="Confirm Password"
                disabled={pending}
                {...register("confirmPassword")}
              />
              {errors.confirmPassword && <p className="text-red-500 text-sm">{errors.confirmPassword.message}</p>}
            </div>

            <Button className="w-full cursor-pointer" size="lg" disabled={pending}>
              {pending ? "Signing Up..." : "Sign Up"}
            </Button>
          </form>

          <Separator className="my-3" />
          <p className="text-center text-sm mt-2 text-muted-foreground">
            Already have an account?
            <Link className="text-sky-700 ml-4 hover-underline cursor-pointer" href="/sign-in">
              Sign in
            </Link>
          </p>
        </CardContent>
      </Card>
    </div>
  )
}

export default SignUpPage
