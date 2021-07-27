using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SimpleTcp;
using Core.Results;

namespace Core.TcpServer
{
    public class TcpServerManager:ITcpServerService
    {
        SimpleTcpServer server;

        //MotorCurrent.Motor1 MotorCurrent.Motor2 SystemTempe.Panel SystemTempe.Bellows
        public String TcpMessage= "0&&0&&0&&0";

        public String IpPort = null;


        public TcpServerManager()
        {
            server = new SimpleTcpServer("127.0.0.1:9000");
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            TcpMessage = Encoding.UTF8.GetString(e.Data);
            IpPort = e.IpPort;
        }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            IpPort = null;
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Console.WriteLine($"{e.IpPort} : connected.");

            IpPort = e.IpPort;
        }

        public Result Send(String message)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    if (IpPort != null)
                    {
                    server.Send(IpPort, message);
                    return new Result(true, "Başarı ile gönderildi");
                    }
                    return new Result(false, "Bağlı Cihaz Yok");
                }
                else
                {
                    return new Result(true, "Messaj Boş");
                }
            }
            return new Result(false, "Soket dinlenmiyor");
        }

        public void StartServer()
        {
            server.Start();
        }
    }
}
