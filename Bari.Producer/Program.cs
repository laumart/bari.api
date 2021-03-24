using Bari.Model;
using RabbitMQ.Client;
using RestSharp;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Bari.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Producer! \n");

            while (true)
            {


#if DEBUG
                //Producer producer = new Producer("bariqueue", "localhost");
                //producer.Publish(new Message("Helloooooo"));

                var restClient = new RestClient("http://localhost:5000/api/Mensageria/send");
                var request = new RestRequest(Method.POST);
                var message = new Message("HelloWorld!!!");

                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddJsonBody(message);

                var response = restClient.ExecuteAsync(request);
                
                Console.WriteLine(response.Result.Content);
#else

#endif
                Thread.Sleep(5000);
            }
        }
    }
}
