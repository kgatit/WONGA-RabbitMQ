using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WONGA.RabbitMQ.Service
{
    public class MessageService
    {
        const string msgKey = "msgKey";
        private IConnectionFactory _connectionFactory;

        public MessageService(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Send(MessageSender messageSender)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: msgKey,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(messageSender.Body());

                channel.BasicPublish(exchange: "",
                                     routingKey: msgKey,
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void Receive()
        {
            var messageReceiver = new MessageReceiver();

            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: msgKey,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                channel.BasicConsume(queue: msgKey,
                                     autoAck: true,
                                     consumer: consumer);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    messageReceiver.Name = message.Split(" ").Last().Trim();

                    Console.WriteLine(" [x] Received {0}", messageReceiver.Body());
                };

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
