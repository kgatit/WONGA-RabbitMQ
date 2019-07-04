namespace WONGA.RabbitMQ.Service
{
    public class MessageSender : MessageBase, ISender
    {
        public string Body()
        {
            return $"Hello my name is, {Name}";
        }
    }
}
