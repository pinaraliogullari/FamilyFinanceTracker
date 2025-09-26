"use client"

import { Button } from '@/components/ui/button'
import { Card, CardHeader, CardDescription, CardContent, CardTitle } from '@/components/ui/card'
import { Input } from '@/components/ui/input'
import { Separator } from '@radix-ui/react-separator'
import Link from 'next/link'
import { useState } from 'react'
import axios from 'axios'
import { BASE_API_URL } from '@/lib/config/api'
import { API_ENDPOINTS } from '@/lib/config/api'


const SignUpPage = () => {
  const [form, setForm] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: ""
  })
  const [pending, setPending] = useState(false)
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setPending(true)
    try {
      await axios.post(`${BASE_API_URL}${API_ENDPOINTS.AUTH}/register`, form)
    } finally {
      setPending(false)
    }
  }

  return (
    <div className='h-full flex items-center justify-center bg-[#1b0918]'>
      <Card className='md:h-auto w-[80%] sm:w-[420px] p-4 sm:p-8'>
        <CardHeader>
          <CardTitle className='text-center'>
            Sign Up
          </CardTitle>
          <CardDescription className='text-sm text-center text-accent-foreground'>
            Please enter your details to create an account.
          </CardDescription>

        </CardHeader>
        <CardContent className='px-2 sm:px-6'>
          <form onSubmit={handleSubmit} className='space-y-3'>
            <Input
              type='text'
              disabled={pending}
              placeholder='First Name'
              value={form.firstName}
              onChange={(e) => setForm({ ...form, firstName: e.target.value })}
              required />
            <Input
              type='text'
              disabled={pending}
              placeholder='Last Name'
              value={form.lastName}
              onChange={(e) => setForm({ ...form, lastName: e.target.value })}
              required />
            <Input
              type='text'
              disabled={pending}
              placeholder='Email'
              value={form.email}
              onChange={(e) => setForm({ ...form, email: e.target.value })}
              required />
            <Input
              type='password'
              disabled={pending}
              placeholder='Password'
              value={form.password}
              onChange={(e) => setForm({ ...form, password: e.target.value })}
              required />
            <Input
              type='password'
              disabled={pending}
              placeholder='Confirm Password'
              value={form.confirmPassword}
              onChange={(e) => setForm({ ...form, confirmPassword: e.target.value })}
              required />
            <Button className='w-full cursor-pointer' size='lg' disabled={pending}>Sign Up</Button>
          </form>
          <Separator />
          <p className='text-center text-sm mt-2 text-muted-foreground'>Already have an account?
            <Link className='text-sky-700 ml-4 hover-underline cursor-pointer' href='/sign-in'>Sign in{" "}</Link></p>
        </CardContent>
      </Card>
    </div>
  )
}

export default SignUpPage
