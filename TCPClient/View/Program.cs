using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    internal class Program : ClientServer
    {
        static SimpleTcpClient client = new SimpleTcpClient("127.0.0.1:9000");
        static void Main(string[] args)
        {
            ClientServer clt = new ClientServer();
            clt.ClientStart(client);         
            Console.WriteLine("Client");
            clt.SendMessage("Hello");
            Console.ReadLine();
        }

      
    }
}
