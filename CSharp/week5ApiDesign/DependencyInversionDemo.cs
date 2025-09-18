using System;

// Dependency Inversion Principle (DIP) Example
// Depend on abstractions, not concretions.
namespace Week5ApiDesign
{
    public interface IMessageSender
    {
        void Send(string message);
    }

    public class EmailSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine($"Email sent: {message}");
    }

    public class NotificationService
    {
        private readonly IMessageSender _sender;
        public NotificationService(IMessageSender sender)
        {
            _sender = sender;
        }
        public void Notify(string message)
        {
            _sender.Send(message);
        }
    }

    public static class DependencyInversionDemo
    {
        public static void RunDemo()
        {
            IMessageSender sender = new EmailSender();
            var service = new NotificationService(sender);
            service.Notify("SOLID principles demo!");
        }
    }
}
