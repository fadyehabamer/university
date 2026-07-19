using System;

namespace ConsoleApp1
{
    internal class TrustAccount : Account
    {
        private const double WithdrawalLimitPercentage = 0.20;
        private const int MaxWithdrawalsPerYear = 3;
        private int withdrawalsThisYear;
        private double interestRate;
        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.interestRate = interestRate;
            withdrawalsThisYear = 0;
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawalsThisYear < MaxWithdrawalsPerYear && amount <= balance * WithdrawalLimitPercentage)
            {
                balance -= amount;
                withdrawalsThisYear++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"[Trust Account: {name}: {balance}, Withdrawals This Year: {withdrawalsThisYear}]";
        }
    }
}
