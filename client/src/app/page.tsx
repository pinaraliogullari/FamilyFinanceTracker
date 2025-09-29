"use client";

import Link from "next/link";
import { useState } from "react";
import { GiMoneyStack, GiWallet, GiChart } from "react-icons/gi";
import Footer from "@/components/layout/footer";
import { useAtom } from "jotai";
import { isAuthenticatedAtom } from "@/stores/auth-atom";

export default function HomePage() {
  const [isAuthenticated, setIsAuthenticated] = useAtom(isAuthenticatedAtom);
  return (
    <div className="min-h-screen bg-[#1b0918] text-white flex flex-col">
      <section className="flex flex-col items-center justify-center text-center py-24 px-4 bg-gradient-to-b from-[#1b0918] to-[#2b0f30]">
        <h1 className="text-4xl sm:text-5xl font-bold mb-4">
          Track Your Finances Effortlessly
        </h1>
        <p className="text-lg sm:text-xl text-gray-300 mb-8 max-w-xl">
          Income, expenses, and financial records – all in one place. Start managing your money smarter today.
        </p>
        <div className="flex gap-4">
          {!isAuthenticated && (
          <><Link
              href="/sign-in"
              className="bg-transparent border !no-underline cursor-pointer text-white font-bold py-2 px-6 rounded transition transform hover:scale-105 hover:text-black hover:shadow-[0_0_10px_#fff]"
            >
              Sign In
            </Link><Link
              href="/sign-up"
              className="bg-transparent border !no-underline cursor-pointer text-white font-bold py-2 px-6 rounded transition transform hover:scale-105 hover:text-black hover:shadow-[0_0_10px_#fff]"
            >
                Sign Up
              </Link></>
          )}
        </div>
      </section>

      <section className="py-24 px-4 max-w-6xl mx-auto grid grid-cols-1 sm:grid-cols-3 gap-8 text-center">
        <div className="flex flex-col items-center gap-4 bg-[#2b0f30] p-6 rounded-lg shadow-md">
          <GiMoneyStack className="text-5xl text-sky-500" />
          <h3 className="text-xl font-bold">Add Income & Expenses</h3>
          <p className="text-gray-300">
            Easily record all your income and expenses to keep track of your finances.
          </p>
        </div>
        <div className="flex flex-col items-center gap-4 bg-[#2b0f30] p-6 rounded-lg shadow-md">
          <GiWallet className="text-5xl text-green-500" />
          <h3 className="text-xl font-bold">View Transaction History</h3>
          <p className="text-gray-300">
            Keep an organized record of all your transactions at a glance.
          </p>
        </div>
        
        <div className="flex flex-col items-center gap-4 bg-[#2b0f30] p-6 rounded-lg shadow-md">
          <GiChart className="text-5xl text-yellow-500" />
          <h3 className="text-xl font-bold">Analytics & Reports</h3>
          <p className="text-gray-300">
            Analyze your spending and income trends with visual charts and reports.
          </p>
        </div>
      </section>
      <Footer />
    </div>
  );
}
