using System;
using Microsoft.Extensions.DependencyInjection;

// Dependency Injection Example with Interface and Microsoft DI
//
// Why is this important?
// - Dependency Injection (DI) allows you to decouple your classes from their dependencies.
// - This makes your code easier to test, maintain, and extend.
// - DI enables you to swap implementations (e.g., for testing or new features) without changing the consumer code.
//
// Why is DI better than using 'new' to create classes?
// - Using 'new' directly couples your class to a specific implementation, making it harder to change or test.
// - DI allows you to inject dependencies, so you can use mocks or stubs for unit testing.
// - DI supports the SOLID principles, especially Dependency Inversion and Single Responsibility.
// - DI frameworks (like Microsoft.Extensions.DependencyInjection) manage object lifetimes and dependencies for you.
namespace Week5ApiDesign
{
    // Define an abstraction for a greeting service
    public interface IGreetingService
    {
        string Greet(string name);
    }

    // Concrete implementation of the greeting service
    public class EnglishGreetingService : IGreetingService
    {
        public string Greet(string name) => $"Hello, {name}!";
    }

    // Consumer class that depends on the abstraction
    public class Greeter
    {
        private readonly IGreetingService _greetingService;
        public Greeter(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }
        public void SayHello(string name)
        {
            Console.WriteLine(_greetingService.Greet(name));
        }
    }

    public static class DependencyInjectionWithInterfaceDemo
    {
        public static void RunDemo()
        {
            // Setup DI container
            var services = new ServiceCollection();
            // Register the interface and its implementation
            services.AddTransient<IGreetingService, EnglishGreetingService>();
            services.AddTransient<Greeter>();
            // Build service provider
            var provider = services.BuildServiceProvider();
            // Resolve Greeter from DI
            var greeter = provider.GetRequiredService<Greeter>();
            // Use the greeter
            greeter.SayHello("SOLID Student");
        }
    }
}
