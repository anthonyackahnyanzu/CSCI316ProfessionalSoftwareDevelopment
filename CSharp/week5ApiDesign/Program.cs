using System;

namespace Week5ApiDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Week 5: API Design - SOLID Principles\n");
            Console.WriteLine("Single Responsibility Principle:");
            SingleResponsibilityDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("Open/Closed Principle:");
            OpenClosedDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("Liskov Substitution Principle:");
            LiskovSubstitutionDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("Interface Segregation Principle:");
            InterfaceSegregationDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("Dependency Inversion Principle:");
            DependencyInversionDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("Dependency Injection with AutoMapper:");
            DependencyInversionDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("Dependency Injection with Interface and Microsoft DI:");
            DependencyInjectionWithInterfaceDemo.RunDemo();
            Console.WriteLine();

            Console.WriteLine("See SOLID_Notes.txt for explanations and examples.");
        }
    }
}
