using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SimpleTcp;
using Core.Results;

namespace Core.TcpClient
{
    public class TcpClientManager:ITcpClientService
    {
        SimpleTcpClient client;
        Boolean connectionState=false;

        //MotorCurrent.Motor1 MotorCurrent.Motor2 SystemTempe.Panel SystemTempe.Bellows
        public String TcpMessage;


        public TcpClientManager(String initTcpMessage)
        {
            TcpMessage = initTcpMessage;
            client = new SimpleTcpClient("127.0.0.1:9000");
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
            client.Connect();
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            TcpMessage = Encoding.UTF8.GetString(e.Data);
        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            //TcpMessage = "404&&404&&404&&404";
            connectionState = false;
            client.Connect();
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            //TcpMessage = "0&&0&&0&&0";
            connectionState = true;
        }

        public Result Send(String message)
        {
            if (connectionState)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    client.Send(message);
                    return new Result(true, "Başarı ile gönderildi");
                }
                else
                {
                    return new Result(true, "Messaj Boş");
                }
            }
            else
            {
                return new Result(false, "Server Baglanılamadı");
            }
        }
    }
}
