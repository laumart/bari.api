using Bari.Model;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Bari.Consumer.Test
{
    public class UnitTest1
    {
        private readonly Consumer _consumer;
        ITestOutputHelper _itestOutputHelper;
        public UnitTest1(ITestOutputHelper testOutput)
        {
            _consumer = new Consumer("HelloWorldTest", "localhost");
            _itestOutputHelper = testOutput;
        }

        [Fact]
        public void Consumer_Publish()
        {
            Assert.True(_consumer.Consume());
            _itestOutputHelper.WriteLine("Teste de output");
        }

        [Fact]
        public void Consumer_Publish_Throw()
        {
            Assert.Throws<Exception>(() => _consumer.Consume());
        }
    }
}
