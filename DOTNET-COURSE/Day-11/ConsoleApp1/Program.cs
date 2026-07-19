namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Queue
            // First In First Out (FIFO)
            Queue <int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);


            Console.WriteLine("Queue elements are: ");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            // Dequeue
            Console.WriteLine("Dequeue element: " + queue.Dequeue());
            Console.WriteLine("Dequeue element: " + queue.Dequeue());
            Console.WriteLine("Dequeue element: " + queue.Dequeue());
            Console.WriteLine("Dequeue element: " + queue.Dequeue());


            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine(arr.Min());
            Console.WriteLine(arr.Max());
            Console.WriteLine(arr.Sum());
            Console.WriteLine(arr.Average());
            Console.WriteLine(arr.Count());
            Console.WriteLine(arr.Contains(3));


        }
    }
}
