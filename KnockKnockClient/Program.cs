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
            // If they pass in a number argument, that's the jokeId to ask the server to tell
            int? jokeId = null;

            if (args.Length > 0)
            {
                jokeId = int.Parse(args[0]);
            }

            // Set up channel and client
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new KnockKnock.KnockKnockService.KnockKnockServiceClient(channel);

            // Start with an empty response for our while loop
            KnockKnockResponse response = new KnockKnockResponse { Line = "", IsPunchLine = false };

            var lastLineWhosThere = false;
            string jokeSessionId = null;

            // Loop until we get the punch line from the server
            while (!response.IsPunchLine)
            {
                string line;
                if (response.Line == "")
                {
                    // Ask for a joke
                    if (jokeId == null)
                    {
                        line = "Tell me a knock knock joke";
                    }
                    else
                    {
                        line = $"Tell me knock knock joke number {jokeId}"; 
                    }
                }
                else if (response.Line == "Knock knock!")
                {
                    line = "Who's there?";
                    lastLineWhosThere = true;
                }
                else if (lastLineWhosThere)
                {
                    // If the last thing we said was "Who's there?", then our line this time is always
                    // to say "<SERVER LINE> who?"
                    line = response.Line + " who?";
                    lastLineWhosThere = false;
                }
                else
                {
                    Console.WriteLine("I don't know how to respond to that.");
                    break;
                }

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

                Console.WriteLine("Request: " + line);
                Console.WriteLine("Response: " + response.Line);
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
