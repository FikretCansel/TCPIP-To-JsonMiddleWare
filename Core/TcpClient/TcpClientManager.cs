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
using Core.TcpObjects.Receive.Concrete;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Core.TcpClient
{
    public class TcpClientManager: ITcpClientService
    {
        SimpleTcpClient client;
        Boolean connectionState=false;
        //T _TcpClientObj;
        public IPlatform tcpObject = null;
        string _controllerName = "";

        //MotorCurrent.Motor1 MotorCurrent.Motor2 SystemTempe.Panel SystemTempe.Bellows


        public TcpClientManager()
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            _controllerName = method.DeclaringType.Name;
            // _TcpClientObj = Object;
            client = new SimpleTcpClient("127.0.0.1:8000");
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
            client.Connect();
        }
        public int i = 0;
        private void Events_DataReceived(object sender, SimpleTcp.DataReceivedEventArgs e)
        {
            IPlatform convertedObject = (IPlatform)ConvertObjectFromByteArray(e.Data);
            tcpObject = convertedObject;
            Console.WriteLine("#{0} Data received: {1}", i, tcpObject);
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

        public object ConvertObjectFromByteArray(byte[] data)
        {
            GCHandle gcHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            Type objectType = FindObjectType(_controllerName);
            object converted_data = Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), objectType);
            gcHandle.Free();
            return converted_data;

        }

        //public void ConvertObjectToByteArray(T obj)
        //{
        //    ByteArrayOutputStream out = new ByteArrayOutputStream();
        //    ObjectOutputStream os = new ObjectOutputStream(out);
        //    os.writeObject(obj);
        //    return out.toByteArray();

        //}


        public Result SendObject(string message)
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

        public Type FindObjectType(string callerControllerName)
        {
            switch (callerControllerName)
            {
                case "TcpTestController":
                    return typeof(SettedLimit);
                default:
                    return typeof(string);
            }
        }
    }
}
