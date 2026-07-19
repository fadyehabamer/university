using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the atm \n");
        b:
            Console.WriteLine("enter the password");
            int password = int.Parse(Console.ReadLine());
            if (password == 1111)
            {
            a:
                Console.WriteLine("access verified\n");
                Console.WriteLine("1-Check the Balance\n");
                Console.WriteLine("2- Withdraw\n");
                Console.WriteLine("3- Deposit\n");
                Console.WriteLine("4-exit\n");
                Console.WriteLine("\n");
                Console.WriteLine("Enter your option: ");
                int option = int.Parse(Console.ReadLine());
                int balance = 500;
                switch (option)
                {case 1: Console.WriteLine("your balance is " + balance);
                        break;
                    case 2: Console.WriteLine("amount of money to withdraw");
                        int withdraw = int.Parse(Console.ReadLine());
                        if (withdraw > balance - 500)
                        {Console.WriteLine("can not withdraw\n " );}
                        else
                        {balance -= withdraw;
                           Console.WriteLine("your balanace is" + balance);}
                        break;
                    case 3: Console.WriteLine("enter  the deposit money");
                        int money = int.Parse(Console.ReadLine());
                        balance += money;
                        Console.WriteLine("your balance is " + balance);
                        break;
                    case 4: Console.WriteLine("thanks for using our atm");
                        break;
                    default: Console.WriteLine("invalid option");
                        break;  }
                Console.WriteLine("do you want to redo(Y/N)");
                char question = char.Parse(Console.ReadLine());
                if (question == 'Y')
                {goto a;}
                else { Console.WriteLine("thanks for using atm"); }}
            else{Console.WriteLine("Your Password is incorrect");
                Console.WriteLine("do you want to re enter password(Y/N)");
                char e = char.Parse(Console.ReadLine());
                if (e == 'Y')
                {goto b;}
                else { Console.WriteLine("thanks for using atm"); }
            }
        }
    }
}