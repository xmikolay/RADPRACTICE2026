using Microsoft.EntityFrameworkCore;
using S00254903_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S00254903_ConsoleApp
{
    public class ConsoleStudentContext : DbContext
    {
        #region Q2 (b) In the console app create a Database Context class called ConsoleStudentContext that will support the student data. Add a migration and update the database to create the database structure.
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }

        //Constructor for MVC (accepts options)
        public ConsoleStudentContext(DbContextOptions<ConsoleStudentContext> options)
            : base(options)
        {
        }

        //Parameterless constructor for Console app
        public ConsoleStudentContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if no options were provided (preserve DI configuration)
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuring many-to-many relationship between Student and Course
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);

            //seed data will go here
            #region In the console app, seed the data shown in tables 1 to 4 into the database
            //seed lecturers
            modelBuilder.Entity<Lecturer>().HasData(
                new Lecturer { ID = 1, FirstName = "Otto", Surname = "Octavius", Title = "Dr.", Email = "otto@atu.ie" },
                new Lecturer { ID = 2, FirstName = "Dominic", Surname = "Carr", Title = "Dr.", Email = "dominic.carr@atu.ie" }
            );

            //seed students
            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, FirstName = "James", Surname = "Johnson", Age = 22, Email = "jammyboi@yahoo.com", Eircode = "A94 FP71" },
                new Student { ID = 2, FirstName = "Peter", Surname = "Parker", Age = 45, Email = "spider-man@marvel.com", Eircode = "D14 X3H0" },
                new Student { ID = 3, FirstName = "Donald", Surname = "Trump", Age = 78, Email = "thedonald45@usa.com", Eircode = "D07 Y3B0" }
            );

            //seed courses
            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Name = "Introduction to Programming", QQILevel = 6, Description = "blah blah for loop", LecturerID = 2 },
                new Course { ID = 2, Name = "Advanced Databases", QQILevel = 7, Description = "Relational DBs are superior", LecturerID = 1 }
            );
            #endregion
        }
        #endregion
    }
}
