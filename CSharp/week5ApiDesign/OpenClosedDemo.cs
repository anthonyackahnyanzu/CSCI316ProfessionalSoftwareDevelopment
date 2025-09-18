using System;

// Open/Closed Principle (OCP) Example
// Classes should be open for extension, but closed for modification.
namespace Week5ApiDesign
{
    // Base class for course grading
    public abstract class Grader
    {
        public abstract string Grade(int score);
    }

    // Extension for Math grading
    public class MathGrader : Grader
    {
        public override string Grade(int score) => score >= 90 ? "A" : "B";
    }

    // Extension for History grading
    public class HistoryGrader : Grader
    {
        public override string Grade(int score) => score >= 80 ? "A" : "B";
    }

    public static class OpenClosedDemo
    {
        public static void RunDemo()
        {
            Grader math = new MathGrader();
            Grader history = new HistoryGrader();
            Console.WriteLine($"Math grade for 95: {math.Grade(95)}");
            Console.WriteLine($"History grade for 85: {history.Grade(85)}");
        }
    }
}
