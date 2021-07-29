using Core.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMessageListService
    {

        MessageList Get();

        Result Send(MessageList messageList);

        Result TestSend(string testString);

    }
}
