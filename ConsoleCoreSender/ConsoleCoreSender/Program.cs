using System;
using WONGA.RabbitMQ.Service;

namespace ConsoleCoreSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello this is a sender application!");

            var service = ServiceFactory.MessageService();

            Console.WriteLine("Enter your name.");

            var msg = Console.ReadLine();
            var message = new MessageSender() { Name = msg };

            service.Send(message);

            Console.WriteLine(" [x] Sent {0}", msg);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
