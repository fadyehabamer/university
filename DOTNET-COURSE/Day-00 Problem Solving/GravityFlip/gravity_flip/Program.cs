namespace gravity_flip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public static int[] gravity_flip(int[] columns)
        {
            Array.Sort(columns);
            return columns;
        }
    }
}
