using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ClsCalculatorGeneric
    {
        public static bool AreEqual<T>(T a, T b)
        {
            return a.Equals(b);
        }
    }
}
