
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dog
    {
        private string name;
        private string description;
        public string breed { get; set; }
        // Private string breed  -- 👆  (Automatic Prop)


        // Automatic properties is not needed if there is a custom logic in the getter and setter
        private string owner;
        public String Owner
        {
            get
            {
                return owner;
            }
            set
            {
                if (value == "Bob")
                {
                    Console.WriteLine("Bob is not allowed to own a dog");
                }
                else
                {
                    owner = value;
                    Console.WriteLine($"{value} has a dog ✌️ ");
                }
            }
        }

        private int age;

        // properties --> getters and setters --> encapsulation --> age : Age

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                    Console.WriteLine($"Age is set to {age}");
                }
                else
                {
                    Console.WriteLine("Age cannot be negative");
                }
            }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }





        // ---------------------
        //public void setName(String name)
        //{
        //    this.name = name;
        //}
        //public void setDescription(String _description)
        //{
        //    description = _description;
        //}
        //public String getDescription() {
        //    return description;
        //}
        //public void getName()
        //{
        //    Console.WriteLine(name);
        //}

        public void Bark()
        {
            Console.WriteLine("Woof");
        }

    }
}
