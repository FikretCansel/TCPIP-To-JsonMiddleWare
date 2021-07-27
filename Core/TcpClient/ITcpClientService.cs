using Core.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TcpClient
{
    public interface ITcpClientService
    {
        Result Send(String message);
    }
}
