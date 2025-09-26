"use client"

import {Button} from '@/components/ui/button'
import {Card,CardHeader,CardDescription,CardContent,CardTitle} from '@/components/ui/card'
import { Input } from '@/components/ui/input'
import { Separator } from '@radix-ui/react-separator'
import Link from 'next/link'

const SignIn = () => {
  return (
    <div className='h-full flex items-center justify-center bg-[#1b0918]'>
        <Card className='md:h-auto w-[80%] sm:w-[420px] p-4 sm:p-8'>
            <CardHeader>
                <CardTitle className='text-center'>
                    Sign Up
                      </CardTitle>
                    <CardDescription className='text-sm text-center text-accent-foreground'>
                          Please enter your email and password to log in.
                    </CardDescription>
              
            </CardHeader>
            <CardContent className='px-2 sm:px-6'>
                <form action="" className='space-y-3'>
                  <Input
                   type='email'
                   disabled={false}
                   placeholder='Email'
                   value={""}
                   onChange={()=>{}}
                   required/>
                  <Input
                   type='password'
                   disabled={false}
                   placeholder='Password'
                   value={""}
                   onChange={()=>{}}
                   required/>
                   <Button className='w-full cursor-pointer' size='lg' disabled={false}>Sign In</Button>
                </form>   
                <Separator/>
                <p className='text-center text-sm mt-2 text-muted-foreground'>Don't have an account? 
                <Link className='text-sky-700 ml-4 hover-underline cursor-pointer' href='/sign-up'>Sign up</Link></p>
            </CardContent>
        </Card>
    </div>
  )
}

export default SignIn
