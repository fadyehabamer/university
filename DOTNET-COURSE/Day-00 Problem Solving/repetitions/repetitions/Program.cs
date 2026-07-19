namespace repetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(repetitions("AAAABBBCCD"));
        }

        public static int repetitions(string s)
        {
            int max = 0;
            int count = 1;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    count++;
                    if (count > max)
                    {
                        max = count;
                    }
                }
                else
                {
                    count = 1;
                }
            }
            return max;

        }
    }

}
