using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_StudentSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Try to be cool and use arabic words but failed ✌️
            // Console.OutputEncoding = Encoding.UTF8;

            using (var context = new StudentSystemContext())
            {
                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("========= Student System Menu =========");
                    Console.WriteLine("1. Add Course");
                    Console.WriteLine("2. Add Student");
                    Console.WriteLine("3. Enroll Student in Course");
                    Console.WriteLine("4. Add Resource to Course");
                    Console.WriteLine("5. Add Homework to Course");
                    Console.WriteLine("6. View All Courses");
                    Console.WriteLine("7. View All Students");
                    Console.WriteLine("8. View All Resources");
                    Console.WriteLine("9. View All Homework");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("=======================================");
                    Console.Write("Choose an option: ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            AddCourse(context);
                            break;
                        case "2":
                            AddStudent(context);
                            break;
                        case "3":
                            EnrollStudentInCourse(context);
                            break;
                        case "4":
                            AddResourceToCourse(context);
                            break;
                        case "5":
                            AddHomeworkToCourse(context);
                            break;
                        case "6":
                            ViewAllCourses(context);
                            break;
                        case "7":
                            ViewAllStudents(context);
                            break;
                        case "8":
                            ViewAllResources(context);
                            break;
                        case "9":
                            ViewAllHomework(context);
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                    }
                }
            }
        }

        static void AddCourse(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== Add Course =====");
            Console.WriteLine("Enter course details:");
            var course = new Course
            {
                Name = ReadString("Course Name: ", maxLength: 80),
                Description = ReadString("Description (optional): ", optional: true),
                StartDate = ReadDate("Start Date (yyyy-MM-dd): "),
                EndDate = ReadDate("End Date (yyyy-MM-dd): "),
                Price = ReadDecimal("Price: "),
            };
            context.Courses.Add(course);
            context.SaveChanges();
            Console.WriteLine("Course added successfully.");
        }

        static void AddStudent(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== Add Student =====");
            Console.WriteLine("Enter student details:");
            var student = new Student
            {
                Name = ReadString("Student Name: ", maxLength: 100),
                PhoneNumber = ReadString("Phone Number (optional): ", optional: true, maxLength: 10, unicode: false),
                RegisteredOn = DateTime.Now,
                Birthday = ReadDate("Birthday (optional, yyyy-MM-dd): ", optional: true)
            };
            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Student added successfully.");
        }

        static void EnrollStudentInCourse(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== Enroll Student in Course =====");
            ViewAllStudents(context);
            var studentId = ReadInt("Enter Student ID: ");
            ViewAllCourses(context);
            var courseId = ReadInt("Enter Course ID: ");

            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };
            context.StudentCourses.Add(studentCourse);
            context.SaveChanges();
            Console.WriteLine("Student enrolled in course successfully.");
        }

        static void AddResourceToCourse(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== Add Resource to Course =====");
            ViewAllCourses(context);
            var courseId = ReadInt("Enter Course ID: ");
            var course = context.Courses.Find(courseId);

            if (course != null)
            {
                Console.WriteLine("Enter resource details:");
                var resource = new Resource
                {
                    Name = ReadString("Resource Name: ", maxLength: 50),
                    Url = ReadString("Resource URL: ", unicode: false),
                    ResourceType = ReadResourceType("Resource Type (Video, Presentation, Document, Other): "),
                    CourseId = courseId
                };
                context.Resources.Add(resource);
                context.SaveChanges();
                Console.WriteLine("Resource added to course successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        static void AddHomeworkToCourse(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== Add Homework to Course =====");
            ViewAllStudents(context);
            var studentId = ReadInt("Enter Student ID: ");
            ViewAllCourses(context);
            var courseId = ReadInt("Enter Course ID: ");

            if (context.Courses.Any(c => c.CourseId == courseId) && context.Students.Any(s => s.StudentId == studentId))
            {
                Console.WriteLine("Enter homework details:");
                var homework = new Homework
                {
                    Content = ReadString("Homework Content (file path): ", unicode: false),
                    ContentType = ReadContentType("Content Type (Application, Pdf, Zip): "),
                    SubmissionTime = DateTime.Now,
                    StudentId = studentId,
                    CourseId = courseId
                };
                context.Homeworks.Add(homework);
                context.SaveChanges();
                Console.WriteLine("Homework added successfully.");
            }
            else
            {
                Console.WriteLine("Course or Student not found.");
            }
        }

        static void ViewAllCourses(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== All Courses =====");
            var courses = context.Courses.ToList();
            if (courses.Count == 0)
            {
                Console.WriteLine("No Data Available Yet");
            }
            else
            {
                foreach (var course in courses)
                {
                    Console.WriteLine($"ID: {course.CourseId}, Name: {course.Name}, Price: {course.Price}");
                }
            }
        }

        static void ViewAllStudents(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== All Students =====");
            var students = context.Students.ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("No Data Available Yet");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}, Phone: {student.PhoneNumber}");
                }
            }
        }

        static void ViewAllResources(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== All Resources =====");
            var resources = context.Resources.ToList();
            if (resources.Count == 0)
            {
                Console.WriteLine("No Data Available Yet");
            }
            else
            {
                foreach (var resource in resources)
                {
                    Console.WriteLine($"ID: {resource.ResourceId}, Name: {resource.Name}, Type: {resource.ResourceType}, URL: {resource.Url}, Course ID: {resource.CourseId}");
                }
            }
        }

        static void ViewAllHomework(StudentSystemContext context)
        {
            Console.Clear();
            Console.WriteLine("===== All Homework =====");
            var homeworks = context.Homeworks.ToList();
            if (homeworks.Count == 0)
            {
                Console.WriteLine("No Data Available Yet");
            }
            else
            {
                foreach (var homework in homeworks)
                {
                    Console.WriteLine($"ID: {homework.HomeworkId}, Content: {homework.Content}, Type: {homework.ContentType}, Submission Time: {homework.SubmissionTime}, Student ID: {homework.StudentId}, Course ID: {homework.CourseId}");
                }
            }
        }

        static string ReadString(string prompt, bool optional = false, int maxLength = int.MaxValue, bool unicode = true)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (optional && string.IsNullOrEmpty(input)) return null;
            } while (input.Length > maxLength || (!unicode && input.Length != input.ToCharArray().Length));
            return input;
        }

        static DateTime ReadDate(string prompt, bool optional = false)
        {
            DateTime date;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (optional && string.IsNullOrEmpty(input)) return DateTime.MinValue;
            } while (!DateTime.TryParse(input, out date));
            return date;
        }

        static decimal ReadDecimal(string prompt)
        {
            decimal value;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out value));
            return value;
        }

        static int ReadInt(string prompt)
        {
            int value;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out value));
            return value;
        }

        static ResourceType ReadResourceType(string prompt)
        {
            ResourceType type;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!Enum.TryParse(input, true, out type));
            return type;
        }

        static ContentType ReadContentType(string prompt)
        {
            ContentType type;
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            } while (!Enum.TryParse(input, true, out type));
            return type;
        }
    }


}




