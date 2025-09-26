"use client";

import Footer from "@/components/layout/footer";
import { GiMoneyStack, GiWallet, GiChart } from "react-icons/gi";

export default function AboutPage() {
  return (
    <div className="min-h-screen bg-[#1c0a20] text-white flex flex-col">
      <section className="text-center py-20 px-4 bg-[#2a0f35]">
        <h1 className="text-5xl font-extrabold mb-4">About Financial Tracker</h1>
        <p className="text-lg sm:text-xl text-gray-300 max-w-2xl mx-auto">
          Our mission is to empower you to take control of your finances with simplicity and clarity. 
          Track income, expenses, and growth with a few clicks.
        </p>
      </section>

      <section className="py-20 px-4 max-w-6xl mx-auto flex flex-col gap-16">
        <div className="flex flex-col sm:flex-row items-center gap-8">
          <GiMoneyStack className="text-6xl text-sky-500 sm:w-1/3" />
          <div className="sm:w-2/3">
            <h2 className="text-2xl font-bold mb-2">Simplify Your Finances</h2>
            <p className="text-gray-300">
              Add income and expenses easily, categorize them, and get an instant overview 
              of your financial status without any hassle.
            </p>
          </div>
        </div>

        <div className="flex flex-col sm:flex-row-reverse items-center gap-8">
          <GiWallet className="text-6xl text-green-500 sm:w-1/3" />
          <div className="sm:w-2/3">
            <h2 className="text-2xl font-bold mb-2">Organized Transaction History</h2>
            <p className="text-gray-300">
              Maintain a neat record of all transactions. Access past incomes and expenses 
              anytime to make informed financial decisions.
            </p>
          </div>
        </div>

        <div className="flex flex-col sm:flex-row items-center gap-8">
          <GiChart className="text-6xl text-yellow-500 sm:w-1/3" />
          <div className="sm:w-2/3">
            <h2 className="text-2xl font-bold mb-2">Visual Analytics & Reports</h2>
            <p className="text-gray-300">
              Analyze your spending trends and generate reports with visual charts to gain 
              insights and improve your financial health.
            </p>
          </div>
        </div>
      </section>
<Footer />
     
    </div>
  );
}
