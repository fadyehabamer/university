namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            //dog.setName("Buddy");
            //dog.setDescription("A friendly dog");
            //dog.getName();
            // Setter

            dog.Name = "Buddy";
            dog.Age = -5;
            dog.Age = 5;
            dog.Description = "A friendly dog";
            dog.breed = "Golden Retriever";
            dog.Owner = "Bob";
            dog.Owner = "Alice";
            dog.Bark();

            // Getter
            Console.WriteLine($"Age is {dog.Age}");
            //Console.WriteLine(dog.getDescription());
            //dog.bark();

            // -------------------


        }
    }
}
