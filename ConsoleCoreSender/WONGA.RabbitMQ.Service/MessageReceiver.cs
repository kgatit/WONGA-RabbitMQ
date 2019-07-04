namespace WONGA.RabbitMQ.Service
{
    public class MessageReceiver : MessageBase, IReceiver
    {
        public string Body()
        {
            return $"Hello {Name}, I am your father!";
        }
    }
}