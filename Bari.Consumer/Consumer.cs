
using Bari.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Bari.Consumer
{
    public class Consumer
    {
        private readonly string queueName;
        private readonly string hostName;
        public List<string> listConsume { get; set; }
        public Consumer(){}

        public Consumer(string queue, string host) 
        {
            this.queueName = queue;
            this.hostName = host;
            listConsume = new List<string>();
        }

        public bool Consume()
        {
            if (string.IsNullOrEmpty(queueName))
                return false;

            bool retorno = true;
            

            var factory = new ConnectionFactory() {
                HostName = hostName,
                UserName = ConnectionFactory.DefaultUser,
                Password = ConnectionFactory.DefaultPass,
                Port = AmqpTcpEndpoint.UseDefaultPort
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, 
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        listConsume.Add(message);
                        Console.WriteLine($"AQUI {message}");
                        //Message message = JsonConvert.DeserializeObject<Message>(retorno);
                        //Console.WriteLine($"RequisicaoID: {message.IdRequisicao} - ID:{message.Id} - Mensagem: {message.Mensagem} - Data-Hora: {message.TimeStamp}");
                        //Console.WriteLine($"RequisicaoID: {message.IdRequisicao}");
                        //Console.WriteLine($"Requisicao: {retorno}");
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + ex.StackTrace);
                        channel.BasicNack(ea.DeliveryTag, false, true);
                        retorno = false;
                        throw ex;
                    }

                };
                channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

                //Console.WriteLine(" Press [enter] to exit.");
                //Console.ReadLine();
                Thread.Sleep(1000);
            }
            //
            return retorno;
        }
    }
}