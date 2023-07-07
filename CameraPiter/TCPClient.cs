using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CameraPiter
{
    internal class TCPClient
    {
        private Socket _clientSocket; //сокет клиента

        public CancellationTokenSource isWorking; //для отмены тасков

        public delegate void NewMessageCallback(string message); //делегат позволяющий сделать подписку на новые сообщения
        public delegate void ConnectedCallback(); //делегат позволяющий сделать подписку на подключение

        public event NewMessageCallback OnNewMessage; //событие нового сообщения
        public event ConnectedCallback OnConnected; //событие подключения
        public void Connect(string IDGasCan)
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clientSocket.Connect("127.0.0.1", Convert.ToInt32("102" + IDGasCan)); //подключение к серверу
            isWorking = new CancellationTokenSource();
        }  

        public async Task SendMessage(string message) //асинхронно отправляет смску
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await _clientSocket?.SendAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
        }
    }
}
