// Module 9: LINQ and Lambda Expressions
// Demonstrates a simple LINQ query and lambda.
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        foreach (var n in evenNumbers)
            Console.WriteLine(n);
    }
}
