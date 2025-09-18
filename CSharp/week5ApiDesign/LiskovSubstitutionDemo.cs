using System;

// Liskov Substitution Principle (LSP) Example
// Subtypes must be substitutable for their base types.
// Another example could be a shape class with method area and other shapes implement area
namespace Week5ApiDesign
{
    public class Course
    {
        public virtual string GetCourseType() => "General Course";
    }

    public class ScienceCourse : Course
    {
        public override string GetCourseType() => "Science Course";
    }

    public static class LiskovSubstitutionDemo
    {
        public static void RunDemo()
        {
            Course course = new ScienceCourse(); // Can substitute base with derived
            Console.WriteLine(course.GetCourseType());
        }
    }
}
