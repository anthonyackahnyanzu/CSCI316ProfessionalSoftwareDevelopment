// Module 8: File I/O and Serialization
// Demonstrates writing and reading a text file.
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "sample.txt";
        File.WriteAllText(path, "Hello, File!");
        string content = File.ReadAllText(path);
        Console.WriteLine($"File content: {content}");
    }
}
