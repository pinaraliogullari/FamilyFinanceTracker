"use client";

import Link from "next/link";
import { NavigationMenu, NavigationMenuList, NavigationMenuItem, NavigationMenuTrigger, NavigationMenuContent, NavigationMenuLink } from "@/components/ui/navigation-menu";
import { DropdownMenu, DropdownMenuTrigger, DropdownMenuContent, DropdownMenuItem, DropdownMenuSeparator } from "@/components/ui/dropdown-menu";
import { Button } from "@/components/ui/button";
import { FaUser } from "react-icons/fa";
import { GiMoneyStack } from "react-icons/gi";
import { IoIosLogIn } from "react-icons/io";
import { useRouter } from "next/navigation";
import { useState } from "react";
import { Separator } from "@radix-ui/react-dropdown-menu";

export default function Navbar() {
    const router = useRouter();
    const [isAuthenticated, setIsAuthenticated] = useState(true);

    const handleLogout = async () => {
        // API logout + localStorage/cookie nin ikisi de yapılacak mı
        router.push("/sign-in");
    };

    return (
        <nav className="w-full border-b bg-[#1b0918] px-6 py-3 flex items-center justify-between">

            <div className="font-bold text-lg flex items-center gap-2">
                <Link href="/" className="text-white !no-underline hover:text-white flex items-center gap-2">
                    Financial Tracker <GiMoneyStack className="text-4xl" />
                </Link>
            </div>

            <div className="flex items-center gap-4 h-10">

                <NavigationMenu>
                    <NavigationMenuList className="flex gap-2">
                        <NavigationMenuItem>
                            <NavigationMenuLink asChild>
                                <Link
                                    href="/"
                                    className="text-white font-bold !no-underline !text-base hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none"
                                >
                                    Home
                                </Link>
                            </NavigationMenuLink>
                        </NavigationMenuItem>

                        <NavigationMenuItem>
                            <NavigationMenuLink asChild>
                                <Link
                                    href="/about-us"
                                    className="text-white font-bold !no-underline text-base hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none"
                                >
                                    About Us
                                </Link>
                            </NavigationMenuLink>
                        </NavigationMenuItem>

                        {isAuthenticated && (
                            <><DropdownMenu>
                                <DropdownMenuTrigger className="text-white !text-base font-bold hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none">
                                    Transactions
                                </DropdownMenuTrigger>
                                <DropdownMenuContent className="p-2">
                                 
                                            <DropdownMenuItem asChild>
                                                <Link href="/transactions/add" className="block px-2 py-1 !text-gray-950 !no-underline cursor-pointer hover:bg-gray-100 rounded">
                                                    Add Transaction
                                                </Link>
                                            </DropdownMenuItem>
                                    
                                            <DropdownMenuItem asChild>
                                                <Link href="/transactions/records" className="block px-2 py-1 !text-gray-950 !no-underline cursor-pointer hover:bg-gray-100 rounded">
                                                    Transaction Records
                                                </Link>
                                            </DropdownMenuItem>
                                 

                                </DropdownMenuContent>
                            </DropdownMenu>
                            <DropdownMenu>
                                    <DropdownMenuTrigger className="text-white !text-base font-bold hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none">
                                        User Management
                                    </DropdownMenuTrigger>
                                    <DropdownMenuContent className="p-2">
                                     
                                                <DropdownMenuItem asChild>
                                                    <Link href="/users/list" className="block px-2 py-1 !text-gray-950 !no-underline cursor-pointer hover:bg-gray-100 rounded">
                                                        User List
                                                    </Link>
                                                </DropdownMenuItem>
                                        
                                    </DropdownMenuContent>
                                </DropdownMenu></>
                        )}
                    </NavigationMenuList>
                </NavigationMenu>

                {isAuthenticated ? (
                    <DropdownMenu>
                        <DropdownMenuTrigger asChild>
                            <Button
                                variant="ghost"
                                size="sm"
                                className="flex items-center h-full gap-2 text-white hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none"
                            >
                                <FaUser className="text-lg" /> Profile
                            </Button>
                        </DropdownMenuTrigger>
                        <DropdownMenuContent align="end" className="w-48">
                            <DropdownMenuItem asChild>
                                <Link href="/profile/my-account" className="!text-gray-950 !no-underline cursor-pointer">
                                    My Account
                                </Link>
                            </DropdownMenuItem>
                            <DropdownMenuItem asChild>
                                <Link href="/profile/my-records" className="!text-gray-950 !no-underline cursor-pointer">
                                    My Records
                                </Link>
                            </DropdownMenuItem>
                            <DropdownMenuSeparator />
                            <DropdownMenuItem className="!text-gray-950 !no-underline cursor-pointer" onClick={handleLogout}>
                                Log Out
                            </DropdownMenuItem>
                        </DropdownMenuContent>
                    </DropdownMenu>
                ) : (
                    <Link
                        href="/sign-in"
                        className="flex items-center h-full text-white font-bold !no-underline !text-base hover:text-gray-300"
                    >
                        <IoIosLogIn className="text-lg mr-1" /> Sign In
                    </Link>
                )}

            </div>
        </nav>
    );
}
