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
    class ServerConnectedClient
    {
        private TcpClient client;
        private Server server;
        private BinaryReader reader;
        private BinaryWriter writer;

        public ServerConnectedClient(Server server, TcpClient client)
        {
            this.server = server;
            this.client = client;
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
                    while (true)
                    {
                        switch ((Requests)reader.ReadInt32())
                        {
                            case Requests.Message:
                                {
                                    string message = reader.ReadString();
                                    foreach (var clt in server.Clients)
                                    {
                                        clt.SendMessage(message);
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void SendMessage(string message)
        {
            writer.Write((int)Requests.Message);
            writer.Write(message);
            writer.Flush();
        }
    }
}
