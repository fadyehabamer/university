namespace Day04
{
    internal class Program
    {
        static void Calculate(int n)
        {
            // convert number to string
            string numberString = n.ToString();
            // Console.WriteLine(numberString);
            //
            int[] digits = new int[numberString.Length];

            for (int i = 0; i < numberString.Length; i++)
            {
                // int <-- (string) <-- char
                digits[i] = int.Parse(numberString[i].ToString());
            }

            // calculate sum of digits
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += digits[i];
            }

            Console.WriteLine($"Sum of digits: {sum}");

        }

         static void Swap(int a, int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine($"a: {a}, b: {b}");
        }

        static double CalculateSumOfTwoNumbers(double a, double b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Calculate(1234);
            Swap(5, 10);

            double sum = CalculateSumOfTwoNumbers(5, 10);
            Console.WriteLine($"Sum of two numbers from Main: {sum}");

        }
    }
}
