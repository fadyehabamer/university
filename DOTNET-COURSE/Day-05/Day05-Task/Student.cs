using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05_Task
{
    internal class Student
    {
        public int ID;
        public string Name;
        public List<Course> CoursesEnrolled;

        public Student()
        {
            CoursesEnrolled = new List<Course>();
        }

        public void EnrollInCourse(Course course)
        {
            CoursesEnrolled.Add(course);
        }

    }
}
