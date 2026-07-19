namespace DAY02_challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            arr[0] = 100;
            arr[^1] = 1000;
            // another way to find the last element -->  arr[arr.Length - 1] = 1000;
            Console.WriteLine("First element: " + arr[0]);
            Console.WriteLine("Last element: " + arr[^1]);
        }
    }
}
