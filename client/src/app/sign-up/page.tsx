"use client"

import {Button} from '@/components/ui/button'
import {Card,CardHeader,CardDescription,CardContent,CardTitle} from '@/components/ui/card'
import { Input } from '@/components/ui/input'
import { Separator } from '@radix-ui/react-separator'
import Link from 'next/link'

const SignUp = () => {
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
                <form action="" className='space-y-3'>
                   <Input
                   type='text'
                   disabled={false}
                   placeholder='First Name'
                   value={""}
                   onChange={()=>{}}
                   required/>
                   <Input
                   type='text'
                   disabled={false}
                   placeholder='Last Name'
                   value={""}
                   onChange={()=>{}}
                   required/>
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
                  <Input
                   type='password'
                   disabled={false}
                   placeholder='Confirm Password'
                   value={""}
                   onChange={()=>{}}
                   required/>
                   <Button className='w-full cursor-pointer' size='lg' disabled={false}>Sign Up</Button>
                </form>   
                <Separator/>
                <p className='text-center text-sm mt-2 text-muted-foreground'>Already have an account? 
                <Link className='text-sky-700 ml-4 hover-underline cursor-pointer' href='/sign-in'>Sign in{" "}</Link></p>
            </CardContent>
        </Card>
    </div>
  )
}

export default SignUp
