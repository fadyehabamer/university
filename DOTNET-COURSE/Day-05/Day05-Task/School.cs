using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05_Task
{
    internal class School
    {

        private List<Student> students;
        private List<Course> courses;
        private Dictionary<int, List<string>> studentCourses;

        public School()
        {
            students = new List<Student>();
            courses = new List<Course>();
            studentCourses = new Dictionary<int, List<string>>();
        }

        // Method to add a student to the school
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void EnrollStudentInCourse(int studentID, string courseName)
        {
            // Find the student by ID
            Student student = students.Find(s => s.ID == studentID);

            if (student != null)
            {
                Course course = courses.Find(c => c.Name == courseName);

                if (course != null)
                {
                    // Check if the student is already enrolled in the course
                    if (!student.CoursesEnrolled.Contains(course))
                    {
                        student.EnrollInCourse(course);
                        Console.WriteLine($"Student {student.Name} enrolled in course {courseName}.");
                    }
                    else
                    {
                        // Alert Messages
                        Console.WriteLine($"Student {student.Name} is already enrolled in course {courseName}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Course {courseName} not found.");
                }
            }
            else
            {
                Console.WriteLine($"Student with ID {studentID} not found.");
            }
        }

        public void DisplayAllStudents()
        {
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"Student Name: {student.Name}, Id: {student.ID}");
                Console.WriteLine("Enrolled Courses:");
                foreach (var course in student.CoursesEnrolled)
                {
                    Console.WriteLine($" - {course.Name}");
                }
                Console.WriteLine();
            }
        }

        public void DisplayAllCourses()
        {
            Console.WriteLine("All Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"Name: {course.Name}, Instructor: {course.Instructor}");
            }
            Console.WriteLine();
        }
    }
}

