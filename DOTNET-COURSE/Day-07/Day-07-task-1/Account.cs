using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_07_task_1
{
    internal class Account
    {
        public string Name { get; }

        // search :
        // private set is used to make the property read-only from outside the class
        public decimal Balance { get; private set; }

        public Account(string name, decimal initialBalance)
        {
            Name = name;
            Balance = initialBalance;
        }

        public void Print()
        {
            Console.WriteLine($"Account Name: {Name}");
            Console.WriteLine($"Balance: {Balance:C}");
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}.");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. New balance is {Balance:C}.");
        }
    }
}
