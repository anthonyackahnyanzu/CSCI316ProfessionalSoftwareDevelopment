using System;

// Single Responsibility Principle (SRP) Example
// Each class should have only one reason to change.
namespace Week5ApiDesign
{
    // Handles student data
    public class StudentData
    {
        public string GetStudentName(int id) => $"Student{id}";
    }

    // Handles logging
    public class Logger
    {
        public void Log(string message) => Console.WriteLine($"LOG: {message}");
    }

    public static class SingleResponsibilityDemo
    {
        public static void RunDemo()
        {
            var studentData = new StudentData();
            var logger = new Logger();
            string name = studentData.GetStudentName(1);
            logger.Log($"Fetched student name: {name}");
        }
    }
}
