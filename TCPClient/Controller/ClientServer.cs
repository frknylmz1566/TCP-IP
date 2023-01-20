using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    internal class ClientServer : IClientServer
    {
        SimpleTcpClient client;
        ClientModel model = new ClientModel();
        public void ClientStart(SimpleTcpClient client)
        {
            this.client = client;
            client.Connect();
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
                    
        }
        public void SendMessage(string message)
        {
            model.SendMessage = message;
            if (client.IsConnected)
            {
                client.Send(model.SendMessage);
            }
        }
        public void ReceivedMessage(string message)
        {
            model.ReceiveMessage = message;
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            Console.WriteLine(e.IpPort + " connected " + Environment.NewLine);
        }

        private  void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.IpPort.ToString() + Encoding.UTF8.GetString(e.Data.ToArray()) + Environment.NewLine);
        }

        private  void Events_Disconnected(object sender, ConnectionEventArgs e)
        {

            Console.WriteLine(e.IpPort + " disconnected " + Environment.NewLine);

        }
    }
}

