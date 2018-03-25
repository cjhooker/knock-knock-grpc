using System;
using System.Linq;
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

            var lastLineWhosThere = false;
            string jokeSessionId = null;

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
                    lastLineWhosThere = true;
                }
                else if (lastLineWhosThere)
                {
                    line = response.Line + " who?";
                    lastLineWhosThere = false;
                }
                else
                {
                    Console.WriteLine("I don't know how to respond to that.");
                    break;
                }
                Console.WriteLine("Request: " + line);
                Metadata metadata = new Metadata();
                if (jokeSessionId != null)
                {
                    metadata.Add("JokeSessionId", jokeSessionId);
                }
                var call = client.RequestKnockKnockAsync(new KnockKnockRequest { Line = line }, metadata);
                var responseHeaders = call.ResponseHeadersAsync.Result;
                response = call.ResponseAsync.Result;
                jokeSessionId = responseHeaders.Single(md => md.Key == "jokesessionid").Value;
                //Console.WriteLine("JokeSessionId set to " + jokeSessionId);
                Console.WriteLine("Response: " + response.Line);
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
