using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            return await Task.Run(async () => {
                string line;
                var isPunchLine = false;
                JokeSession jokeSession;
                Regex jokeStartRegex = new Regex(
                    "Tell me(?: a)?(?: knock knock)? joke(?:(?: number)? (?<JokeNumber>[0-9]+))?",
                    RegexOptions.IgnoreCase);

                Console.WriteLine("Request: " + request.Line);
                if (jokeStartRegex.IsMatch(request.Line))
                {
                    // Start a joke
                    Joke joke;
                    var match = jokeStartRegex.Match(request.Line);
                    if (match.Groups["JokeNumber"].Length > 0)
                    {
                        var jokeId = int.Parse(match.Groups["JokeNumber"].Value);
                        joke = _Jokes.Single(j => j.JokeId == jokeId);
                    }
                    else
                    {
                        joke = _Jokes[_Random.Next(_Jokes.Count)];
                    }

                    line = "Knock knock!";
                    jokeSession = new JokeSession {
                        JokeSessionId = _NextJokeSessionId++,
                        Joke = joke,
                        LastLineIndex = -1
                    };
                    _JokeSessions.Add(jokeSession);
                }
                else
                {
                    // Respond to a joke

                    // Client should be sending request header with jokesessionid so we know which joke we're telling
                    // and where we are in the joke.
                    Metadata metadata = context.RequestHeaders;
                    var jokeSessionId = int.Parse(metadata.Single(md => md.Key == "jokesessionid").Value);
                    jokeSession = _JokeSessions.Single(js => js.JokeSessionId == jokeSessionId);

                    // Look up the client's line to find the response to it
                    var requestLine = jokeSession.Joke.Lines
                        .Select((l, i) => new {Line = l, Index = i})
                        .FirstOrDefault(x => 
                            x.Line.Request.Equals(request.Line, StringComparison.InvariantCultureIgnoreCase) && x.Index > jokeSession.LastLineIndex);
                    if (requestLine == null) 
                    {
                        var correctRequestLine = jokeSession.Joke.Lines
                            .Select((l, i) => new {Line = l, Index = i})
                            .FirstOrDefault(x => x.Index == jokeSession.LastLineIndex + 1);

                        line = $"That's not a valid line! Don't you know how knock knock jokes work? Try saying \"{correctRequestLine.Line.Request}\"";
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

                // Send the jokesessionid in the response headers
                Metadata responseHeaders = new Metadata
                {
                    { "jokesessionid", jokeSession.JokeSessionId.ToString() }
                };
                await context.WriteResponseHeadersAsync(responseHeaders);

                // Send the response
                return new KnockKnockResponse { Line = line, IsPunchLine = isPunchLine };
            });
        }
    }
}