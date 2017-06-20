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
    public class Client : ClientBase
    {
        public Client() : base(new TcpClient())
        {
            Registerhandler<MessageRequest>(Requests.Message, m => MessageReceived?.Invoke(m));
        }

        public bool Start(IPAddress address)
        {
            try
            {
                client.Connect(address, 8080);
                var stream = client.GetStream();
                writer = new BinaryWriter(stream);
                reader = new BinaryReader(stream);
                new Thread(WorkWithClient).Start();
                return (Requests)reader.ReadInt32() == Requests.ConnectionOk;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }            
        }

        public void SendMessage(string message)
        {
            writer.Write((int)Requests.Message);
            writer.Write(message);
            writer.Flush();
        }

        public event Action<MessageRequest> MessageReceived;
    }
}
