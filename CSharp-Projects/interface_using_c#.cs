using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication42
{
    interface customer
    {
        //declare only
        void print();
        //يعني مينفعش حتي افتح قوسين للميثود او لأي حاجه تانيه  
        //ex propperty , constructor
        //like abstract classes

        //-------------------------------------------------------------------

        // لا تقبل access modifier 
        //by   default   public
        //-------------------------------------------------------------------
        //  int i = 0;
        // iterfaces dont contain fields
        //--------------------------------------------------------------------

        // if class will inhert from interface which contain method
        // the class must implement this method 
        //ex::
    }
    public class person : customer
    {
        // لو عملت run
        //هيديني  error
        //لازم اعمل implementation لل  method print()
        // public لازم الكلاس تكون وال method
        public void print() { Console.WriteLine("hello from class person"); }
        // method in line 12
    }

    public struct human : customer
    {
        //يطبق عليه ما يطبق علي الكلاس
        //structures must also implement methods in interfaces
        // public لازم ال structure تكون وال method
        public void print() { Console.WriteLine("hello from structure human"); }
    }


    //if class inherts from 2 interfaces 
    // the class must implement ALL METHODS IN the 2 interfaces
    //ex::

    interface customer2
    {
        void print2();
    }
    public class tree : customer, customer2
    {
        // tree class must implement both methods in interface customer and in interface  customer2
        //methods in line 12,55
        public void print() { Console.WriteLine("hello from tree class , customer"); }
        public void print2() { Console.WriteLine("hello from tree class , customer2"); }
    }
    //IMPORTANT NOTES 
    // it is not possible that a class inhert from 2 classes at same time
    // also in structs












    class Program
    {
        static void Main(string[] args)
        {
            customer c1 = new customer();
            customer2 c2 = new customer2();
        }
    }
}
