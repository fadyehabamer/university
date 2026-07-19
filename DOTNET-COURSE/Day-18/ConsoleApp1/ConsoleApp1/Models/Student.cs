using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        // Navigation properties
        // 1. Each student can have many courses and each course can have many students
        // 2. Each student can have many homeworks
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
