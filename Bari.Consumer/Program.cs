using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Bari.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Consumer! \n");

            Consumer consumer = new Consumer("helloWorldBari", "localhost");
            consumer.Consume();
        }
    }
}
