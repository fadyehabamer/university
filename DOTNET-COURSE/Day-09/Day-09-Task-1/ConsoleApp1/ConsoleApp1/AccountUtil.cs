public static class AccountUtil
{
    // Utility helper functions for Account class

    public static void Display<T>(List<T> accounts) where T : Account
    {
        Console.WriteLine("\n=== Accounts ==========================================");
        foreach (var acc in accounts)
        {
            Console.WriteLine(acc);
        }
    }

    public static void Deposit<T>(List<T> accounts, double amount) where T : Account
    {
        Console.WriteLine($"\n=== Depositing {amount} to Accounts =================================");
        foreach (var acc in accounts)
        {
            acc.Deposit(amount);
        }
    }

    public static void Withdraw<T>(List<T> accounts, double amount) where T : Account
    {
        Console.WriteLine($"\n=== Withdrawing {amount} from Accounts ==============================");
        foreach (var acc in accounts)
        {
            acc.Withdraw(amount);
        }
    }
}
