using Bari.Model;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bari.Producer
{
    public class Producer
    {
        private readonly string queueName;
        private readonly string hostName;

        public Producer(){}
        public Producer(string queue, string host)
        {
            this.queueName = queue;
            this.hostName = host;
        }

        public bool Publish(Message mensagem)
        {
            if (string.IsNullOrEmpty(queueName))
                return false;

            try
            {
                var factory = new ConnectionFactory() {
                    HostName = hostName,
                    UserName = ConnectionFactory.DefaultUser,
                    Password = ConnectionFactory.DefaultPass,
                    Port = AmqpTcpEndpoint.UseDefaultPort
                };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName, //"helloWorldBari",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    //string message = "Hello World!";
                    string message = System.Text.Json.JsonSerializer.Serialize(mensagem);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                                         routingKey: queueName, //"helloWorldBari",
                                                         basicProperties: null,
                                                         body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro ao tentar executar o envio " + ex);
                throw ex;
                // return new StatusCodeResult(500);
                return false;
            }
            return true;
        }
    }
}
