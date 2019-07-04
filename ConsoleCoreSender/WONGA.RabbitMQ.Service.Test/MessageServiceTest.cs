using System.Collections.Generic;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client;

namespace WONGA.RabbitMQ.Service.Test
{
    [TestClass]
    public class MessageServiceTest
    {
        [TestMethod]
        public void Send_Success()
        {
            //Given
            var mock = AutoMock.GetLoose();
            var connectionFactory = mock.Mock<IConnectionFactory>().Setup(s => s.CreateConnection()).Returns(mock.Mock<IConnection>().Object);
            var connection = mock.Mock<IConnection>().Setup(s => s.CreateModel()).Returns(mock.Mock<IModel>().Object);

            var messageSender = new MessageSender();

            var service = mock.Create<MessageService>();

            //When
            service.Send(messageSender);

            //Then
            mock.Mock<IConnectionFactory>().Verify(e => e.CreateConnection(), Times.Once);
            mock.Mock<IConnection>().Verify(e => e.CreateModel(), Times.Once);
            mock.Mock<IModel>().Verify(e => e.QueueDeclare(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>()), Times.Once);
        }

        [TestMethod]
        public void Receive_Success()
        {
            //Given
            var mock = AutoMock.GetLoose();
            var connectionFactory = mock.Mock<IConnectionFactory>().Setup(s => s.CreateConnection()).Returns(mock.Mock<IConnection>().Object);
            var connection = mock.Mock<IConnection>().Setup(s => s.CreateModel()).Returns(mock.Mock<IModel>().Object);

            var messageSender = new MessageSender();

            var service = mock.Create<MessageService>();

            //When
            service.Receive();

            //Then
            mock.Mock<IConnectionFactory>().Verify(e => e.CreateConnection(), Times.Once);
            mock.Mock<IConnection>().Verify(e => e.CreateModel(), Times.Once);
            mock.Mock<IModel>().Verify(e => e.QueueDeclare(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>()), Times.Once);
        }
    }
}