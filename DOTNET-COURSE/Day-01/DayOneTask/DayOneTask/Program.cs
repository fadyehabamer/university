namespace DayOneTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int perSmallCharge = 25;
            int perLargeCharge = 35;
            double tax = 0.06;

            Console.WriteLine("Estimate for carpet cleaning service");
            Console.Write("Enter the number of small carpets: ");
            int numSmallCarpets = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of large carpets: ");
            int numLargeCarpets = Convert.ToInt32(Console.ReadLine());
            double TotalWithNoTax = (perSmallCharge * numSmallCarpets) + (perLargeCharge * numLargeCarpets);
            Console.WriteLine("Price per small Carpet: $25");
            Console.WriteLine("Price per large Carpet: $35");
            Console.WriteLine($"Cost : ${TotalWithNoTax} ");
            Console.WriteLine($"Tax :  {tax * TotalWithNoTax:C2}");
            Console.WriteLine("===============================");
            Console.WriteLine($"Total estimate: ${TotalWithNoTax + (tax * TotalWithNoTax)}");
            Console.WriteLine("This estimate is valid for 30 days");

            Console.ReadLine();




        }
    }
}
