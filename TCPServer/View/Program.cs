using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    internal class Program
    {

        static SimpleTcpServer server = new SimpleTcpServer("127.0.0.1:9000");    

        static void Main(string[] args)
        {        
            Server srv = new Server();
            srv.ServerStart(server);     
            Console.WriteLine("Server");
            Console.ReadKey();
          
        }

      
      
    }
}
