"use client";

import { useState } from "react";
import { Button } from '@/components/ui/button'
import { Card, CardHeader, CardDescription, CardContent, CardTitle } from '@/components/ui/card'
import { Input } from '@/components/ui/input'
import { Separator } from '@radix-ui/react-separator'
import Link from 'next/link'
import { useRouter } from "next/navigation";

const SignInPage = () => {
  const router = useRouter();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const handleSignIn = async (e: React.FormEvent) => {
    e.preventDefault();
    // API call for sign in
    router.push("/");
  }

  return (
    <div className='h-full flex items-center justify-center bg-[#1b0918]'>
      <Card className='md:h-auto w-[80%] sm:w-[420px] p-4 sm:p-8'>
        <CardHeader>
          <CardTitle className='text-center'>Sign In</CardTitle>
          <CardDescription className='text-sm text-center text-accent-foreground'>
            Please enter your email and password to log in.
          </CardDescription>
        </CardHeader>

        <CardContent className='px-2 sm:px-6'>
          <form action="" className='space-y-4'>
            <Input
              type='email'
              placeholder='Email'
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
            <Input
              type='password'
              placeholder='Password'
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
            <Button className='w-full cursor-pointer' size='lg'>Sign In</Button>
          </form>

          <Separator className="my-4" />

          <p className='text-center text-sm text-muted-foreground'>
            Don't have an account? 
            <Link className='text-sky-700 ml-2 hover:underline cursor-pointer' href='/sign-up'>
              Sign up
            </Link>
          </p>
        </CardContent>
      </Card>
    </div>
  )
}

export default SignInPage;
