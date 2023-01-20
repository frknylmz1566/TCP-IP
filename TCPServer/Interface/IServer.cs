using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    internal interface IServer
    {

        void ServerStart(SimpleTcpServer server);
        void ReceivedMessage(string message);
        void SendMessage(string ip);
    }
       
}
