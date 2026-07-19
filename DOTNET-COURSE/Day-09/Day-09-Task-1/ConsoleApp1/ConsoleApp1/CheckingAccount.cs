using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class CheckingAccount : Account
    {
        private const double WithdrawalFee = 1.50;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
            : base(name, balance)
        {
        }

        public bool WithdrawWithFee(double amount)
        {
            if (Withdraw(amount + WithdrawalFee))
            {
                balance -= WithdrawalFee;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"[Checking Account: {name}: {balance}]";
        }
    }
}
