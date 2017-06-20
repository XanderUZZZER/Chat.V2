using ChatServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    public class Client
    {
        private TcpClient client;
        private BinaryWriter writer;
        private BinaryReader reader;

        public Client()
        {
            client = new TcpClient();
        }

        public bool Start(IPAddress address)
        {
            try
            {
                client.Connect(address, 8080);
                var stream = client.GetStream();
                writer = new BinaryWriter(stream);
                reader = new BinaryReader(stream);
                new Thread(ClientProc).Start();
                return (Requests)reader.ReadInt32() == Requests.ConnectionOk;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }            
        }

        private void ClientProc()
        {
            while (true)
            {
                switch ((Requests)reader.ReadInt32())
                {
                    case Requests.Message:
                        {
                            string message = reader.ReadString();
                            MessageReceived?.Invoke(message);
                            break;
                        }
                }
            }
        }

        public void SendMessage(string message)
        {
            writer.Write((int)Requests.Message);
            writer.Write(message);
            writer.Flush();
        }

        public event Action<string> MessageReceived;
    }
}
