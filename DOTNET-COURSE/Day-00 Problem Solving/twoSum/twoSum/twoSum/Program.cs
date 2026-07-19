namespace twoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] nums = { 1, 2, 3 };

            TwoSum(nums, 3);
        }


        // [2,5,5,11] t = 10 => [1,2]

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    result[0] = dict[complement];
                    result[1] = i;
                    return result;
                }
                dict[nums[i]] = i;
            }
            return result;

        }
    }
}
