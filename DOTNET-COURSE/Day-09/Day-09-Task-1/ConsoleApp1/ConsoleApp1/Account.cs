using System;
using System.Collections.Generic;

public class Account
{
    protected string name;
    protected double balance;

    public Account(string name = "Unnamed Account", double balance = 0.0)
    {
        this.name = name;
        this.balance = balance;
    }

    public bool Deposit(double amount)
    {
        if (amount < 0)
            return false;
        else
        {
            balance += amount;
            return true;
        }
    }

    public virtual bool Withdraw(double amount)
    {
        if (balance - amount >= 0)
        {
            balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public double GetBalance()
    {
        return balance;
    }

    public static double operator +(Account acc1, Account acc2)
    {
        return acc1.balance + acc2.balance;
    }

    public override string ToString()
    {
        return $"[Account: {name}: {balance}]";
    }
}
