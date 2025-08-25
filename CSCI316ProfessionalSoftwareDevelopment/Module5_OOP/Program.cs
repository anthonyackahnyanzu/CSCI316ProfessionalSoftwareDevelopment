// Module 5: Object-Oriented Programming
// Demonstrates a simple class and object usage.
using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Person p = new Person { Name = "Bob", Age = 30 };
        Console.WriteLine($"Person: {p.Name}, Age: {p.Age}");
    }
}
