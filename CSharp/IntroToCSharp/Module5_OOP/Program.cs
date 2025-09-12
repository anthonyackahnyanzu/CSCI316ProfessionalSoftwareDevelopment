// Module 5: Object-Oriented Programming
// Demonstrates a simple class and object usage.
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void addFive() 
    {
        Age += 5;
    }
}


class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 28 },
            new Person { Name = "Bob", Age = 34 }

        };
        people[0].addFive();
        Console.WriteLine(people.First(p => p.Age == 34).Name);
    }
}
