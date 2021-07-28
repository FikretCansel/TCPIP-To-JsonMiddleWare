using System;
using System.Net;
using System.Net.Sockets;

namespace ExampleServer.Sockets
{
    public class Listener
    {
        #region Variables
        Socket _Socket;
        int _Port;
        int _MaxConnectionQueue;
        #endregion

        #region Constructor
        public Listener(int port, int maxConnectionQueue)
        {
            _Port = port;
            _MaxConnectionQueue = maxConnectionQueue;
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        #endregion

        #region Public Methods
        public async void Start()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 9450);
            _Socket.Bind(ipEndPoint);
            _Socket.Listen(_MaxConnectionQueue);
            _Socket.BeginAccept(OnBeginAccept, _Socket);
        }
        #endregion

        #region Private Methods
        void OnBeginAccept(IAsyncResult asyncResult)
        {
            Socket socket = _Socket.EndAccept(asyncResult);
            Client client = new Client(socket);

            // Client tarafından gönderilen datamızı işleyeceğimiz kısım.
            client._OnExampleDTOReceived += new Sockets.OnExampleDTOReceived(OnExampleDTOReceived);
            client.Start();

            // Tekrardan dinlemeye devam diyoruz.
            _Socket.BeginAccept(OnBeginAccept, null);
        }

        void OnExampleDTOReceived(string exampleDTO)
        {
            // Client tarafından gelen data, istediğiniz gibi burada handle edebilirsiniz senaryonuza göre.
            Console.WriteLine(string.Format("Message: {0}", exampleDTO));
        }
        #endregion
    }
}