using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    public class MessageRequest
    {
        public string Message { get; set; }
        public string User { get; set; }
    }

    

    
    class ServerConnectedClient : ClientBase
    {
        private Server server;

        public ServerConnectedClient(Server server, TcpClient client) : base (client)
        {
            this.server = server;
            this.client = client;
            Registerhandler<MessageRequest>(Requests.Message, ProcessMessage);
        }

        private void ProcessMessage(MessageRequest request)
        {
            foreach (var clnt in server.Clients)
            {
                clnt.SendMessage(request.User, request.Message);
            }
        }

        public void Start()
        {
            new Thread(() => ClientProc(client)).Start();
        }

        private void ClientProc(TcpClient client)
        {
            using (client)
            {
                using (var stream = client.GetStream())
                {
                    writer = new BinaryWriter(stream);
                    reader = new BinaryReader(stream);
                    writer.Write((int)Requests.ConnectionOk);
                    writer.Flush();
WorkWithClient();
                    
                }
            }
        }        

        private void SendMessage(string login, string message)
        {
            writer.Write((int)Requests.Message);
            writer.Write(message);
            writer.Flush();
        }
    }
}
