namespace contains_duplicate
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3, 5, 6, 1, 11, 1, 3, 4 };

            Soloution soloution = new Soloution();
            bool result = soloution.ContainsDublicate(ints);
            Console.WriteLine(result);

        }
    }
}
