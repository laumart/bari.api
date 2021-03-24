using Bari.Model;
using System;
using Xunit;

namespace Bari.Producer.Test
{
    public class UnitTest1
    {
        private readonly Producer _producer;
        private readonly Message _message;
        public UnitTest1()
        {
            _producer = new Producer("HelloWorldTest", "localhost");
            _message = new Message()
            {
                Mensagem = "xUnit Test",
            };
        }

        [Fact]
        public void Producer_Publish()
        {
            Assert.True(_producer.Publish(_message));  
        }

        [Fact]
        public void Producer_Publish_Throw()
        {
            Assert.Throws<Exception>(() => _producer.Publish(_message));
        }
    }
}
