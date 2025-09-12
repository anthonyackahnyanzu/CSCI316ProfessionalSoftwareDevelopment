// Module 11: Unit Testing and Debugging
// Demonstrates a simple method suitable for unit testing.
using System;

public class Calculator
{
    public int Add(int a, int b) => a + b;
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        Console.WriteLine($"2 + 3 = {calc.Add(2, 3)}");
    }
}
