using RabbitMQ.Client;

namespace WONGA.RabbitMQ.Service
{
    public static class ServiceFactory
    {
        public static MessageService MessageService()
        {
            return new MessageService(new ConnectionFactory());
        }
    }
}
