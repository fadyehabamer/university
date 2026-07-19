namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person person = new Person("John", 25, "American", "New York");
            Student student = new Student("John", 25, "American", "New York", "Bachelor", "Computer Science", 3.5);
            Employee employee = new Employee(5000, "Manager", "Software Developer", "John", 25, "American", "New York");

        }

        // BASE CLASS
        public class Person
        {
            public string name;
            public int age;
            public string nationality;
            public string address;

            public Person(string name, int age, string nationality, string address)
            {
                this.name = name;
                this.age = age;
                this.nationality = nationality;
                this.address = address;
            }
        }

        // DERIVED CLASS
        public class Student : Person
        {
            string studyLevel;
            string specialization;
            double GPA;

            public Student(string name, int age, string nationality, string address , string studyLevel ,string specialization , double GPA) : base(name, age, nationality, address)
            {
                this.studyLevel = studyLevel;
                this.specialization = specialization;
                this.GPA = GPA;
            }
        }

        // DERIVED CLASS 2

        public class Employee : Person
        {
            double salary;
            string rank;
            string job;

            public Employee(double salary, string rank, string job , string name , int age , string nationality , string address) : base(name, age, nationality, address)
            {
                this.salary = salary;
                this.rank = rank;
                this.job = job;
            }

        }

    }
}
