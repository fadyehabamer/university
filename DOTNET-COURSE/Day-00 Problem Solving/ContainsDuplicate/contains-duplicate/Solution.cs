using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contains_duplicate
{
   public class Soloution
    {
        public bool ContainsDublicate(int[] nums)
        {
            Dictionary <int, int> keyValuePairs = new Dictionary <int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (keyValuePairs.ContainsKey(nums[i]))
                {
                    return true;
                }
                else
                {
                    keyValuePairs.Add(nums[i], 1);
                }
            }
            return false;

        }
    }
}
