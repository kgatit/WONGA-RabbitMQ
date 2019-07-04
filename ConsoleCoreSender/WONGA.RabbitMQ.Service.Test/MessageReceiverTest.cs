using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WONGA.RabbitMQ.Service.Test
{
    [TestClass]
    public class MessageReceiverTest
    {
        [TestMethod]
        public void Body_Interpolates_Name_Success()
        {
            //Given
            var messageSender = new MessageReceiver() { Name = "Tebogo" };

            //When
            var result = messageSender.Body();

            //Then
            Assert.AreEqual("Hello Tebogo, I am your father!", result);
        }
    }
}
