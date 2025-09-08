// Module 10: Asynchronous Programming
// Demonstrates async and await.
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await SayHelloAsync();
    }

    static async Task SayHelloAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Hello after 1 second!");
    }
}
