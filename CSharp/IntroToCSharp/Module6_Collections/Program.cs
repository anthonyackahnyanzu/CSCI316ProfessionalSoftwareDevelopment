// Module 6: Collections and Generics
// Demonstrates using a List and a Dictionary.
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> fruits = new List<string> { "Apple", "Banana", "Cherry" };
        foreach (var fruit in fruits)
            Console.WriteLine(fruit);

        Dictionary<string, int> ages = new Dictionary<string, int> { { "Alice", 25 }, { "Bob", 30 } };
        Console.WriteLine($"Alice's age: {ages["Alice"]}");
    }
}
