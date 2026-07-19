namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// bool IsEqual = ClsCalculatorOverload.AreEqual(10, 20);
            //// bool IsEqual = ClsCalculatorOverload.AreEqual("ABC", "ABC");
            //bool IsEqual = ClsCalculatorOverload.AreEqual(10.5, 20.5);
            //if (IsEqual)
            //{
            //    Console.WriteLine("Both are Equal");
            //}
            //else
            //{
            //    Console.WriteLine("Both are Not Equal");
            //}
            //Console.ReadKey();



            bool IsEqual = ClsCalculatorGeneric.AreEqual<int>(10, 20);
            //bool IsEqual = ClsCalculatorGeneric.AreEqual<string>("ABC", "ABC");
            //bool IsEqual = ClsCalculatorGeneric.AreEqual<double>(10.5, 20.5);
            if (IsEqual)
            {
                Console.WriteLine("Both are Equal");
            }
            else
            {
                Console.WriteLine("Both are Not Equal");
            }
            Console.ReadKey();



        }
    }
}
