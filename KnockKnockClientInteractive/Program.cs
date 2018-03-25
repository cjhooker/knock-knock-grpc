using System;
using System.Linq;
using Grpc.Core;
using KnockKnock;

namespace KnockKnockClientInteractive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up channel and client
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new KnockKnock.KnockKnockService.KnockKnockServiceClient(channel);

            // Start with an empty response for our while loop
            KnockKnockResponse response = new KnockKnockResponse { Line = "", IsPunchLine = false };

            string jokeSessionId = null;
            
            Console.WriteLine("Try typing \"Tell me a joke\" or \"Tell me joke 1\"");

            // Loop until we get the punch line from the server
            while (!response.IsPunchLine)
            {
                string line;
                line = Console.ReadLine();

                // After the first request, the server will give us the jokesessionid,
                // and we need to pass it along on all our requests.
                Metadata metadata = new Metadata();
                if (jokeSessionId != null)
                {
                    metadata.Add("jokesessionid", jokeSessionId);
                }

                // Make the request to the server, get the jokesessionid from the response headers,
                // and get the response itself.
                var call = client.RequestKnockKnockAsync(new KnockKnockRequest { Line = line }, metadata);
                var responseHeaders = call.ResponseHeadersAsync.Result;
                jokeSessionId = responseHeaders.Single(md => md.Key == "jokesessionid").Value;
                response = call.ResponseAsync.Result;

                Console.WriteLine("Response: " + response.Line);
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("That's the end of the joke. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
