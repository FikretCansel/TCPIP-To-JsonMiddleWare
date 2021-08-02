using Business.Abstract;
using Core.Results;
using Core.TcpClient;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MessageListManager : IMessageListService
    {
        TcpClientManager tcpServerService;
        MessageList MessageList = new MessageList();
        public MessageListManager()
        {
            tcpServerService = new TcpClientManager();
        }
        private MessageList ConvertToMessageList(String TcpMessage)
        {
            String[] messagesArray = TcpMessage.Split("&&");
            MessageList.Id = Convert.ToInt32(messagesArray[0]);
            MessageList.Type = Convert.ToInt32(messagesArray[1]);
            MessageList.Date = DateTime.Parse(messagesArray[2]);
            MessageList.Description = messagesArray[3];

            return MessageList;
        }
        private String ConvertToString(MessageList messageList)
        {

            String result = "";
            result += messageList.Id + ",";
            result += messageList.Type + ",";
            result += messageList.Date + ",";
            result += messageList.Description + ",";

            return result;
        }

        public MessageList Get()
        {
            MessageList MessageListValue = new MessageList();//ConvertToMessageList(tcpServerService.TcpMessage);
            return MessageListValue;
        }

        public Result Send(MessageList messageList)
        {
            return tcpServerService.Send(ConvertToString(messageList));
        }
    }
}
