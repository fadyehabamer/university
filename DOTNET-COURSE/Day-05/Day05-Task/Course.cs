using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05_Task
{
    internal class Course
    {
        public string Name;
        public string Instructor;
        public List<Student> StudentsEnrolled;

        public Course()
        {
            StudentsEnrolled = new List<Student>();
        }
    }
}
