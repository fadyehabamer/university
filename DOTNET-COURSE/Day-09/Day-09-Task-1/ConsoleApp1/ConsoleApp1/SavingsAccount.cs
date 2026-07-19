using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.interestRate = interestRate;
        }

        public double CalculateInterest()
        {
            return balance * (interestRate / 100);
        }

        public override string ToString()
        {
            return $"[Savings Account: {name}: {balance}, Interest Rate: {interestRate}%]";
        }
    }
}
