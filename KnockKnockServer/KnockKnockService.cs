using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using KnockKnock;
using Newtonsoft.Json;

namespace KnockKnockServer
{
    public class KnockKnockService : KnockKnock.KnockKnockService.KnockKnockServiceBase
    {
        private List<Joke> _Jokes;
        private List<JokeSession> _JokeSessions;
        private int _NextJokeSessionId = 1;
        private Random _Random;

        public KnockKnockService()
        {
            _Jokes = JsonConvert.DeserializeObject<List<Joke>>(File.ReadAllText("jokes.json"));
            _JokeSessions = new List<JokeSession>();
            _Random = new Random();
        }
        
        public override async Task<KnockKnockResponse> RequestKnockKnock(KnockKnockRequest request, ServerCallContext context)
        {
            // var jokeId = 1;
            // var joke = _Jokes.Single(j => j.JokeId == jokeId);

            return await Task.Run(async () => {
                string line;
                var isPunchLine = false;
                JokeSession jokeSession;

                Console.WriteLine("Request: " + request.Line);
                if (request.Line == "Tell me a knock knock joke")
                {
                    line = "Knock knock!";
                    jokeSession = new JokeSession {
                        JokeSessionId = _NextJokeSessionId++,
                        Joke = _Jokes[_Random.Next(_Jokes.Count)],
                        LastLineIndex = -1
                    };
                    _JokeSessions.Add(jokeSession);
                }
                else
                {
                    Metadata metadata = context.RequestHeaders;
                    var jokeSessionId = int.Parse(metadata.Single(md => md.Key == "jokesessionid").Value);
                    jokeSession = _JokeSessions.Single(js => js.JokeSessionId == jokeSessionId);
                    var requestLine = jokeSession.Joke.Lines
                        .Select((l, i) => new {Line = l, Index = i})
                        .FirstOrDefault(x => x.Line.Request == request.Line && x.Index > jokeSession.LastLineIndex);
                    if (requestLine == null) 
                    {
                        line = "That's not a valid line! Don't you know how knock knock jokes work?";
                    }
                    else
                    {
                        jokeSession.LastLineIndex = requestLine.Index;
                        line = requestLine.Line.Response;
                        if (requestLine.Index == jokeSession.Joke.Lines.Count - 1) {
                            isPunchLine = true;
                        }
                    }
                }

                Console.WriteLine("Response: " + line);

                Metadata responseHeaders = new Metadata
                {
                    { "JokeSessionId", jokeSession.JokeSessionId.ToString() }
                };
                await context.WriteResponseHeadersAsync(responseHeaders);
                return new KnockKnockResponse { Line = line, IsPunchLine = isPunchLine };
            });
        }
    }
}