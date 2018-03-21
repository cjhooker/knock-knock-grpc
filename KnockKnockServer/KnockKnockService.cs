using System;
using System.Threading.Tasks;
using Grpc.Core;
using KnockKnock;

namespace KnockKnockServer
{
    public class KnockKnockService : KnockKnock.KnockKnockService.KnockKnockServiceBase
    {
        public override async Task<KnockKnockResponse> RequestKnockKnock(KnockKnockRequest request, ServerCallContext context)
        {
            return await Task.Run(() => {
                string line;
                var isPunchLine = false;

                Console.WriteLine("Request: " + request.Line);
                if (request.Line == "Tell me a knock knock joke")
                {
                    line = "Knock knock!";
                }
                else if (request.Line == "Who's there?")
                {
                    line = "Boo";
                }
                else if (request.Line == "Boo who?")
                {
                    line = "Don't cry, it's just a knock knock joke!";
                    isPunchLine = true;
                }
                else
                {
                    throw new Exception("That's not a valid line! Don't you know how knock knock jokes work?");
                }

                Console.WriteLine("Response: " + line);

                return new KnockKnockResponse { Line = line, IsPunchLine = isPunchLine };
            });
        }
    }
}