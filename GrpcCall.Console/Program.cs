using Grpc.Net.Client;
using GrpcCall.Api.Protos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcCall.Console
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7172");
            var client = new Greeter.GreeterClient(channel);

            for (int i = 0; i < 5; i++)
            {
                var response = await client.SayHelloAsync(
                    new HelloRequest { Name = "World" });

                System.Console.WriteLine(response.Message);
            }

            while (true)
            {
                var response = await client.SayHelloAsync(
                   new HelloRequest { Name = "World" });

                System.Console.WriteLine(response.Message);

                Thread.Sleep(2000);
            }

            System.Console.ReadKey();
        }
    }
}
