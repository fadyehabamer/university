using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    internal class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9GSKSA6\DOTNETCOURSE;Initial Catalog=EFLastDay;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.RegisteredOn)
                    .IsRequired();

                entity.Property(e => e.Birthday)
                    .IsRequired(false);

                entity.HasMany(e => e.StudentCourses)
                    .WithOne(sc => sc.Student)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasMany(e => e.Homeworks)
                    .WithOne(h => h.Student)
                    .HasForeignKey(h => h.StudentId);
            });

            // ---------------------

            // Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Description)
                    .IsUnicode()
                    .IsRequired(false);

                entity.Property(e => e.StartDate)
                    .IsRequired();

                entity.Property(e => e.EndDate)
                    .IsRequired();

                entity.Property(e => e.Price)
                .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.HasMany(e => e.StudentCourses)
                    .WithOne(sc => sc.Course)
                    .HasForeignKey(sc => sc.CourseId);

                entity.HasMany(e => e.Resources)
                    .WithOne(r => r.Course)
                    .HasForeignKey(r => r.CourseId);

                entity.HasMany(e => e.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);
            });

            // ---------------------

            // Resource
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.ResourceType)
                    .IsRequired();

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(e => e.CourseId);
            });

            // ---------------------

            // Homework
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.ContentType)
                    .IsRequired();

                entity.Property(e => e.SubmissionTime)
                    .IsRequired();

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.Homeworks)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Homeworks)
                    .HasForeignKey(e => e.CourseId);
            });

            // ---------------------

            // StudentCourse
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId);
            });

            // ---------------------

            base.OnModelCreating(modelBuilder);
        }
    }

}
