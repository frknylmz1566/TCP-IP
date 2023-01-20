using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    internal interface IClientServer 
    {
        void ClientStart(SimpleTcpClient client);
        void SendMessage(string message);
        void ReceivedMessage(string message);      
    }
}
