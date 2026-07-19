namespace ConsoleApp1
{
    internal class ClsCalculatorOverload
    {

        public static bool AreEqual(int a, int b)
        {
            return a == b;
        }

        public static bool AreEqual(string a, string b)
        {
            return a == b;
        }

        public static bool AreEqual(double a, double b)
        {
            return a == b;
        }
    }
}
