// Module 7: Exception Handling
// Demonstrates try-catch-finally.
using System;

class Program
{
    static void Main()
    {
        try
        {
            int x = 10;
            int y = 0;
            int result = x / y;

            // oopen some file
        }
        catch (Exception e)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        finally
        {
            Console.WriteLine("Done with exception handling.");
        }
    }
}
