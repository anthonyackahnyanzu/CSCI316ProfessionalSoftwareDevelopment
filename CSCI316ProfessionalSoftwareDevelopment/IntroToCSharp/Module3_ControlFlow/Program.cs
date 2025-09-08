// Module 3: Control Flow
// Demonstrates if-else and loops.
using System;

class Program
{
    static void Main()
    {
        int number = 5;
        if (number % 2 == 0)
            Console.WriteLine($"{number} is even");
        else
            Console.WriteLine($"{number} is odd");

        Console.WriteLine("Counting from 1 to 5:");
        for (int i = 1; i <= 5; i++)
            Console.WriteLine(i);
    }
}
