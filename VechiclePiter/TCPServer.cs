using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VechiclePiter
{
    internal class TCPServer
    {
        private static Socket _socket;
        private static List<Socket> _clients = new List<Socket>();

        public delegate void NewMessageCallback(string message);
        public delegate void NewClientCallback(Socket client);

        public static event NewMessageCallback OnNewMessage;
        public static event NewClientCallback OnNewClient;

        public static void Start()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1020);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(ipEndPoint);
            _socket.Listen(10);

            ListenToClients();
        }

        private static async Task ListenToClients()
        {
            while (true)
            {
                var newClient = await _socket.AcceptAsync();
                _clients.Add(newClient);

                OnNewClient(newClient);

                await ReceiveMessages(newClient);
            }
        }

        private static async Task ReceiveMessages(Socket clientReceived)
        {
            while (true)
            {
                byte[] buffer = new byte[1024];

                await clientReceived?.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                string message = Encoding.UTF8.GetString(buffer);
                OnNewMessage(message);
            }
        }
    }
}
