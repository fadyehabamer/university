using System;

namespace DayOneTaskB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Currency (C or c):
            decimal price = 100.50m;
            Console.WriteLine($"Price: {price:C}"); // Output: Price: $100.50

            // Digits(D or d):

            int number = 1234;
            Console.WriteLine($"Number: {number:D6}");

            //Exponential(E or e):
            double value = 12345.6789;
            Console.WriteLine($"Value: {value:E2}");


            //  Float(F or f):
            double num = 123.456789;
            Console.WriteLine($"Number: {num:F2}");

            //Number(N or n):
            int amount = 1234567;
            Console.WriteLine($"Amount: {amount:N}");

            //Percent(P or p):
            double percentage = 0.75;
            Console.WriteLine($"Percentage: {percentage:P}");

            //Hexadecimal(X or x):

            int hexValue = 0x2AF3;
            Console.WriteLine($"Hexadecimal Value: {hexValue:X}");
        }
    }
}
