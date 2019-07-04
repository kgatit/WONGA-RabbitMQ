using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WONGA.RabbitMQ.Service.Test
{
    [TestClass]
    public class MessageSenderTest
    {
        [TestMethod]
        public void Body_Interpolates_Name_Success()
        {
            //Given
            var messageSender = new MessageSender() { Name = "Tebogo" };

            //When
            var result = messageSender.Body();

            //Then
            Assert.AreEqual("Hello my name is, Tebogo", result);
        }
    }
}