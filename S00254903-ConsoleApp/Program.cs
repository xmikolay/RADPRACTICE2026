using Microsoft.EntityFrameworkCore;
using S00254903_ClassLibrary;
using S00254903_ConsoleApp;
using System.Collections.Generic;

#region Q2 (d) Write a method called list_students(int CourseID) that will create an instance of the DB Context and print a list of all the students enrolled in the indicated course.
static void list_students(int courseID)
{
    using (var context = new ConsoleStudentContext())
    {       
        //list students
        var students = context.Courses
            .Where(c => c.ID == courseID)
            .Include(c => c.Students)
            .SelectMany(c => c.Students)
            .ToList();        
    }
}
#endregion

#region Write a method called connected(int StudentID, int LecturerID) that will determine if the student is enrolled in a course taught by the lecturer using a single LINQ query.
static bool connected(int studentID, int lecturerID)
{
    using (var context = new ConsoleStudentContext())
    {
        bool isConnected = context.Students
            .Where(s => s.ID == studentID) //get student
            .SelectMany(s => s.Courses) //get all their courses
            .Any(c => c.LecturerID == lecturerID); //check if any course is taught by that lecturer

        return isConnected;
    }
}
#endregion