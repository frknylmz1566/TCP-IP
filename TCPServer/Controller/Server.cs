using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    internal class Server : IServer
    {
        SimpleTcpServer server;
        ServerModel model = new ServerModel();
        public void ServerStart(SimpleTcpServer server)
        {
            this.server = server;      
            server.Start();        
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        public void ReceivedMessage(string message)
        {
          
            model.ReceiveMessage = message;
        }
        public void SendMessage(string ip)
        {
            server.Send(ip.ToString(), " "+model.ReceiveMessage + " " + DateTime.Now.ToString());
        }

        private  void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.IpPort.ToString() +" "+ Encoding.UTF8.GetString(e.Data.ToArray()) + Environment.NewLine);
            ReceivedMessage(Encoding.UTF8.GetString(e.Data.ToArray()));
            SendMessage(e.IpPort.ToString());
        }

        private  void Events_ClientDisconnected(object sender, ConnectionEventArgs e)
        {

            Console.WriteLine(e.IpPort + " disconnected " + Environment.NewLine);

        }

        private  void Events_ClientConnected(object sender, ConnectionEventArgs e)
        {
            Console.WriteLine(e.IpPort + " connected " + Environment.NewLine);
        }
    }
}
