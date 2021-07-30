using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SimpleTcp;
using Core.Results;
using Entity.Abstract;
using Entity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Core.TcpClient
{
    public class TcpClientManager<T> where T:IEntity, ITcpClientService
    {
        SimpleTcpClient client;
        Boolean connectionState=false;
        T _TcpClientObj;

        //MotorCurrent.Motor1 MotorCurrent.Motor2 SystemTempe.Panel SystemTempe.Bellows


        public TcpClientManager(String initTcpMessage,T Object)
        {
            _TcpClientObj = Object;
            client = new SimpleTcpClient("127.0.0.1:9000");
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
            client.Connect();
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            ConvertObjectFromByteArray(e.Data);
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

        public void ConvertObjectFromByteArray(byte[] data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                _TcpClientObj = (T)obj;
            }

        }

        //public void ConvertObjectToByteArray(T obj)
        //{
        //    ByteArrayOutputStream out = new ByteArrayOutputStream();
        //    ObjectOutputStream os = new ObjectOutputStream(out);
        //    os.writeObject(obj);
        //    return out.toByteArray();

        //}


        public Result SendObject(T message)
        {
            if (connectionState)
            {
                    

                    client.Send(message);
                    return new Result(true, "Başarı ile gönderildi");
            }
            else
            {
                return new Result(false, "Server Baglanılamadı");
            }
        }


    }
}
