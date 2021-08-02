using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using Core.Results;
using Core.TcpClient;

namespace Business.Concrete
{
    public class MotionToHostManager : IMotionToHostService
    {
        TcpClientManager tcpServerService;
        MotionToHost MotionToHost = new MotionToHost();

        public MotionToHostManager()
        {
            tcpServerService = new TcpClientManager();
        }

        private MotionToHost ConvertToMotionToHost(String TcpMessage)
        {
            String[] messagesArray = TcpMessage.Split("&&");
            MotionToHost.MotorCurrent.Motor1 = Convert.ToInt32(messagesArray[0]);
            MotionToHost.MotorCurrent.Motor2 = Convert.ToInt32(messagesArray[1]);
            MotionToHost.SystemTempe.Panel = Convert.ToInt32(messagesArray[2]);
            MotionToHost.SystemTempe.Bellows = Convert.ToInt32(messagesArray[3]);

            return MotionToHost;
        }

        public MotionToHost Get()
        {
            MotionToHost MotionToHostValue = new MotionToHost();//ConvertToMotionToHost(tcpServerService.TcpMessage);
            return MotionToHostValue;
        }

        private String ConvertToString(MotionToHost motionToHost)
        {

            String result = "";

            result += motionToHost.MotorCurrent.Motor1+",";
            result += motionToHost.MotorCurrent.Motor2 + ",";
            result += motionToHost.SystemTempe.Panel + ",";
            result += motionToHost.SystemTempe.Bellows + ",";

            return result;
        }



        public Result Send(MotionToHost motionToHost)
        {
            

            return tcpServerService.Send(ConvertToString(motionToHost));
        }

    }
}
