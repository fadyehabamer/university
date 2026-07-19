namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exception Handling


            int[] Values = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(Values[0]); // 1
            Console.WriteLine(Values[5]); // IndexOutOfRangeException

            // try catch

            //try
            //{
            //    Console.WriteLine(Values[5]);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("An error occurred: " + ex.Message);
            //    Console.WriteLine(ex.ToString());
            //}


            try
            {
                // Code that may cause an exception
                int x = 10;
                int y = 0;
                int z = x / y;

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("HOW TO ACCESS INDEX FROM OUTSIDE BOUNDRIES");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You can't divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Code that will always run
                Console.WriteLine("The 'try catch' is finished.");
            }



            Console.WriteLine("Enter 1st Number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd Number");
            int num2 = Convert.ToInt32(Console.ReadLine());


            if (num2 == 0)
            {
                Console.WriteLine("You can't divide by zero");
                return;
            }

            int result = num1 / num2;

            try
            {
                Console.WriteLine("Result is: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("The 'try catch' is finished.");
            }



            // if you want to throw an exception

            try
            {
                throw new Exception("This is an exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("The 'try catch' is finished.");
            }

        }
    }
}
