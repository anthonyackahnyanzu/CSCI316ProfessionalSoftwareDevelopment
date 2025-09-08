// Module 4: Methods and Parameters
// Demonstrates defining and calling methods.
using System;

class Program
{
    static void Main()
    {
        int result = Add(3, 4);
        Console.WriteLine($"3 + 4 = {result}");
    }

    static int Add(int a, int b)
    {
        return a + b;
    }
}
