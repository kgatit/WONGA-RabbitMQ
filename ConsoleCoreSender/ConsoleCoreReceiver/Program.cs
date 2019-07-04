using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WONGA.RabbitMQ.Service;

namespace ConsoleCoreReceiver
{
    class Program
    {
        const string Queue = "msgKey";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello this is the Receiver application!");

            var service = ServiceFactory.MessageService();

            service.Receive();
        }
    }
}