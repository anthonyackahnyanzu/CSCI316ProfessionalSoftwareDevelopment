using System;

// Interface Segregation Principle (ISP) Example
// Clients should not be forced to depend on interfaces they do not use.
namespace Week5ApiDesign
{
    public interface IPrintable
    {
        void Print();
    }

    public interface IScannable
    {
        void Scan();
    }

    public class Printer : IPrintable
    {
        public void Print() => Console.WriteLine("Printing document...");
    }

    public class Scanner : IScannable
    {
        public void Scan() => Console.WriteLine("Scanning document...");
    }

    public static class InterfaceSegregationDemo
    {
        public static void RunDemo()
        {
            IPrintable printer = new Printer();
            IScannable scanner = new Scanner();
            printer.Print();
            scanner.Scan();
        }
    }
}
