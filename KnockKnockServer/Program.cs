using System;
using System.Collections.Generic;
using System.IO;
using Grpc.Core;
using KnockKnock;

namespace KnockKnockServer
{
    class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            var cacert = File.ReadAllText(@"..\certs\ca.crt");
            var cert = File.ReadAllText(@"..\certs\server.crt");
            var key = File.ReadAllText(@"..\certs\server.key");
            var keypair = new KeyCertificatePair(cert, key);
            var credentials = new SslServerCredentials(new List<KeyCertificatePair> 
            {
                keypair
            }, cacert, false);

            Server server = new Server
            {
                Services = { KnockKnock.KnockKnockService.BindService(new KnockKnockService()) },
                Ports = { new ServerPort("0.0.0.0", Port, credentials) }
            };
            server.Start();

            Console.WriteLine("Knock Knock server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
