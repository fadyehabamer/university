using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    class Program
    {static void print (int []array)
        {
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("enter elmenet num{0}", i + 1);
                array[i] = int.Parse(Console.ReadLine());
                total += array[i];

            } for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("element nom{0}", i + 1);
                Console.WriteLine(array[i]);
            }



            Console.WriteLine("nom of elements={0}", array.Length);
            Console.WriteLine("total is{0}", total);
            Console.WriteLine("average={0}", total / array.Length);
            Console.ReadKey();

        }
        static void Main(string[] args)
        {
         int[]grades=new int [5];
         print(grades);
           
        }
    }
}
