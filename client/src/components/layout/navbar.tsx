"use client";

import Link from "next/link";
import { NavigationMenu, NavigationMenuList, NavigationMenuItem, NavigationMenuTrigger, NavigationMenuContent, NavigationMenuLink } from "@/components/ui/navigation-menu";
import { DropdownMenu, DropdownMenuTrigger, DropdownMenuContent, DropdownMenuItem, DropdownMenuSeparator } from "@/components/ui/dropdown-menu";
import { Button } from "@/components/ui/button";
import { FaUser } from "react-icons/fa";
import { GiMoneyStack } from "react-icons/gi";
import { useRouter } from "next/navigation";



export default function Navbar() {
    const router = useRouter();
    const handleLogout = async () => {
        //hem apiye logout isteği hem de localstoragedaki token silme işlemi mi olacak?
        router.push("/sign-in");
    };
    return (
        <nav className="w-full border-b bg-[#1b0918] px-6 py-3 flex items-center ml-auto justify-between">

            <div className="font-bold text-lg flex items-center gap-2">
                <Link href="/" className="text-white !no-underline hover:text-white flex items-center gap-2">
                    Financial Tracker <GiMoneyStack className="text-4xl" />
                </Link>
            </div>

            <div className="flex ml-auto gap-4">
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
                                    href="/"
                                    className=" text-white font-bold !no-underline text-base hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none"
                                >
                                    Hakkımızda
                                </Link>
                            </NavigationMenuLink>


                        </NavigationMenuItem>

                        <NavigationMenuItem>
                            <NavigationMenuTrigger className="text-white !text-base hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none">İşlemler</NavigationMenuTrigger>
                            <NavigationMenuContent className="p-2">
                                <ul className="grid gap-2 w-48">
                                    <li>
                                        <NavigationMenuLink asChild>
                                            <Link href="/transactions/income" className="block px-2 py-1 !text-gray-950 !no-underline hover:bg-gray-100 rounded">
                                                Gelir İşlemleri
                                            </Link>
                                        </NavigationMenuLink>
                                    </li>
                                    <li>
                                        <NavigationMenuLink asChild>
                                            <Link href="/transactions/expense" className="block px-2 py-1 !text-gray-950 !no-underline hover:bg-gray-100 rounded">
                                                Gider İşlemleri
                                            </Link>
                                        </NavigationMenuLink>
                                    </li>
                                    <li>
                                        <NavigationMenuLink asChild>
                                            <Link href="/transactions/records" className="block px-2 py-1 !text-gray-950 !no-underline hover:bg-gray-100 rounded">
                                                İşlem Kayıtları
                                            </Link>
                                        </NavigationMenuLink>
                                    </li>
                                </ul>
                            </NavigationMenuContent>
                        </NavigationMenuItem>
                    </NavigationMenuList>
                </NavigationMenu>

                <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                        <Button variant="ghost" size="sm" className="flex items-center gap-2  text-white hover:text-gray-300 bg-transparent p-0 rounded-none shadow-none">
                            <FaUser /> Profil
                        </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end" className="w-48">
                        <DropdownMenuItem asChild>
                            <Link href="/profile" className="!text-gray-950 !no-underline cursor-pointer">Hesabım</Link>
                        </DropdownMenuItem>
                        <DropdownMenuItem asChild>
                            <Link href="/profile/records" className="!text-gray-950 !no-underline cursor-pointer">Kayıtlarım</Link>
                        </DropdownMenuItem>
                        <DropdownMenuSeparator />
                        <DropdownMenuItem className="!text-gray-950 !no-underline cursor-pointer" onClick={handleLogout}>
                            Çıkış Yap
                        </DropdownMenuItem>
                    </DropdownMenuContent>
                </DropdownMenu>
            </div>
        </nav>
    );
}
