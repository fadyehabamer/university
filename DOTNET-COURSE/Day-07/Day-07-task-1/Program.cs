namespace Day_07_task_1
{


    public class StaticUserOption
    {
        public static MenuOption GetUserOption()
        {
            MenuOption userOption;
            string input;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Print");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Quit");
                Console.Write("Enter your choice: ");
                input = Console.ReadLine();
            }
            while (!Enum.TryParse(input, out userOption) || userOption < MenuOption.Print || userOption > MenuOption.Quit);

            return userOption;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("JAKE Account", 20000);
            MenuOption option;

            do
            {
                option = StaticUserOption.GetUserOption();

                switch (option)
                {
                    case MenuOption.Print:
                        account.Print();
                        break;
                    case MenuOption.Withdraw:
                        DoWithdraw(account);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(account);
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Exiting program...");
                        break;
                }
            } while (option != MenuOption.Quit);
        }

        private static void DoDeposit(Account account)
        {
            Console.Write("Enter deposit amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            account.Deposit(amount);
        }

        private static void DoWithdraw(Account account)
        {
            Console.Write("Enter withdrawal amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(amount);
        }
    }
}
