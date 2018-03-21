using System;
using Grpc.Core;
using KnockKnock;

namespace KnockKnockClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new KnockKnock.KnockKnockService.KnockKnockServiceClient(channel);

            KnockKnockResponse response = new KnockKnockResponse { Line = "", IsPunchLine = false };

            while (!response.IsPunchLine)
            {
                string line;
                if (response.Line == "")
                {
                    line = "Tell me a knock knock joke";
                }
                else if (response.Line == "Knock knock!")
                {
                    line = "Who's there?";
                }
                else
                {
                    line = response.Line + " who?";
                }
                Console.WriteLine("Request: " + line);
                response = client.RequestKnockKnock(new KnockKnockRequest { Line = line });
                Console.WriteLine("Response: " + response.Line);
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
